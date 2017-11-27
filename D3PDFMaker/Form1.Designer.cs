namespace D3PDFMaker
{
    partial class form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.thumbBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbx_PDF = new System.Windows.Forms.TextBox();
            this.btn_PDF = new System.Windows.Forms.Button();
            this.btn_Excel = new System.Windows.Forms.Button();
            this.txtbx_Excel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.box_fontlist = new System.Windows.Forms.ComboBox();
            this.rdo_center = new System.Windows.Forms.RadioButton();
            this.rdo_left = new System.Windows.Forms.RadioButton();
            this.rdo_right = new System.Windows.Forms.RadioButton();
            this.btn_SaveDir = new System.Windows.Forms.Button();
            this.txtbx_SaveDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_MakeSample = new System.Windows.Forms.Button();
            this.btn_MakeAll = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lbl_fontSample = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbx_Sampletext = new System.Windows.Forms.TextBox();
            this.box_excelsheet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.エクセルテンプレートを保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // thumbBox
            // 
            this.thumbBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbBox.Location = new System.Drawing.Point(12, 37);
            this.thumbBox.Name = "thumbBox";
            this.thumbBox.Size = new System.Drawing.Size(236, 334);
            this.thumbBox.TabIndex = 0;
            this.thumbBox.TabStop = false;
            this.thumbBox.Click += new System.EventHandler(this.thumbBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ベースPDFファイル";
            // 
            // txtbx_PDF
            // 
            this.txtbx_PDF.Location = new System.Drawing.Point(270, 57);
            this.txtbx_PDF.Name = "txtbx_PDF";
            this.txtbx_PDF.ReadOnly = true;
            this.txtbx_PDF.Size = new System.Drawing.Size(343, 19);
            this.txtbx_PDF.TabIndex = 2;
            // 
            // btn_PDF
            // 
            this.btn_PDF.Location = new System.Drawing.Point(619, 53);
            this.btn_PDF.Name = "btn_PDF";
            this.btn_PDF.Size = new System.Drawing.Size(23, 23);
            this.btn_PDF.TabIndex = 3;
            this.btn_PDF.Text = "...";
            this.btn_PDF.UseVisualStyleBackColor = true;
            this.btn_PDF.Click += new System.EventHandler(this.btn_PDF_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.Location = new System.Drawing.Point(619, 108);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(23, 23);
            this.btn_Excel.TabIndex = 6;
            this.btn_Excel.Text = "...";
            this.btn_Excel.UseVisualStyleBackColor = true;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // txtbx_Excel
            // 
            this.txtbx_Excel.Location = new System.Drawing.Point(270, 112);
            this.txtbx_Excel.Name = "txtbx_Excel";
            this.txtbx_Excel.ReadOnly = true;
            this.txtbx_Excel.Size = new System.Drawing.Size(343, 19);
            this.txtbx_Excel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "リストエクセルファイル";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "フォント";
            // 
            // box_fontlist
            // 
            this.box_fontlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_fontlist.FormattingEnabled = true;
            this.box_fontlist.Location = new System.Drawing.Point(270, 223);
            this.box_fontlist.Name = "box_fontlist";
            this.box_fontlist.Size = new System.Drawing.Size(197, 20);
            this.box_fontlist.TabIndex = 10;
            this.box_fontlist.SelectedIndexChanged += new System.EventHandler(this.box_fontlist_SelectedIndexChanged);
            // 
            // rdo_center
            // 
            this.rdo_center.AutoSize = true;
            this.rdo_center.Checked = true;
            this.rdo_center.Location = new System.Drawing.Point(270, 262);
            this.rdo_center.Name = "rdo_center";
            this.rdo_center.Size = new System.Drawing.Size(68, 16);
            this.rdo_center.TabIndex = 11;
            this.rdo_center.TabStop = true;
            this.rdo_center.Text = "中央揃え";
            this.rdo_center.UseVisualStyleBackColor = true;
            // 
            // rdo_left
            // 
            this.rdo_left.AutoSize = true;
            this.rdo_left.Location = new System.Drawing.Point(346, 262);
            this.rdo_left.Name = "rdo_left";
            this.rdo_left.Size = new System.Drawing.Size(56, 16);
            this.rdo_left.TabIndex = 12;
            this.rdo_left.TabStop = true;
            this.rdo_left.Text = "左揃え";
            this.rdo_left.UseVisualStyleBackColor = true;
            // 
            // rdo_right
            // 
            this.rdo_right.AutoSize = true;
            this.rdo_right.Location = new System.Drawing.Point(414, 262);
            this.rdo_right.Name = "rdo_right";
            this.rdo_right.Size = new System.Drawing.Size(56, 16);
            this.rdo_right.TabIndex = 13;
            this.rdo_right.TabStop = true;
            this.rdo_right.Text = "右揃え";
            this.rdo_right.UseVisualStyleBackColor = true;
            // 
            // btn_SaveDir
            // 
            this.btn_SaveDir.Location = new System.Drawing.Point(618, 314);
            this.btn_SaveDir.Name = "btn_SaveDir";
            this.btn_SaveDir.Size = new System.Drawing.Size(23, 23);
            this.btn_SaveDir.TabIndex = 16;
            this.btn_SaveDir.Text = "...";
            this.btn_SaveDir.UseVisualStyleBackColor = true;
            this.btn_SaveDir.Click += new System.EventHandler(this.btn_SaveDir_Click);
            // 
            // txtbx_SaveDir
            // 
            this.txtbx_SaveDir.Location = new System.Drawing.Point(269, 316);
            this.txtbx_SaveDir.Name = "txtbx_SaveDir";
            this.txtbx_SaveDir.ReadOnly = true;
            this.txtbx_SaveDir.Size = new System.Drawing.Size(343, 19);
            this.txtbx_SaveDir.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "保存場所";
            // 
            // btn_MakeSample
            // 
            this.btn_MakeSample.Location = new System.Drawing.Point(269, 348);
            this.btn_MakeSample.Name = "btn_MakeSample";
            this.btn_MakeSample.Size = new System.Drawing.Size(115, 23);
            this.btn_MakeSample.TabIndex = 17;
            this.btn_MakeSample.Text = "見本データ作成";
            this.btn_MakeSample.UseVisualStyleBackColor = true;
            this.btn_MakeSample.Click += new System.EventHandler(this.btn_MakeSample_Click);
            // 
            // btn_MakeAll
            // 
            this.btn_MakeAll.Location = new System.Drawing.Point(394, 348);
            this.btn_MakeAll.Name = "btn_MakeAll";
            this.btn_MakeAll.Size = new System.Drawing.Size(102, 23);
            this.btn_MakeAll.TabIndex = 18;
            this.btn_MakeAll.Text = "全データ作成";
            this.btn_MakeAll.UseVisualStyleBackColor = true;
            this.btn_MakeAll.Click += new System.EventHandler(this.btn_MakeAll_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(506, 348);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(90, 23);
            this.btn_reset.TabIndex = 19;
            this.btn_reset.Text = "リセット";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lbl_fontSample
            // 
            this.lbl_fontSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_fontSample.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_fontSample.Location = new System.Drawing.Point(483, 211);
            this.lbl_fontSample.Name = "lbl_fontSample";
            this.lbl_fontSample.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbl_fontSample.Size = new System.Drawing.Size(159, 32);
            this.lbl_fontSample.TabIndex = 20;
            this.lbl_fontSample.Text = "サンプルテキスト";
            this.lbl_fontSample.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "見本データに入れるテキスト";
            // 
            // txtbx_Sampletext
            // 
            this.txtbx_Sampletext.Location = new System.Drawing.Point(272, 166);
            this.txtbx_Sampletext.Name = "txtbx_Sampletext";
            this.txtbx_Sampletext.Size = new System.Drawing.Size(239, 19);
            this.txtbx_Sampletext.TabIndex = 22;
            this.txtbx_Sampletext.Text = "○○○○マンション";
            // 
            // box_excelsheet
            // 
            this.box_excelsheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_excelsheet.Enabled = false;
            this.box_excelsheet.FormattingEnabled = true;
            this.box_excelsheet.Location = new System.Drawing.Point(526, 166);
            this.box_excelsheet.Name = "box_excelsheet";
            this.box_excelsheet.Size = new System.Drawing.Size(116, 20);
            this.box_excelsheet.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(524, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "読み込むシート";
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.colorBox.Location = new System.Drawing.Point(520, 262);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(121, 16);
            this.colorBox.TabIndex = 26;
            this.colorBox.TabStop = false;
            this.colorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(481, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "カラー";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 26);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.エクセルテンプレートを保存ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.終了ToolStripMenuItem});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.メニューToolStripMenuItem.Text = "メニュー";
            // 
            // エクセルテンプレートを保存ToolStripMenuItem
            // 
            this.エクセルテンプレートを保存ToolStripMenuItem.Name = "エクセルテンプレートを保存ToolStripMenuItem";
            this.エクセルテンプレートを保存ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.エクセルテンプレートを保存ToolStripMenuItem.Text = "エクセルテンプレートを出力";
            this.エクセルテンプレートを保存ToolStripMenuItem.Click += new System.EventHandler(this.SaveExcelTemplToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 22);
            this.toolStripMenuItem2.Text = "マニュアルを表示";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ShowManualtoolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 383);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.box_excelsheet);
            this.Controls.Add(this.txtbx_Sampletext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_fontSample);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_MakeAll);
            this.Controls.Add(this.btn_MakeSample);
            this.Controls.Add(this.btn_SaveDir);
            this.Controls.Add(this.txtbx_SaveDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdo_right);
            this.Controls.Add(this.rdo_left);
            this.Controls.Add(this.rdo_center);
            this.Controls.Add(this.box_fontlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.txtbx_Excel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_PDF);
            this.Controls.Add(this.txtbx_PDF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thumbBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D3PDFMaker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbx_PDF;
        private System.Windows.Forms.Button btn_PDF;
        private System.Windows.Forms.Button btn_Excel;
        private System.Windows.Forms.TextBox txtbx_Excel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox box_fontlist;
        private System.Windows.Forms.RadioButton rdo_center;
        private System.Windows.Forms.RadioButton rdo_left;
        private System.Windows.Forms.RadioButton rdo_right;
        private System.Windows.Forms.Button btn_SaveDir;
        private System.Windows.Forms.TextBox txtbx_SaveDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_MakeSample;
        private System.Windows.Forms.Button btn_MakeAll;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_fontSample;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbx_Sampletext;
        private System.Windows.Forms.ComboBox box_excelsheet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem エクセルテンプレートを保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

