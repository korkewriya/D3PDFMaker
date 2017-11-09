using System;
using System.Windows.Forms;

namespace D3PDFMaker
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        public void updateProgressBar(ProgressValue data, int maxProcess, string dir)
        {
            ProgressBarControl.Value = (int)(data.count * 100 / (float)maxProcess);
            lbl_dir.Text = "出力先 : " + dir;
            lbl_pdfname.Text = "ファイル名 : " + data.name;
            lbl_count.Text = Convert.ToString(data.count) + "/" + Convert.ToString(maxProcess) ;
        }
    }
}
