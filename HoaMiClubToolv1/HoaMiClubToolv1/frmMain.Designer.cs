namespace HoaMiClubToolv1
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mntSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCoppy = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.txtOu = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lstErr = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtstt = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.txtPrg = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntSetting,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mntSetting
            // 
            this.mntSetting.Name = "mntSetting";
            this.mntSetting.Size = new System.Drawing.Size(65, 20);
            this.mntSetting.Text = "Thiết lập";
            this.mntSetting.Click += new System.EventHandler(this.mntSetting_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHelp,
            this.btnAbout});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // btnHelp
            // 
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(180, 22);
            this.btnHelp.Text = "Hướng dẫn sử dụng";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(180, 22);
            this.btnAbout.Text = "Giới thiệu";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnSetting);
            this.groupBox1.Controls.Add(this.btnSort);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 515);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(181, 439);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(122, 70);
            this.btnSetting.TabIndex = 6;
            this.btnSetting.Text = "Thiết lập";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSort.Location = new System.Drawing.Point(9, 438);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(122, 70);
            this.btnSort.TabIndex = 5;
            this.btnSort.Text = "Sắp xếp theo abc";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(6, 32);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(327, 400);
            this.txtInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dán danh sách các bài hát cần lấy lời tại đây";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCoppy);
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Controls.Add(this.txtOu);
            this.groupBox2.Location = new System.Drawing.Point(585, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 515);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnCoppy
            // 
            this.btnCoppy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCoppy.Location = new System.Drawing.Point(113, 438);
            this.btnCoppy.Name = "btnCoppy";
            this.btnCoppy.Size = new System.Drawing.Size(122, 70);
            this.btnCoppy.TabIndex = 7;
            this.btnCoppy.Text = "Coppy All";
            this.btnCoppy.UseVisualStyleBackColor = true;
            this.btnCoppy.Click += new System.EventHandler(this.btnCoppy_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(9, 32);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(324, 400);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            // 
            // txtOu
            // 
            this.txtOu.AutoSize = true;
            this.txtOu.Location = new System.Drawing.Point(6, 16);
            this.txtOu.Name = "txtOu";
            this.txtOu.Size = new System.Drawing.Size(128, 13);
            this.txtOu.TabIndex = 0;
            this.txtOu.Text = "Đã tìm thấy lời 0/0 bài hát";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(59, 74);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 70);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Bắt đầu =>";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lstErr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(357, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 509);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "hoặc nghi ngờ lấy lời sai";
            // 
            // lstErr
            // 
            this.lstErr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstErr.Location = new System.Drawing.Point(8, 206);
            this.lstErr.MultiSelect = false;
            this.lstErr.Name = "lstErr";
            this.lstErr.Size = new System.Drawing.Size(214, 268);
            this.lstErr.TabIndex = 9;
            this.lstErr.UseCompatibleStateImageBehavior = false;
            this.lstErr.View = System.Windows.Forms.View.List;
            this.lstErr.Click += new System.EventHandler(this.lstErr_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Danh sách các bài hát lỗi/ chưa lấy lời được";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtstt,
            this.prgBar,
            this.txtPrg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(936, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtstt
            // 
            this.txtstt.Name = "txtstt";
            this.txtstt.Size = new System.Drawing.Size(128, 17);
            this.txtstt.Text = "Đã lấy được 0/0 bài hát";
            this.txtstt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // prgBar
            // 
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(100, 16);
            // 
            // txtPrg
            // 
            this.txtPrg.Name = "txtPrg";
            this.txtPrg.Size = new System.Drawing.Size(73, 17);
            this.txtPrg.Text = "Hoàn thành!";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 585);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(952, 624);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool getLyric lấy lời bài hát -Họa Mi club v1.0";
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mntSetting;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtOu;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCoppy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lstErr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtstt;
        private System.Windows.Forms.ToolStripProgressBar prgBar;
        private System.Windows.Forms.ToolStripStatusLabel txtPrg;
        private System.Windows.Forms.Label label2;
    }
}

