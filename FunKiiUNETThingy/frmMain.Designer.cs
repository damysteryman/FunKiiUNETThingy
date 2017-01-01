namespace FunKiiUNETThingy
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
            this.components = new System.ComponentModel.Container();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblKeySiteUrl = new System.Windows.Forms.Label();
            this.txtKeySiteUrl = new System.Windows.Forms.TextBox();
            this.dgvTitles = new System.Windows.Forms.DataGridView();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lbxTitleQueue = new System.Windows.Forms.ListBox();
            this.chkGame = new System.Windows.Forms.CheckBox();
            this.chkGameUpdate = new System.Windows.Forms.CheckBox();
            this.chkGameDlc = new System.Windows.Forms.CheckBox();
            this.chkDemo = new System.Windows.Forms.CheckBox();
            this.chkSysApp = new System.Windows.Forms.CheckBox();
            this.chkSysData = new System.Windows.Forms.CheckBox();
            this.chkBackTitle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRegUnk = new System.Windows.Forms.CheckBox();
            this.chkRegTwn = new System.Windows.Forms.CheckBox();
            this.chkRegKor = new System.Windows.Forms.CheckBox();
            this.chkRegChn = new System.Windows.Forms.CheckBox();
            this.chkRegEur = new System.Windows.Forms.CheckBox();
            this.chkRegUsa = new System.Windows.Forms.CheckBox();
            this.chkRegJpn = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkDemoTimeLimit = new System.Windows.Forms.CheckBox();
            this.chkDlcUnlock = new System.Windows.Forms.CheckBox();
            this.btnTitleKeyFileDownload = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbrFileDownload = new System.Windows.Forms.ProgressBar();
            this.lblProgressData = new System.Windows.Forms.Label();
            this.lblProgressContent = new System.Windows.Forms.Label();
            this.cmsTitleQueue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.lblProgressTitle = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblTitleTotalSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lblManualNameError = new System.Windows.Forms.Label();
            this.lblManualTitleIDError = new System.Windows.Forms.Label();
            this.lblManualTitleKeyError = new System.Windows.Forms.Label();
            this.btnManualAdd = new System.Windows.Forms.Button();
            this.txtManualName = new System.Windows.Forms.TextBox();
            this.cboManualRegion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtManualID = new System.Windows.Forms.TextBox();
            this.txtManualTitleKey = new System.Windows.Forms.TextBox();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.pbxPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmsTitleQueue.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(103, 59);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(79, 89);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load/Reload Data from titlekeys.json";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblKeySiteUrl
            // 
            this.lblKeySiteUrl.AutoSize = true;
            this.lblKeySiteUrl.Location = new System.Drawing.Point(6, 16);
            this.lblKeySiteUrl.Name = "lblKeySiteUrl";
            this.lblKeySiteUrl.Size = new System.Drawing.Size(109, 13);
            this.lblKeySiteUrl.TabIndex = 1;
            this.lblKeySiteUrl.Text = "\"That Key Site\" URL:";
            // 
            // txtKeySiteUrl
            // 
            this.txtKeySiteUrl.Location = new System.Drawing.Point(7, 33);
            this.txtKeySiteUrl.Name = "txtKeySiteUrl";
            this.txtKeySiteUrl.Size = new System.Drawing.Size(175, 20);
            this.txtKeySiteUrl.TabIndex = 2;
            // 
            // dgvTitles
            // 
            this.dgvTitles.AllowUserToAddRows = false;
            this.dgvTitles.AllowUserToDeleteRows = false;
            this.dgvTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitles.Location = new System.Drawing.Point(10, 193);
            this.dgvTitles.MultiSelect = false;
            this.dgvTitles.Name = "dgvTitles";
            this.dgvTitles.ReadOnly = true;
            this.dgvTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTitles.Size = new System.Drawing.Size(745, 387);
            this.dgvTitles.TabIndex = 4;
            this.dgvTitles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTitles_CellDoubleClick);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(6, 355);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(272, 26);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "DOWNLOAD!";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lbxTitleQueue
            // 
            this.lbxTitleQueue.FormattingEnabled = true;
            this.lbxTitleQueue.Location = new System.Drawing.Point(6, 19);
            this.lbxTitleQueue.Name = "lbxTitleQueue";
            this.lbxTitleQueue.Size = new System.Drawing.Size(272, 329);
            this.lbxTitleQueue.TabIndex = 6;
            // 
            // chkGame
            // 
            this.chkGame.AutoSize = true;
            this.chkGame.Location = new System.Drawing.Point(6, 19);
            this.chkGame.Name = "chkGame";
            this.chkGame.Size = new System.Drawing.Size(57, 17);
            this.chkGame.TabIndex = 8;
            this.chkGame.Text = "GAME";
            this.chkGame.UseVisualStyleBackColor = true;
            this.chkGame.CheckedChanged += new System.EventHandler(this.chkGame_CheckedChanged);
            // 
            // chkGameUpdate
            // 
            this.chkGameUpdate.AutoSize = true;
            this.chkGameUpdate.Location = new System.Drawing.Point(6, 51);
            this.chkGameUpdate.Name = "chkGameUpdate";
            this.chkGameUpdate.Size = new System.Drawing.Size(104, 17);
            this.chkGameUpdate.TabIndex = 9;
            this.chkGameUpdate.Text = "GAME-UPDATE";
            this.chkGameUpdate.UseVisualStyleBackColor = true;
            this.chkGameUpdate.CheckedChanged += new System.EventHandler(this.ChkGameUpdate_CheckedChanged);
            // 
            // chkGameDlc
            // 
            this.chkGameDlc.AutoSize = true;
            this.chkGameDlc.Location = new System.Drawing.Point(6, 67);
            this.chkGameDlc.Name = "chkGameDlc";
            this.chkGameDlc.Size = new System.Drawing.Size(81, 17);
            this.chkGameDlc.TabIndex = 10;
            this.chkGameDlc.Text = "GAME-DLC";
            this.chkGameDlc.UseVisualStyleBackColor = true;
            this.chkGameDlc.CheckedChanged += new System.EventHandler(this.chkGameDlc_CheckedChanged);
            // 
            // chkDemo
            // 
            this.chkDemo.AutoSize = true;
            this.chkDemo.Location = new System.Drawing.Point(6, 35);
            this.chkDemo.Name = "chkDemo";
            this.chkDemo.Size = new System.Drawing.Size(58, 17);
            this.chkDemo.TabIndex = 11;
            this.chkDemo.Text = "DEMO";
            this.chkDemo.UseVisualStyleBackColor = true;
            this.chkDemo.CheckedChanged += new System.EventHandler(this.chkDemo_CheckedChanged);
            // 
            // chkSysApp
            // 
            this.chkSysApp.AutoSize = true;
            this.chkSysApp.Location = new System.Drawing.Point(112, 19);
            this.chkSysApp.Name = "chkSysApp";
            this.chkSysApp.Size = new System.Drawing.Size(94, 17);
            this.chkSysApp.TabIndex = 12;
            this.chkSysApp.Text = "SYSTEM-APP";
            this.chkSysApp.UseVisualStyleBackColor = false;
            this.chkSysApp.CheckedChanged += new System.EventHandler(this.chkSysApp_CheckedChanged);
            // 
            // chkSysData
            // 
            this.chkSysData.AutoSize = true;
            this.chkSysData.Location = new System.Drawing.Point(112, 35);
            this.chkSysData.Name = "chkSysData";
            this.chkSysData.Size = new System.Drawing.Size(102, 17);
            this.chkSysData.TabIndex = 13;
            this.chkSysData.Text = "SYSTEM-DATA";
            this.chkSysData.UseVisualStyleBackColor = true;
            this.chkSysData.CheckedChanged += new System.EventHandler(this.chkSysData_CheckedChanged);
            // 
            // chkBackTitle
            // 
            this.chkBackTitle.AutoSize = true;
            this.chkBackTitle.Location = new System.Drawing.Point(112, 51);
            this.chkBackTitle.Name = "chkBackTitle";
            this.chkBackTitle.Size = new System.Drawing.Size(135, 17);
            this.chkBackTitle.TabIndex = 14;
            this.chkBackTitle.Text = "BACKGROUND-TITLE";
            this.chkBackTitle.UseVisualStyleBackColor = true;
            this.chkBackTitle.CheckedChanged += new System.EventHandler(this.chkBackTitle_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkGame);
            this.groupBox1.Controls.Add(this.chkBackTitle);
            this.groupBox1.Controls.Add(this.chkGameUpdate);
            this.groupBox1.Controls.Add(this.chkSysData);
            this.groupBox1.Controls.Add(this.chkGameDlc);
            this.groupBox1.Controls.Add(this.chkSysApp);
            this.groupBox1.Controls.Add(this.chkDemo);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 89);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Title Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRegUnk);
            this.groupBox2.Controls.Add(this.chkRegTwn);
            this.groupBox2.Controls.Add(this.chkRegKor);
            this.groupBox2.Controls.Add(this.chkRegChn);
            this.groupBox2.Controls.Add(this.chkRegEur);
            this.groupBox2.Controls.Add(this.chkRegUsa);
            this.groupBox2.Controls.Add(this.chkRegJpn);
            this.groupBox2.Location = new System.Drawing.Point(259, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 89);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Title Region";
            // 
            // chkRegUnk
            // 
            this.chkRegUnk.AutoSize = true;
            this.chkRegUnk.Location = new System.Drawing.Point(6, 66);
            this.chkRegUnk.Name = "chkRegUnk";
            this.chkRegUnk.Size = new System.Drawing.Size(72, 17);
            this.chkRegUnk.TabIndex = 6;
            this.chkRegUnk.Text = "Unknown";
            this.chkRegUnk.UseVisualStyleBackColor = true;
            this.chkRegUnk.CheckedChanged += new System.EventHandler(this.chkRegUnk_CheckedChanged);
            // 
            // chkRegTwn
            // 
            this.chkRegTwn.AutoSize = true;
            this.chkRegTwn.Location = new System.Drawing.Point(58, 51);
            this.chkRegTwn.Name = "chkRegTwn";
            this.chkRegTwn.Size = new System.Drawing.Size(52, 17);
            this.chkRegTwn.TabIndex = 5;
            this.chkRegTwn.Text = "TWN";
            this.chkRegTwn.UseVisualStyleBackColor = true;
            this.chkRegTwn.CheckedChanged += new System.EventHandler(this.chkRegTwn_CheckedChanged);
            // 
            // chkRegKor
            // 
            this.chkRegKor.AutoSize = true;
            this.chkRegKor.Location = new System.Drawing.Point(58, 35);
            this.chkRegKor.Name = "chkRegKor";
            this.chkRegKor.Size = new System.Drawing.Size(49, 17);
            this.chkRegKor.TabIndex = 4;
            this.chkRegKor.Text = "KOR";
            this.chkRegKor.UseVisualStyleBackColor = true;
            this.chkRegKor.CheckedChanged += new System.EventHandler(this.chkRegKor_CheckedChanged);
            // 
            // chkRegChn
            // 
            this.chkRegChn.AutoSize = true;
            this.chkRegChn.Location = new System.Drawing.Point(58, 19);
            this.chkRegChn.Name = "chkRegChn";
            this.chkRegChn.Size = new System.Drawing.Size(49, 17);
            this.chkRegChn.TabIndex = 3;
            this.chkRegChn.Text = "CHN";
            this.chkRegChn.UseVisualStyleBackColor = true;
            this.chkRegChn.CheckedChanged += new System.EventHandler(this.chkRegChn_CheckedChanged);
            // 
            // chkRegEur
            // 
            this.chkRegEur.AutoSize = true;
            this.chkRegEur.Location = new System.Drawing.Point(6, 51);
            this.chkRegEur.Name = "chkRegEur";
            this.chkRegEur.Size = new System.Drawing.Size(49, 17);
            this.chkRegEur.TabIndex = 2;
            this.chkRegEur.Text = "EUR";
            this.chkRegEur.UseVisualStyleBackColor = true;
            this.chkRegEur.CheckedChanged += new System.EventHandler(this.chkRegEur_CheckedChanged);
            // 
            // chkRegUsa
            // 
            this.chkRegUsa.AutoSize = true;
            this.chkRegUsa.Location = new System.Drawing.Point(6, 35);
            this.chkRegUsa.Name = "chkRegUsa";
            this.chkRegUsa.Size = new System.Drawing.Size(48, 17);
            this.chkRegUsa.TabIndex = 1;
            this.chkRegUsa.Text = "USA";
            this.chkRegUsa.UseVisualStyleBackColor = true;
            this.chkRegUsa.CheckedChanged += new System.EventHandler(this.chkRegUsa_CheckedChanged);
            // 
            // chkRegJpn
            // 
            this.chkRegJpn.AutoSize = true;
            this.chkRegJpn.Location = new System.Drawing.Point(6, 19);
            this.chkRegJpn.Name = "chkRegJpn";
            this.chkRegJpn.Size = new System.Drawing.Size(46, 17);
            this.chkRegJpn.TabIndex = 0;
            this.chkRegJpn.Text = "JPN";
            this.chkRegJpn.UseVisualStyleBackColor = true;
            this.chkRegJpn.CheckedChanged += new System.EventHandler(this.chkRegJpn_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 20);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(277, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkDemoTimeLimit
            // 
            this.chkDemoTimeLimit.AutoSize = true;
            this.chkDemoTimeLimit.Location = new System.Drawing.Point(6, 16);
            this.chkDemoTimeLimit.Name = "chkDemoTimeLimit";
            this.chkDemoTimeLimit.Size = new System.Drawing.Size(162, 17);
            this.chkDemoTimeLimit.TabIndex = 19;
            this.chkDemoTimeLimit.Text = "DEMO - Remove Time Limits";
            this.chkDemoTimeLimit.UseVisualStyleBackColor = true;
            // 
            // chkDlcUnlock
            // 
            this.chkDlcUnlock.AutoSize = true;
            this.chkDlcUnlock.Location = new System.Drawing.Point(6, 32);
            this.chkDlcUnlock.Name = "chkDlcUnlock";
            this.chkDlcUnlock.Size = new System.Drawing.Size(144, 17);
            this.chkDlcUnlock.TabIndex = 20;
            this.chkDlcUnlock.Text = "DLC - Unlock All Content";
            this.chkDlcUnlock.UseVisualStyleBackColor = true;
            // 
            // btnTitleKeyFileDownload
            // 
            this.btnTitleKeyFileDownload.Location = new System.Drawing.Point(7, 59);
            this.btnTitleKeyFileDownload.Name = "btnTitleKeyFileDownload";
            this.btnTitleKeyFileDownload.Size = new System.Drawing.Size(79, 89);
            this.btnTitleKeyFileDownload.TabIndex = 21;
            this.btnTitleKeyFileDownload.Text = "Download / Update titlekeys.json file";
            this.btnTitleKeyFileDownload.UseVisualStyleBackColor = true;
            this.btnTitleKeyFileDownload.Click += new System.EventHandler(this.btnTitleKeyFileDownload_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkDemoTimeLimit);
            this.groupBox3.Controls.Add(this.chkDlcUnlock);
            this.groupBox3.Location = new System.Drawing.Point(591, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 54);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extra Patches";
            // 
            // pbrFileDownload
            // 
            this.pbrFileDownload.Location = new System.Drawing.Point(6, 127);
            this.pbrFileDownload.Name = "pbrFileDownload";
            this.pbrFileDownload.Size = new System.Drawing.Size(505, 23);
            this.pbrFileDownload.TabIndex = 23;
            // 
            // lblProgressData
            // 
            this.lblProgressData.AutoSize = true;
            this.lblProgressData.Location = new System.Drawing.Point(7, 111);
            this.lblProgressData.Name = "lblProgressData";
            this.lblProgressData.Size = new System.Drawing.Size(0, 13);
            this.lblProgressData.TabIndex = 24;
            // 
            // lblProgressContent
            // 
            this.lblProgressContent.AutoSize = true;
            this.lblProgressContent.Location = new System.Drawing.Point(7, 98);
            this.lblProgressContent.Name = "lblProgressContent";
            this.lblProgressContent.Size = new System.Drawing.Size(0, 13);
            this.lblProgressContent.TabIndex = 25;
            // 
            // cmsTitleQueue
            // 
            this.cmsTitleQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemove});
            this.cmsTitleQueue.Name = "cmsTitleQueue";
            this.cmsTitleQueue.Size = new System.Drawing.Size(185, 26);
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(184, 22);
            this.tsmiRemove.Text = "Remove from Queue";
            this.tsmiRemove.Click += new System.EventHandler(this.tsmiRemove_Click);
            // 
            // lblProgressTitle
            // 
            this.lblProgressTitle.AutoSize = true;
            this.lblProgressTitle.Location = new System.Drawing.Point(7, 46);
            this.lblProgressTitle.Name = "lblProgressTitle";
            this.lblProgressTitle.Size = new System.Drawing.Size(70, 13);
            this.lblProgressTitle.TabIndex = 27;
            this.lblProgressTitle.Text = "Nothing ATM";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(502, 134);
            this.txtLog.TabIndex = 28;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSearch);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Location = new System.Drawing.Point(7, 109);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(363, 40);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblKeySiteUrl);
            this.groupBox5.Controls.Add(this.btnLoad);
            this.groupBox5.Controls.Add(this.txtKeySiteUrl);
            this.groupBox5.Controls.Add(this.btnTitleKeyFileDownload);
            this.groupBox5.Location = new System.Drawing.Point(10, 29);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(190, 158);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TitleKey Options";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox2);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.groupBox1);
            this.groupBox6.Location = new System.Drawing.Point(206, 29);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(379, 158);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Title Selection Options";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtLog);
            this.groupBox7.Location = new System.Drawing.Point(10, 580);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(517, 156);
            this.groupBox7.TabIndex = 32;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Log";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblTitleTotalSize);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.pbrFileDownload);
            this.groupBox8.Controls.Add(this.lblProgressData);
            this.groupBox8.Controls.Add(this.lblProgressContent);
            this.groupBox8.Controls.Add(this.lblProgressTitle);
            this.groupBox8.Location = new System.Drawing.Point(528, 580);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(517, 156);
            this.groupBox8.TabIndex = 33;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Doownload Progress";
            // 
            // lblTitleTotalSize
            // 
            this.lblTitleTotalSize.AutoSize = true;
            this.lblTitleTotalSize.Location = new System.Drawing.Point(7, 59);
            this.lblTitleTotalSize.Name = "lblTitleTotalSize";
            this.lblTitleTotalSize.Size = new System.Drawing.Size(0, 13);
            this.lblTitleTotalSize.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Currently Downloading Title:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lbxTitleQueue);
            this.groupBox9.Controls.Add(this.btnDownload);
            this.groupBox9.Location = new System.Drawing.Point(761, 193);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(284, 387);
            this.groupBox9.TabIndex = 34;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Title Queue";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1053, 24);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "TitleKey:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "TitleID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Name:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lblManualNameError);
            this.groupBox10.Controls.Add(this.lblManualTitleIDError);
            this.groupBox10.Controls.Add(this.lblManualTitleKeyError);
            this.groupBox10.Controls.Add(this.btnManualAdd);
            this.groupBox10.Controls.Add(this.txtManualName);
            this.groupBox10.Controls.Add(this.cboManualRegion);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.txtManualID);
            this.groupBox10.Controls.Add(this.txtManualTitleKey);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.label4);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Location = new System.Drawing.Point(590, 84);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(451, 103);
            this.groupBox10.TabIndex = 47;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Manual Title Add";
            // 
            // lblManualNameError
            // 
            this.lblManualNameError.AutoSize = true;
            this.lblManualNameError.Location = new System.Drawing.Point(263, 19);
            this.lblManualNameError.Name = "lblManualNameError";
            this.lblManualNameError.Size = new System.Drawing.Size(0, 13);
            this.lblManualNameError.TabIndex = 55;
            // 
            // lblManualTitleIDError
            // 
            this.lblManualTitleIDError.AutoSize = true;
            this.lblManualTitleIDError.Location = new System.Drawing.Point(54, 57);
            this.lblManualTitleIDError.Name = "lblManualTitleIDError";
            this.lblManualTitleIDError.Size = new System.Drawing.Size(0, 13);
            this.lblManualTitleIDError.TabIndex = 54;
            // 
            // lblManualTitleKeyError
            // 
            this.lblManualTitleKeyError.AutoSize = true;
            this.lblManualTitleKeyError.Location = new System.Drawing.Point(54, 19);
            this.lblManualTitleKeyError.Name = "lblManualTitleKeyError";
            this.lblManualTitleKeyError.Size = new System.Drawing.Size(0, 13);
            this.lblManualTitleKeyError.TabIndex = 53;
            // 
            // btnManualAdd
            // 
            this.btnManualAdd.Location = new System.Drawing.Point(306, 72);
            this.btnManualAdd.Name = "btnManualAdd";
            this.btnManualAdd.Size = new System.Drawing.Size(136, 23);
            this.btnManualAdd.TabIndex = 52;
            this.btnManualAdd.Text = "Add to Download Queue";
            this.btnManualAdd.UseVisualStyleBackColor = true;
            this.btnManualAdd.Click += new System.EventHandler(this.btnManualAdd_Click);
            // 
            // txtManualName
            // 
            this.txtManualName.Location = new System.Drawing.Point(222, 34);
            this.txtManualName.Name = "txtManualName";
            this.txtManualName.Size = new System.Drawing.Size(220, 20);
            this.txtManualName.TabIndex = 51;
            // 
            // cboManualRegion
            // 
            this.cboManualRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualRegion.FormattingEnabled = true;
            this.cboManualRegion.Location = new System.Drawing.Point(200, 73);
            this.cboManualRegion.Name = "cboManualRegion";
            this.cboManualRegion.Size = new System.Drawing.Size(95, 21);
            this.cboManualRegion.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Region:";
            // 
            // txtManualID
            // 
            this.txtManualID.Location = new System.Drawing.Point(7, 74);
            this.txtManualID.Name = "txtManualID";
            this.txtManualID.Size = new System.Drawing.Size(127, 20);
            this.txtManualID.TabIndex = 48;
            // 
            // txtManualTitleKey
            // 
            this.txtManualTitleKey.Location = new System.Drawing.Point(7, 34);
            this.txtManualTitleKey.Name = "txtManualTitleKey";
            this.txtManualTitleKey.Size = new System.Drawing.Size(209, 20);
            this.txtManualTitleKey.TabIndex = 47;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Location = new System.Drawing.Point(893, 29);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(81, 13);
            this.lblAppTitle.TabIndex = 48;
            this.lblAppTitle.Text = "AppTitleVersion";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(893, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 26);
            this.label6.TabIndex = 49;
            this.label6.Text = "\"Dev-PEBCAK Error\" Edition";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(893, 68);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(37, 13);
            this.lblAuthor.TabIndex = 50;
            this.lblAuthor.Text = "author";
            // 
            // pbxPicture
            // 
            this.pbxPicture.Location = new System.Drawing.Point(823, 25);
            this.pbxPicture.Name = "pbxPicture";
            this.pbxPicture.Size = new System.Drawing.Size(64, 64);
            this.pbxPicture.TabIndex = 51;
            this.pbxPicture.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 745);
            this.Controls.Add(this.pbxPicture);
            this.Controls.Add(this.lblAppTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvTitles);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "FunKiiUNETThingy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cmsTitleQueue.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblKeySiteUrl;
        private System.Windows.Forms.TextBox txtKeySiteUrl;
        private System.Windows.Forms.DataGridView dgvTitles;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListBox lbxTitleQueue;
        private System.Windows.Forms.CheckBox chkGame;
        private System.Windows.Forms.CheckBox chkGameUpdate;
        private System.Windows.Forms.CheckBox chkGameDlc;
        private System.Windows.Forms.CheckBox chkDemo;
        private System.Windows.Forms.CheckBox chkSysApp;
        private System.Windows.Forms.CheckBox chkSysData;
        private System.Windows.Forms.CheckBox chkBackTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkRegEur;
        private System.Windows.Forms.CheckBox chkRegUsa;
        private System.Windows.Forms.CheckBox chkRegJpn;
        private System.Windows.Forms.CheckBox chkRegTwn;
        private System.Windows.Forms.CheckBox chkRegKor;
        private System.Windows.Forms.CheckBox chkRegChn;
        private System.Windows.Forms.CheckBox chkRegUnk;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkDemoTimeLimit;
        private System.Windows.Forms.CheckBox chkDlcUnlock;
        private System.Windows.Forms.Button btnTitleKeyFileDownload;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar pbrFileDownload;
        private System.Windows.Forms.Label lblProgressData;
        private System.Windows.Forms.Label lblProgressContent;
        private System.Windows.Forms.ContextMenuStrip cmsTitleQueue;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemove;
        private System.Windows.Forms.Label lblProgressTitle;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitleTotalSize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cboManualRegion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtManualID;
        private System.Windows.Forms.TextBox txtManualTitleKey;
        private System.Windows.Forms.TextBox txtManualName;
        private System.Windows.Forms.Button btnManualAdd;
        private System.Windows.Forms.Label lblManualTitleKeyError;
        private System.Windows.Forms.Label lblManualTitleIDError;
        private System.Windows.Forms.Label lblManualNameError;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAuthor;
        protected System.Windows.Forms.PictureBox pbxPicture;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

