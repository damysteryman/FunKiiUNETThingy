namespace FunKiiUNETThingy
{
    partial class frmSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoLoadData = new System.Windows.Forms.CheckBox();
            this.chkAutoUpdateTitlekeys = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSaveResult = new System.Windows.Forms.Label();
            this.chkGroupDownloads = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDirSelect = new System.Windows.Forms.Button();
            this.txtSaveDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkFileDownloadSkip = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkFilesize1024 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAutoLoadData);
            this.groupBox1.Controls.Add(this.chkAutoUpdateTitlekeys);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Settings";
            // 
            // chkAutoLoadData
            // 
            this.chkAutoLoadData.AutoSize = true;
            this.chkAutoLoadData.Location = new System.Drawing.Point(6, 43);
            this.chkAutoLoadData.Name = "chkAutoLoadData";
            this.chkAutoLoadData.Size = new System.Drawing.Size(243, 17);
            this.chkAutoLoadData.TabIndex = 1;
            this.chkAutoLoadData.Text = "Auto-Load TitleKey Data when program starts.";
            this.chkAutoLoadData.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdateTitlekeys
            // 
            this.chkAutoUpdateTitlekeys.AutoSize = true;
            this.chkAutoUpdateTitlekeys.Location = new System.Drawing.Point(6, 20);
            this.chkAutoUpdateTitlekeys.Name = "chkAutoUpdateTitlekeys";
            this.chkAutoUpdateTitlekeys.Size = new System.Drawing.Size(231, 17);
            this.chkAutoUpdateTitlekeys.TabIndex = 0;
            this.chkAutoUpdateTitlekeys.Text = "Auto-Update titlekeys.json on program start.";
            this.chkAutoUpdateTitlekeys.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(69, 385);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(185, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSaveResult
            // 
            this.lblSaveResult.Location = new System.Drawing.Point(12, 355);
            this.lblSaveResult.Name = "lblSaveResult";
            this.lblSaveResult.Size = new System.Drawing.Size(311, 27);
            this.lblSaveResult.TabIndex = 3;
            // 
            // chkGroupDownloads
            // 
            this.chkGroupDownloads.Location = new System.Drawing.Point(6, 43);
            this.chkGroupDownloads.Name = "chkGroupDownloads";
            this.chkGroupDownloads.Size = new System.Drawing.Size(243, 38);
            this.chkGroupDownloads.TabIndex = 2;
            this.chkGroupDownloads.Text = "Group downloads in subfolders based on Name + Region";
            this.chkGroupDownloads.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDirSelect);
            this.groupBox2.Controls.Add(this.txtSaveDir);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chkFileDownloadSkip);
            this.groupBox2.Controls.Add(this.chkGroupDownloads);
            this.groupBox2.Location = new System.Drawing.Point(13, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 213);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download Settings";
            // 
            // btnDirSelect
            // 
            this.btnDirSelect.Location = new System.Drawing.Point(219, 174);
            this.btnDirSelect.Name = "btnDirSelect";
            this.btnDirSelect.Size = new System.Drawing.Size(75, 23);
            this.btnDirSelect.TabIndex = 6;
            this.btnDirSelect.Text = "Select Dir";
            this.btnDirSelect.UseVisualStyleBackColor = true;
            this.btnDirSelect.Click += new System.EventHandler(this.btnDirSelect_Click);
            // 
            // txtSaveDir
            // 
            this.txtSaveDir.Location = new System.Drawing.Point(6, 176);
            this.txtSaveDir.Name = "txtSaveDir";
            this.txtSaveDir.Size = new System.Drawing.Size(207, 20);
            this.txtSaveDir.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Downloads Directory:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 78);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Example:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "-> \\Game-Title (REG) [GAME-DLC] [ID_CODE}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "-> \\Game-Title (REG) [GAME-UPDATE] [ID_CODE]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "-> \\Game-Title (REG) [GAME] [ID_CODE]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "install\\Game-Title (REG)";
            // 
            // chkFileDownloadSkip
            // 
            this.chkFileDownloadSkip.AutoSize = true;
            this.chkFileDownloadSkip.Location = new System.Drawing.Point(6, 20);
            this.chkFileDownloadSkip.Name = "chkFileDownloadSkip";
            this.chkFileDownloadSkip.Size = new System.Drawing.Size(247, 17);
            this.chkFileDownloadSkip.TabIndex = 0;
            this.chkFileDownloadSkip.Text = "Skip download of already existing Content files.";
            this.chkFileDownloadSkip.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkFilesize1024);
            this.groupBox4.Location = new System.Drawing.Point(13, 293);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 59);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cosmetic Settings";
            // 
            // chkFilesize1024
            // 
            this.chkFilesize1024.Location = new System.Drawing.Point(4, 14);
            this.chkFilesize1024.Name = "chkFilesize1024";
            this.chkFilesize1024.Size = new System.Drawing.Size(268, 39);
            this.chkFilesize1024.TabIndex = 0;
            this.chkFilesize1024.Text = "Display Filesizes using base-2 instead of base-10 (1024 vs 1000)";
            this.chkFilesize1024.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 420);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblSaveResult);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoLoadData;
        private System.Windows.Forms.CheckBox chkAutoUpdateTitlekeys;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSaveResult;
        private System.Windows.Forms.CheckBox chkGroupDownloads;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFileDownloadSkip;
        private System.Windows.Forms.Button btnDirSelect;
        private System.Windows.Forms.TextBox txtSaveDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkFilesize1024;
    }
}