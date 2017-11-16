using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace D3PDFMaker
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm(DoWorkEventHandler doWork, int maximum)
        {
            InitializeComponent();

            this.ProgressBarControl.Maximum = maximum;

            //イベント
            this.Shown += new EventHandler(ProgressBarForm_Shown);
            this.backgroundWorker1.DoWork += doWork;
            this.backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private object workerArgument = null;

        private object _result = null;
        /// <summary>
        /// DoWorkイベントハンドラで設定された結果
        /// </summary>
        public object Result
        {
            get
            {
                return this._result;
            }
        }

        private Exception _error = null;
        /// <summary>
        /// バックグラウンド処理中に発生したエラー
        /// </summary>
        public Exception Error
        {
            get
            {
                return this._error;
            }
        }

        /// <summary>
        /// 進行状況ダイアログで使用しているBackgroundWorkerクラス
        /// </summary>
        public BackgroundWorker BackgroundWorker
        {
            get
            {
                return this.backgroundWorker1;
            }
        }

        //フォームが表示されたときにバックグラウンド処理を開始
        private void ProgressBarForm_Shown(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync(this.workerArgument);
        }

        //ReportProgressメソッドが呼び出されたとき
        private void backgroundWorker1_ProgressChanged(
            object sender, ProgressChangedEventArgs e)
        {
            //プログレスバーの値を変更する
            if (e.ProgressPercentage < this.ProgressBarControl.Minimum)
            {
                this.ProgressBarControl.Value = this.ProgressBarControl.Minimum;
            }
            else if (this.ProgressBarControl.Maximum < e.ProgressPercentage)
            {
                this.ProgressBarControl.Value = this.ProgressBarControl.Maximum;
            }
            else
            {
                this.ProgressBarControl.Value = e.ProgressPercentage;
            }
            //メッセージのテキストを変更する
            var args = (string[])e.UserState;
            string path = args[0];
            string filename = args[1];
            string progress = args[2];
            this.lbl_dir.Text = "出力先 : " + path;
            this.lbl_pdfname.Text = "ファイル名 : " + filename;
            this.lbl_count.Text = progress;
        }

        //バックグラウンド処理が終了したとき
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this,
                    "エラー",
                    "エラーが発生しました。\n\n" + e.Error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this._error = e.Error;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                this._result = e.Result;
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
    }
}
