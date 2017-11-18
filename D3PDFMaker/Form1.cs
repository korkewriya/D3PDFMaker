using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace D3PDFMaker
{
    public struct ProgressValue
    {
        public int count;
        public string name;
    }

    public partial class form1 : Form
    {
        /// <summary>
        /// メインフォームのイベント
        /// </summary>

        // forCustomer -> true のとき、ファイル名をお客様仕様で出力
        static public bool forCustomer = true;

        private List<string> errorList = new List<string>();

        private string tmpPath;
        private string pdfPath;
        private string excelPath;
        private string savePath;
        public static string binPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public float minX = 0;
        public float maxY = 0;
        public float slctWidth = 0;
        public float slctHeight = 0;

        public static int dpi = 100;

        public Color fontcolor = Color.FromArgb(0, 0, 0);

        List<string> ValidMansionNameList = new List<string>();
        List<string> ValidPrintCntList = new List<string>();
        List<string> ValidNoList = new List<string>();

        string font;
        string subPathName;

        // イメージファイル
        Bitmap loadingImg = Properties.Resources.loading;

        public form1()
        {
            InitializeComponent();
            GetFontList();
        }

        //PDF選択 ボタンを押したときの処理
        private void btn_PDF_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            //openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFile.Filter = "PDFファイル(*.pdf)|*.pdf";
            openFile.Title = "PDFファイルを選択してください";
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pdfPath = txtbx_PDF.Text = openFile.FileName;

                thumbBox.SizeMode = PictureBoxSizeMode.CenterImage;
                thumbBox.Image = loadingImg;
                btn_PDF.Enabled = false;

                Task.Factory.StartNew(() =>
                {
                    if (File.Exists(tmpPath))
                    {
                        File.Delete(tmpPath);
                    }

                    var thumb = new ThumbMaker();
                    tmpPath = thumb.Generate(openFile.FileName);

                    if (tmpPath == "")
                    {
                        MessageBox.Show("PDFファイルの読み込みに失敗しました。",
                                        "エラー",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        pdfPath = txtbx_PDF.Text = "";
                        thumbBox.Image = null;
                        return;
                    }

                    thumbBox.SizeMode = PictureBoxSizeMode.Zoom;
                    thumbBox.BackgroundImageLayout = ImageLayout.Center;
                    thumbBox.Image = CreateImage(tmpPath);
                });

                btn_PDF.Enabled = true;
            }
        }

        // エクセル選択 ボタンを押したときの処理
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            //openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFile.Filter = "EXCELファイル(*.xls;*.xlsx)|*.xls;*.xlsx";
            openFile.Title = "EXCELファイルを選択してください";
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                excelPath = txtbx_Excel.Text = openFile.FileName;

                ExcelReader excel;
                try
                {
                    excel = new ExcelReader(excelPath);
                }
                catch (IOException)
                {
                    MessageBox.Show("エクセルファイルが見つかりません。または、エクセルファイルを閉じてからエクセルを選択してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    excelPath = txtbx_Excel.Text = "";
                    DisableDropDownList();
                    return;
                }

                var sheet = excel.GetSheet(0);
                if (!excel.IsRegularExcel(sheet))
                {
                    MessageBox.Show("専用エクセルファイルを使用してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    excelPath = txtbx_Excel.Text = "";
                    DisableDropDownList();
                    excel.Close();
                    return;
                }

                int sheetLen = excel.GetSheetLen();
                string[] sheetNameArr = excel.GetSheetNameArr(sheetLen);
                SetSheetNumToDropDownBox(sheetLen, sheetNameArr);
                excel.Close();
            }
        }

        // フォントを選択したときの処理
        private void box_fontlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string font = box_fontlist.Text;
            lbl_fontSample.Font = new Font(font, 10);
        }

        // ディレクトリ選択 ボタンを押したときの処理
        private void btn_SaveDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "保存場所を指定してください";
            folder.RootFolder = Environment.SpecialFolder.Desktop;
            folder.ShowNewFolderButton = true;

            if (folder.ShowDialog(this) == DialogResult.OK)
            {
                savePath = txtbx_SaveDir.Text = Convert.ToString(folder.SelectedPath);
            }
        }

        // サンプルデータを作成 ボタンを押したときの処理
        private void btn_MakeSample_Click(object sender, EventArgs e)
        {
            if (minX == 0 || maxY == 0 || slctWidth == 0 || slctHeight == 0)
            {
                MessageBox.Show("PDFを選択し、座標を指定してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (savePath == null) savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            font = box_fontlist.SelectedValue.ToString();
            string sampleText = txtbx_Sampletext.Text.ToString();

            int align = GetRadioBoxValue();
            float alignedMinX = GetAlignedXcoord(minX, slctWidth, align);

            string sampleFileName = "【見本】" + Path.GetFileNameWithoutExtension(pdfPath) + ".pdf";
            string dstPath = Path.Combine(savePath, sampleFileName);

            if (File.Exists(dstPath))
            {
                DialogResult result = MessageBox.Show("既に" + dstPath + "が存在します。上書きしてもよろしいですか？",
                                                      "確認",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }

            btn_MakeSample.Enabled = false;
            btn_MakeAll.Enabled = false;
            btn_reset.Enabled = false;

            Task.Factory.StartNew(() =>
            {
                PDFAppend pdf = new PDFAppend(pdfPath);
                var pdfContentByte = pdf.CopyTemplate();
                pdf.Append(ref pdfContentByte, sampleText, alignedMinX, maxY, slctWidth, slctHeight, font, fontcolor, align);
                pdf.Close();
                try {
                    pdf.Save(dstPath);
                }
                catch(IOException) {
                    MessageBox.Show("開いているPDFを閉じてから、作成ボタンを押してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(dstPath + "を作成しました。");
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(dstPath);

            }).ContinueWith(_ =>
            {
                btn_MakeSample.Enabled = true;
                btn_MakeAll.Enabled = true;
                btn_reset.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        // 全データを作成 ボタンを押したときの処理
        private void btn_MakeAll_Click(object sender, EventArgs e)
        {
            // エラーリストを初期化しておく
            errorList.Clear();

            // エクセルリストを初期化する
            ValidMansionNameList.Clear();
            ValidPrintCntList.Clear();
            ValidNoList.Clear();

            if (minX == 0 || maxY == 0 || slctWidth == 0 || slctHeight == 0)
            {
                MessageBox.Show("PDFを選択し、座標を指定してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            else if (excelPath == null)
            {
                MessageBox.Show("エクセルファイルを選択してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            ExcelReader excel;
            try
            {
                excel = new ExcelReader(excelPath);
            }
            catch (IOException)
            {
                MessageBox.Show("エクセルファイルが見つかりません。または、エクセルファイルを閉じてから[全データ作成]ボタンを押してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (savePath == null) savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            font = box_fontlist.SelectedValue.ToString();

            int sheetNum = Convert.ToInt32(box_excelsheet.SelectedValue.ToString());
            var sheet = excel.GetSheet(sheetNum - 1);
            var sheetName = sheet.SheetName;

            var NoList = excel.ReadCol(sheet, colIndex: 0, fromRow: 3);
            var MansionNameList = excel.ReadCol(sheet, colIndex: 1, fromRow: 3);
            var PrintCntList = excel.ReadCol(sheet, colIndex: 2, fromRow: 3);

            excel.Close();

            // 指定フォルダに D3作成済PDF フォルダを作る
            string savePath2 = Path.Combine(savePath, "D3作成済PDF");
            if (!Directory.Exists(savePath2))
            {
                DialogResult result = MessageBox.Show(savePath + "に D3作成済PDF フォルダがありません。作成してもよろしいですか？",
                                                      "確認",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                Directory.CreateDirectory(savePath2);
            }

            // D3作成済PDF フォルダに、子フォルダを作る
            string subFolderName = Path.GetFileNameWithoutExtension(pdfPath) + "_" + sheetName;
            subPathName = Path.Combine(savePath2, subFolderName);
            Directory.CreateDirectory(subPathName);

            DialogResult result2 = MessageBox.Show(subPathName + " にPDFデータを作成します。よろしいですか？　同名のファイルは上書きされます。",
                                                  "確認",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result2 == DialogResult.No) return;

            /*    PDF生成の処理はここから    */

            GetValidList(ValidNoList, ValidMansionNameList, ValidPrintCntList, NoList, MansionNameList, PrintCntList);

            if(ValidMansionNameList.Count < 1)
            {
                MessageBox.Show("指定したエクセルシートに、有効なマンション名・部数の組み合わせがありません。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            /*    PDF生成の開始    */

            ProgressBarForm progressForm = new ProgressBarForm(new DoWorkEventHandler(ProgressDialog_DoWork), ValidMansionNameList.Count);
            DialogResult procResult = progressForm.ShowDialog(this);

            if(procResult == DialogResult.OK)
            {
                MessageBox.Show("PDFの出力が完了しました。",
                                "メッセージ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);

                if (errorList.Count > 0)
                {
                    string[] errorArr = errorList.ToArray();
                    var errors = String.Join("\r\n", errorArr);
                    var errorlog = Path.Combine(subPathName, "エラーログ.txt");
                    StreamWriter sw = File.CreateText(errorlog);
                    sw.Write(errors);
                    sw.Close();
                    MessageBox.Show("エラーが発生しています。エクセルリストをご確認ください。",
                                    "メッセージ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk);
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(errorlog);
                }

                progressForm.Close();
            }
        }

        private void ProgressDialog_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            int cnt = 0;
            string filename = "";
            for (int i = 0; ValidMansionNameList.Count > i; i++)
            {
                try
                {
                    string mansionName = ValidMansionNameList[i];
                    string printCnt = ValidPrintCntList[i];
                    string no = ValidNoList[i];
                    if (mansionName == "" || printCnt == "") continue;

                    var data = MakeAllPDF(mansionName, printCnt, no, subPathName, font, cnt);
                    cnt = data.count;
                    filename = data.name;
                    //progressForm.updateProgressBar(data, ValidMansionNameList.Count, subPathName);
                }
                catch (Exception error)
                {
                    Console.WriteLine("{0}\n", error);
                }
                var args = new string[] { subPathName, filename, Convert.ToString(i) + "/" + Convert.ToString(ValidMansionNameList.Count) };
                bw.ReportProgress(i, args);
            }
        }

        // サムネイルスペースをクリックしたときの処理
        private void thumbBox_Click(object sender, EventArgs e)
        {
            if (thumbBox.Image == loadingImg)
            {
                return;
            }
            else if (thumbBox.Image != null)
            {
                var f = new Form2(this);
                f.CurrentImage = thumbBox.Image;
                f.ShowDialog();
            }
            else
            {
                btn_PDF_Click(sender, e);
            }
        }

        // リセットボタンを押したときの処理
        private void btn_reset_Click(object sender, EventArgs e)
        {
            thumbBox.Image = null;
            if (File.Exists(tmpPath))
            {
                File.Delete(tmpPath);
            }
            tmpPath = "";
            txtbx_PDF.Text = "";
            txtbx_Excel.Text = "";
            txtbx_SaveDir.Text = "";
            minX = 0;
            maxY = 0;
            slctWidth = 0;
            slctHeight = 0;
            DisableDropDownList();
            errorList.Clear();
            ValidMansionNameList.Clear();
            ValidPrintCntList.Clear();
            ValidNoList.Clear();
            fontcolor = Color.FromArgb(0, 0, 0);
            colorBox.BackColor = fontcolor;
        }

        //フォームを閉じるときの処理
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(tmpPath))
            {
                File.Delete(tmpPath);
            }
        }

        // カラーボックスをクリックしたときの処理
        private void colorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorBox.BackColor = colorDialog.Color;
                fontcolor = colorDialog.Color;
            }
        }
    }
}
