using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace D3PDFMaker
{
    public partial class form1 : Form
    {
        /// <summary>
        /// メインフォームのイベントから呼び出される内部処理
        /// </summary>
        /// 

        // 有効な（共に空でない）リストを取得する
        public void GetValidList(List<string> ValidNoList, List<string> ValidMansionNameList, List<string> ValidPrintCntList,
                                 List<string> NoList, List<string> MansionNameList, List<string> PrintCntList)
        {
            for (int i = 0; MansionNameList.Count > i; i++)
            {
                string mansionName = MansionNameList[i];
                string printCnt = PrintCntList[i];
                string no = NoList[i];
                string noIndex = NoList[i];

                if (mansionName == "" && printCnt == "")    // マンション名・部数共に空の場合は無視
                {
                    continue;
                }

                if (mansionName == "" || printCnt == "")
                {
                    string errorMsg = "◆No." + noIndex + " : マンション名または部数が抜けています。";
                    errorList.Add(errorMsg);
                    continue;
                }

                int j = 0;
                if (!int.TryParse(printCnt, out j) || Convert.ToDecimal(printCnt) <= 0)
                {
                    string errorMsg = "◆No." + noIndex + " " + mansionName + " : 部数が不正な値です。";
                    errorList.Add(errorMsg);
                    continue;
                }

                if (!IsValidFilename(mansionName))
                {
                    string errorMsg = "◆No." + noIndex + " " + mansionName + " : ファイル名に使用できない文字が含まれています。";
                    errorList.Add(errorMsg);
                    continue;
                }

                ValidMansionNameList.Add(mansionName);
                ValidPrintCntList.Add(printCnt);
                ValidNoList.Add(no);
            }
        }

        // ファイル名が有効か調べる
        public bool IsValidFilename(string str)
        {
            char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();

            if (str.IndexOfAny(invalidChars) < 0)
            {
                return true;
            }
            return false;
        }

        // エクセルページ数をドロップダウンリストに反映する
        public void SetSheetNumToDropDownBox(int sheetLen, string[] sheetNameArr)
        {
            // 現在のリストをクリアする
            box_excelsheet.DataSource = null;
            box_excelsheet.Items.Clear();

            DataTable sheetTable = new DataTable();
            sheetTable.Columns.Add("ID", typeof(string));
            sheetTable.Columns.Add("DISP_NAME", typeof(string));

            for (int i = 1; sheetLen >= i; i++)
            {
                DataRow row = sheetTable.NewRow();
                row["ID"] = i.ToString();
                row["DISP_NAME"] = i.ToString() + " <" + sheetNameArr[i-1] + ">";
                sheetTable.Rows.Add(row);
            }
            box_excelsheet.Enabled = true;

            box_excelsheet.DataSource = sheetTable;
            box_excelsheet.DisplayMember = "DISP_NAME";
            box_excelsheet.ValueMember = "ID";

            box_excelsheet.SelectedItem = box_excelsheet.Items[0];
        }

        // ドロップダウンリストを無効化する
        public void DisableDropDownList()
        {
            box_excelsheet.Enabled = false;
            box_excelsheet.DataSource = null;
            box_excelsheet.Items.Clear();
            excelPath = null;
        }

        // PDFデータをまとめて作成する
        public ProgressValue MakeAllPDF(string mansionName, string printCnt, string no, string subPathName, string font, int cnt)
        {
            ProgressValue values = new ProgressValue();

            string filename;
            if (forCustomer) {  // お客様向けモード
                if (Convert.ToDecimal(printCnt) % 2 == 1)    // 奇数の場合
                {
                    printCnt = "Z" + Convert.ToString(Convert.ToDecimal(printCnt) + 1);
                }
                else    // 偶数の場合
                {
                    printCnt = "Z" + printCnt;
                }
                filename = mansionName + "_" + printCnt + ".pdf";
            }
            else    // 社内向けモード
            {
                string _no = no.PadLeft(3, '0');
                printCnt = "CP" + Convert.ToString(Math.Ceiling(Convert.ToDecimal(printCnt) / 2));
                filename = _no + "_" + mansionName + "_" + printCnt + ".pdf";
            }

            int align = GetRadioBoxValue();
            float alignedMinX = GetAlignedXcoord(minX, slctWidth, align);

            PDFAppend pdf = new PDFAppend(pdfPath);
            var pdfContentByte = pdf.CopyTemplate();
            pdf.Append(ref pdfContentByte, mansionName, alignedMinX, maxY, slctWidth, slctHeight, font, fontcolor, align);
            pdf.Close();
            string dstPath = Path.Combine(subPathName, filename);
            try
            {
                pdf.Save(dstPath);
            }
            catch (IOException)
            {
                string errorMsg = "◆No." + no + " " + mansionName + " : 開いているPDFを閉じてから、作成ボタンを押してください。";
                errorList.Add(errorMsg);
                cnt--;
            }

            values.name = filename;
            values.count = ++cnt;

            return values;
        }
        
        // フォント一覧をコンボボックスに表示する
        private void GetFontList()
        {
            DirectoryInfo dirWindowsFolder = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System));
            string fontPath = Path.Combine(dirWindowsFolder.FullName, "Fonts");
            //string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            RegistryKey fonts = GetSystemFontFromRegistry();
            Dictionary<string, string> fontDict = MakeFontDict(fonts, fontPath);

            DataTable fontTable = new DataTable();
            fontTable.Columns.Add("NAME", typeof(string));
            fontTable.Columns.Add("PATH", typeof(string));

            foreach (KeyValuePair<string, string> font in fontDict)
            {
                DataRow row = fontTable.NewRow();
                row["NAME"] = font.Key;
                row["PATH"] = font.Value;
                fontTable.Rows.Add(row);
            }

            box_fontlist.DataSource = fontTable;
            box_fontlist.DisplayMember = "NAME";
            box_fontlist.ValueMember = "PATH";
        }

        // ラジオボタンの値を取得する
        private int GetRadioBoxValue()
        {
            if (rdo_center.Checked) return 1;
            else if (rdo_left.Checked) return 0;
            else return 2;
        }

        // ファイルをロックせず画像を読み込む
        private System.Drawing.Image CreateImage(string filename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(
                filename,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
            fs.Close();
            return img;
        }

        // Alignを考慮したX座標を取得する
        private float GetAlignedXcoord(float x, float slctWidth, int align)
        {
            if (align == 0) return x;
            else if (align == 1) return x + (slctWidth / 2);
            else return x + slctWidth;
        }

        // レジストリからシステムフォント一覧を取得する
        private RegistryKey GetSystemFontFromRegistry()
        {
            RegistryKey fonts = null;
            
            fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts", false);
            if (fonts == null)
            {
                fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Fonts", false);
                if (fonts == null)
                {
                    MessageBox.Show("フォント一覧の取得に失敗しました。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return fonts;
                }
            }
            return fonts;
        }

        // フォント名とパスの辞書を作成する
        private Dictionary<string, string> MakeFontDict(RegistryKey fonts, string fontPath) {

            Dictionary<string, string> fontDict = new Dictionary<string, string>();

            string[] keys = fonts.GetValueNames();
            foreach (string key in keys)
            {
                try
                {
                    if (key.IndexOf(" & ") != -1)
                    {
                        string[] splitted = key.Split(new string[] { " & " }, StringSplitOptions.None);
                        int i = 0;
                        foreach (string _key in splitted)
                        {
                            string sub_key = Regex.Replace(_key, @"\s*\(.*\)", "");
                            string japaneseFontName = GetJapaneseFontName(sub_key);
                            if (!Regex.IsMatch(japaneseFontName, @"^[a-zA-Z0-9\s\(\)-_,\.]+$"))
                            {
                                string fontName = fonts.GetValue(key).ToString() + "," + i.ToString();
                                string fullFontPath = Path.Combine(fontPath, fontName);
                                fontDict.Add(japaneseFontName, fullFontPath);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        string sub_key = Regex.Replace(key, @"\s*\(.*\)", "");
                        string japaneseFontName = GetJapaneseFontName(sub_key);

                        if (!Regex.IsMatch(japaneseFontName, @"^[a-zA-Z0-9\s\(\)-_,\.]+$"))
                        {
                            string fullFontPath = Path.Combine(fontPath, fonts.GetValue(key).ToString());
                            fontDict.Add(japaneseFontName, fullFontPath);
                        }
                    }
                }
                catch (ArgumentException) { }
            }
            return fontDict;
        }

        // 日本語フォント名を取得する
        public string GetJapaneseFontName(string fontName)
        {
            try
            {
                FontFamily japaneseFontFamily = new FontFamily(fontName);
                return japaneseFontFamily.GetName(1041);    // 日本の国コード 1041
            }
            catch (ArgumentException)
            {
                return fontName;
            }
        }

        // 【デバッグ用】フォント一覧の出力
        public void WriteLog(List<string> strs)
        {
            string Desktop = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            StreamWriter sw = File.CreateText(Path.Combine(Desktop, "log.txt"));
            foreach (string s in strs)
            {
                sw.WriteLine(s);
            }
            sw.Close();
        }
    }
}
