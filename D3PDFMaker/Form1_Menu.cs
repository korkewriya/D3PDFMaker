using System;
using System.IO;
using System.Windows.Forms;

namespace D3PDFMaker
{
    public partial class form1 : Form
    {
        private void SaveExcelTemplToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savePath == null) savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = savePath;
            sfd.FileName = "マンション名・地名リスト.xlsx";
            sfd.Filter = "EXCELファイル(*.xlsx)|*.xlsx";
            sfd.Title = "エクセルテンプレートを出力するフォルダを指定してください。";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.DereferenceLinks = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string excelTempl = Path.Combine(form1.binPath, "templ");
                File.Copy(excelTempl, sfd.FileName, overwrite: true);
                MessageBox.Show(sfd.FileName + "を作成しました。",
                                "メッセージ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
            }
        }

        private void ShowManualtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string manual = Path.Combine(form1.binPath, "操作ガイド.pdf");
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(manual);
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
