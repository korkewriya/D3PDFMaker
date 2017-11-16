namespace D3PDFMaker
{
    partial class ProgressBarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProgressBarControl = new System.Windows.Forms.ProgressBar();
            this.lbl_pdfname = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.lbl_dir = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ProgressBarControl
            // 
            this.ProgressBarControl.Location = new System.Drawing.Point(27, 58);
            this.ProgressBarControl.Name = "ProgressBarControl";
            this.ProgressBarControl.Size = new System.Drawing.Size(380, 24);
            this.ProgressBarControl.TabIndex = 0;
            // 
            // lbl_pdfname
            // 
            this.lbl_pdfname.AutoEllipsis = true;
            this.lbl_pdfname.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_pdfname.Location = new System.Drawing.Point(26, 38);
            this.lbl_pdfname.MinimumSize = new System.Drawing.Size(380, 0);
            this.lbl_pdfname.Name = "lbl_pdfname";
            this.lbl_pdfname.Size = new System.Drawing.Size(380, 12);
            this.lbl_pdfname.TabIndex = 1;
            this.lbl_pdfname.Text = "ファイル名";
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_count.Location = new System.Drawing.Point(335, 88);
            this.lbl_count.MaximumSize = new System.Drawing.Size(70, 0);
            this.lbl_count.MinimumSize = new System.Drawing.Size(70, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(70, 12);
            this.lbl_count.TabIndex = 2;
            this.lbl_count.Text = "件数";
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_dir
            // 
            this.lbl_dir.AutoEllipsis = true;
            this.lbl_dir.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_dir.Location = new System.Drawing.Point(26, 17);
            this.lbl_dir.MinimumSize = new System.Drawing.Size(380, 0);
            this.lbl_dir.Name = "lbl_dir";
            this.lbl_dir.Size = new System.Drawing.Size(380, 12);
            this.lbl_dir.TabIndex = 3;
            this.lbl_dir.Text = "ディレクトリ名";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_dir);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.lbl_pdfname);
            this.Controls.Add(this.ProgressBarControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDFデータを作成中…";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBarControl;
        private System.Windows.Forms.Label lbl_pdfname;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Label lbl_dir;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}