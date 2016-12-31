using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.Threading;

namespace FunKiiUNETThingy
{
    public partial class frmMain : Form
    {
        #region globals

        public const string TYPE_GAME = "GAME";
        public const string TYPE_DEMO = "DEMO";
        public const string TYPE_UPDATE = "GAME-UPDATE";
        public const string TYPE_DLC = "GAME-DLC";
        public const string TYPE_SYSAPP = "SYSTEM-APP";
        public const string TYPE_SYSDATA = "SYSTEM-DATA";
        public const string TYPE_BACKGROUND = "BACKGROUND-TITLE";

        public const string REG_JPN = "JPN";
        public const string REG_USA = "USA";
        public const string REG_EUR = "EUR";
        public const string REG_CHN = "CHN";
        public const string REG_KOR = "KOR";
        public const string REG_TWN = "TWN";
        public const string REG_UNK = "UNK";

        Config config = new Config();
        List<TitleData> titles = null;
        bool queueIsProcessing = false;
        Thread dlQueueThread;

        public const string NINTYCDN_BASEURL = "http://ccs.cdn.c.shop.nintendowifi.net/ccs/download/";

        #endregion globals

        #region delegates

        private delegate void RemoveFirstTitleFromQueueCallBack();
        private delegate void UpdateProgressContentCallBack(string line);
        private delegate void UpdateProgressTitleCallBack(string line);
        private delegate void UpdateProgressDataCallBack(string line);
        private delegate void UpdateTitleTotalSizeCallBack(string line);
        private delegate void WriteToLogCallBack(string line);
        private delegate void EnableDisableDlButtonCallBack(bool enabled);

        #endregion delegates

        #region init

        public frmMain()
        {
            InitializeComponent();
            this.Icon = FunKiiUNETThingy.Properties.Resources.FunKiiUNETThingy;
            this.lblAppTitle.Text = String.Format("{0} v{1}", Application.ProductName, Application.ProductVersion);
            this.lblAuthor.Text = String.Format("By {0}", Application.CompanyName);
            this.pbxPicture.Image = new Bitmap(FunKiiUNETThingy.Properties.Resources.FunKiiUNETThingyPNG, 64, 64);
            this.Text = String.Format("{0} v{1} By {2}", Application.ProductName, Application.ProductVersion, Application.CompanyName);

            this.cboManualRegion.Items.Add(REG_JPN);
            this.cboManualRegion.Items.Add(REG_USA);
            this.cboManualRegion.Items.Add(REG_EUR);
            this.cboManualRegion.Items.Add(REG_CHN);
            this.cboManualRegion.Items.Add(REG_KOR);
            this.cboManualRegion.Items.Add(REG_TWN);
            this.cboManualRegion.Items.Add(REG_UNK);
            this.cboManualRegion.SelectedItem = REG_UNK;
        }

        #endregion init

        #region events

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbxTitleQueue.MouseDown += lbxTitleQueue_MouseDown;
            WriteToLog("FunKiiUNETThingy Loaded!" + Environment.NewLine);
            //WriteToLog("Titles will be saved in " + Environment.CurrentDirectory + "\\install\\" + Environment.NewLine);
            

            try
            {
                config = new Config(Environment.CurrentDirectory + "\\config.json");
                WriteToLog("config.json loaded!");
            }
            catch (Exception ex)
            {
                WriteToLog("WARNING! Can't access config.json, using default config instead." + Environment.NewLine + ex.Message);
                config = new Config();
            }

            WriteToLog("Titles will be saved in " + config.saveDir + Environment.NewLine);
            

            txtKeySiteUrl.Text = CheckUrlPrefix(config.keysite);

            dgvTitles.Columns.Add("TitleType", "Type");
            dgvTitles.Columns["TitleType"].MinimumWidth = 120;

            dgvTitles.Columns["TitleType"].Visible = false;

            chkGame.Checked = config.titleGame;
            chkDemo.Checked = config.titleDemo;
            chkGameDlc.Checked = config.titleGameDlc;
            chkGameUpdate.Checked = config.titleGameUpdate;
            chkSysApp.Checked = config.titleSysApp;
            chkSysData.Checked = config.titleSysData;
            chkBackTitle.Checked = config.titleBackTitle;

            chkRegJpn.Checked = config.regJpn;
            chkRegUsa.Checked = config.regUsa;
            chkRegEur.Checked = config.regEur;
            chkRegChn.Checked = config.regChn;
            chkRegKor.Checked = config.regKor;
            chkRegTwn.Checked = config.regTwn;
            chkRegUnk.Checked = config.regUnk;

            chkDemoTimeLimit.Checked = config.patchDemoTimeLimit;
            chkDlcUnlock.Checked = config.patchDlcUnlock;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadTitleData();
        }

        private void btnTitleKeyFileDownload_Click(object sender, EventArgs e)
        {
            if (!(txtKeySiteUrl.Text == null || txtKeySiteUrl.Text == ""))
                UpdateTitlekeysFile(txtKeySiteUrl.Text + "/json");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lbxTitleQueue.Items.Count > 0)
            {
                dlQueueThread = new Thread(() =>
                {
                    queueIsProcessing = true;
                    btnDownload.Invoke(new EnableDisableDlButtonCallBack(this.EnableDisableDlButton), new object[] { false });
                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "QUEUE STARTED!" });

                    while (lbxTitleQueue.Items.Count > 0)
                    {
                        DownloadTitle(((KeyValuePair<TitleData, string>)lbxTitleQueue.Items[0]).Key);
                        lbxTitleQueue.Invoke(new RemoveFirstTitleFromQueueCallBack(this.RemoveFirstTitleFromQueue));
                    }

                    queueIsProcessing = false;
                    btnDownload.Invoke(new EnableDisableDlButtonCallBack(this.EnableDisableDlButton), new object[] { true });
                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "QUEUE COMPLETE!" + Environment.NewLine });

                    lblProgressTitle.Invoke(new UpdateProgressTitleCallBack(this.UpdateProgressTitle), new object[] { "Nothing ATM" });
                    lblTitleTotalSize.Invoke(new UpdateTitleTotalSizeCallBack(this.UpdateTitleTotalSize), new object[] { "" });
                    lblProgressContent.Invoke(new UpdateProgressContentCallBack(this.UpdateProgressContent), new object[] { "" });
                    lblProgressData.Invoke(new UpdateProgressDataCallBack(this.UpdateProgressData), new object[] { "" });

                });
                dlQueueThread.IsBackground = true;
                dlQueueThread.Start();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                pbrFileDownload.Value = 0;
            });

        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker) delegate
                {
                    pbrFileDownload.Value = e.ProgressPercentage;
                    lblProgressData.Text = String.Format("Downloaded {0:n0} / {1:n0} bytes ( {3} / {4} ) - {2}%", e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage, ((double)e.BytesReceived).ConvertByteToText(config.appFilesize1024), ((double)e.TotalBytesToReceive).ConvertByteToText(config.appFilesize1024));
                });
        }

        private void lbxTitleQueue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = lbxTitleQueue.IndexFromPoint(e.X, e.Y);
                if (index >= 0)
                {
                    lbxTitleQueue.SelectedIndex = index;

                    if (index == 0 && queueIsProcessing == true)
                    {
                        tsmiRemove.Text = "Can't remove currently Processing Title";
                        tsmiRemove.Enabled = false;
                    }
                    else
                    {
                        tsmiRemove.Text = "Remove Title from Queue";
                        tsmiRemove.Enabled = true;
                    }


                    cmsTitleQueue.Show(lbxTitleQueue, e.Location);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void btnManualAdd_Click(object sender, EventArgs e)
        {
            txtManualTitleKey.BackColor = Color.White;
            lblManualTitleKeyError.ForeColor = Color.Black;
            lblManualTitleKeyError.Text = "";

            txtManualID.BackColor = Color.White;
            lblManualTitleIDError.ForeColor = Color.Black;
            lblManualTitleIDError.Text = "";

            txtManualName.BackColor = Color.White;
            lblManualNameError.ForeColor = Color.Black;
            lblManualNameError.Text = "";

            try
            {
                byte[] titleKey = Utils.GetByteArrayFromHexString(txtManualTitleKey.Text);

                if (titleKey.Length != 16)
                {
                    ManualTitleKeyErrorDisplay();
                    return;
                }
            }
            catch (Exception)
            {
                ManualTitleKeyErrorDisplay();
                return;
            }

            try
            {
                byte[] titleID = Utils.GetByteArrayFromHexString(txtManualID.Text);

                if (!(
                    txtManualID.Text.StartsWith("00050000") ||
                    txtManualID.Text.StartsWith("00050002") ||
                    txtManualID.Text.ToLower().StartsWith("0005000c") ||
                    txtManualID.Text.ToLower().StartsWith("0005000e") ||
                    txtManualID.Text.StartsWith("00050010") ||
                    txtManualID.Text.ToLower().StartsWith("0005001b") ||
                    txtManualID.Text.StartsWith("00050030")
                    ) || titleID.Length != 8)
                {
                    ManualTitleIDErrorDisplay();
                    return;
                }
            }
            catch (Exception)
            {
                ManualTitleIDErrorDisplay();
                return;
            }

            if (txtManualName.Text == null || txtManualName.Text == "")
            {
                txtManualName.BackColor = Color.Salmon;
                lblManualNameError.ForeColor = Color.Red;
                lblManualNameError.Text = "Please Enter a Name!";
                return;
            }

            TitleData title = new TitleData(txtManualID.Text, txtManualTitleKey.Text, txtManualName.Text.SanitizeFileName(), (string)cboManualRegion.SelectedItem, "0");
            AddTitleToQueue(title);
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            lbxTitleQueue.Items.Remove(lbxTitleQueue.Items[lbxTitleQueue.SelectedIndex]);
        }

        // CheckBoxes
        private void chkGame_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void ChkGameUpdate_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkGameDlc_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkDemo_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkSysApp_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkSysData_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkBackTitle_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkRegJpn_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkRegUsa_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkRegEur_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkRegChn_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkRegKor_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkRegTwn_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void chkRegUnk_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTitleRows();
        }

        private void dgvTitles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                AddTitleToQueue(titles[e.RowIndex]);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmSettings frmSet = new frmSettings(config, "config.json"))
            {
                DialogResult result = frmSet.ShowDialog();

                if (result == DialogResult.OK)
                {
                    config = frmSet.config;

                    WriteToLog("Config updated!");
                    WriteToLog("Titles will be saved in " + config.saveDir + Environment.NewLine);
                }
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (config.appAutoUpdateTitlekeys)
                UpdateTitlekeysFile(txtKeySiteUrl.Text + "/json");

            if (config.appAutoLoadData)
                LoadTitleData();
        }

        #endregion events

        #region methods

        private void SaveConfig()
        {
            config.keysite = txtKeySiteUrl.Text;

            config.titleGame = chkGame.Checked;
            config.titleDemo = chkDemo.Checked;
            config.titleGameUpdate = chkGameUpdate.Checked;
            config.titleSysApp = chkSysApp.Checked;
            config.titleSysData = chkSysData.Checked;
            config.titleBackTitle = chkBackTitle.Checked;

            config.regJpn = chkRegJpn.Checked;
            config.regUsa = chkRegUsa.Checked;
            config.regEur = chkRegEur.Checked;
            config.regChn = chkRegChn.Checked;
            config.regKor = chkRegKor.Checked;
            config.regTwn = chkRegTwn.Checked;
            config.regUnk = chkRegUnk.Checked;

            config.patchDemoTimeLimit = chkDemoTimeLimit.Checked;
            config.patchDlcUnlock = chkDlcUnlock.Checked;

            try
            {
                config.SaveToFile("config.json");
                WriteToLog("config.json saved!");
            }
            catch (Exception ex)
            {
                WriteToLog("ERROR! Can't save config.json! Settings won't be saved!" + Environment.NewLine + ex.Message);
            }
            
        }

        //private void DownloadFile(string url, string filePath, string customMessage="")
        //{
        //    using (WebClient wc = new WebClient())
        //    {
        //        wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
        //        wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);

        //        try
        //        {
        //            wc.DownloadFileAsync(new Uri(url), filePath);
        //        }
        //        catch (WebException we)
        //        {
        //            string message = "ERROR! Could not download " + Path.GetFileName(filePath) + "!";
        //            throw new WebException(message, we);
        //        }
        //        catch (IOException ioe)
        //        {
        //            string message = "ERROR! Could not save " + Path.GetFileName(filePath) + "!";
        //            throw new IOException(message, ioe);
        //        }
        //    }
        //}

        private void DownloadTitle(TitleData titleInfo)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);

                    string baseUrl = NINTYCDN_BASEURL + titleInfo.TitleID + "/";
                    string titleType = GetTitleType(titleInfo.TitleID);
                    string saveDir = "";

                    //if (config.appDlGroupDlsIntoSubfolders)
                    //    saveDir = String.Format(@"{0}\install\{1} ({2})\{1} ({2}) [{3}] [{4}]", Environment.CurrentDirectory, titleInfo.Name.SanitizeFileName(), titleInfo.Region, titleType, titleInfo.TitleID);
                    //else
                    //    saveDir = String.Format(@"{0}\install\{1} ({2}) [{3}] [{4}]", Environment.CurrentDirectory, titleInfo.Name.SanitizeFileName(), titleInfo.Region, titleType, titleInfo.TitleID);

                    if (config.appDlGroupDlsIntoSubfolders)
                        saveDir = String.Format(@"{0}\{1} ({2})\{1} ({2}) [{3}] [{4}]", config.saveDir, titleInfo.Name.SanitizeFileName(), titleInfo.Region, titleType, titleInfo.TitleID);
                    else
                        saveDir = String.Format(@"{0}\{1} ({2}) [{3}] [{4}]", config.saveDir, titleInfo.Name.SanitizeFileName(), titleInfo.Region, titleType, titleInfo.TitleID);

                    //if (!(Directory.Exists(Environment.CurrentDirectory + "\\install")))
                    //    Directory.CreateDirectory(Environment.CurrentDirectory + "\\install");
                    if (!(Directory.Exists(saveDir)))
                        Directory.CreateDirectory(saveDir);

                    UInt64 titleSize = 0;
                    Ticket ticket;
                    Tmd tmd;

                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Currently Downloading Title:" + Environment.NewLine + Path.GetFileName(saveDir) });

                    try
                    {
                        txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Downloading TMD from Nintendo CDN..." });
                        tmd = new Tmd(wc.DownloadData(baseUrl + "tmd"));

                        txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Saving TMD - title.tmd" });
                        File.WriteAllBytes(saveDir + "\\title.tmd", tmd.ExportTmdData());
                    }
                    catch (WebException we)
                    {
                        string message = "ERROR! Could not download TMD!";
                        throw new WebException(message, we);
                    }
                    catch (IOException ioe)
                    {
                        string message = "ERROR! Could not save title.tmd!";
                        throw new IOException(message, ioe);
                    }


                    for (int i = 0; i < tmd.GetContentCount(); i++)
                        titleSize += tmd.GetContentSize((uint)i);

                    string titleSizeStr = String.Format("Estimated Content Size: {0:n0} bytes. (Approx. {1})", titleSize, ((double)titleSize).ConvertByteToText(config.appFilesize1024));
                    lblTitleTotalSize.Invoke(new UpdateTitleTotalSizeCallBack(this.UpdateTitleTotalSize), new object[] { titleSizeStr });

                    string currentTitleLogStr = String.Format("{0}" + Environment.NewLine + "{1}", Path.GetFileName(saveDir), titleSizeStr);

                    lblProgressTitle.Invoke(new UpdateProgressTitleCallBack(this.UpdateProgressTitle), new object[] { currentTitleLogStr });
                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { titleSizeStr });

                    // Only GAME, DEMO, and GAME-DLC need "Unnofficial" Ticket, either from "That site" or a generated one
                    // So All other types of titles should just grab official ticket direct from CDN
                    if (!(titleType == TYPE_GAME || titleType == TYPE_DEMO || titleType == TYPE_DLC))
                    {
                        txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Downloading Ticket from Nintendo CDN..." });
                        try
                        {
                            byte[] cetk = wc.DownloadData(baseUrl + "cetk");
                            byte[] tik = new byte[0x350];

                            for (int i = 0; i < tik.Length; i++)
                                tik[i] = cetk[i];

                            ticket = new Ticket(tik);
                        }
                        catch (WebException we)
                        {
                            string message = "ERROR! Could not download Ticket from Nintendo CDN!";
                            throw new WebException(message, we);
                        }
                    }
                    else
                    {
                        if (titleInfo.TicketIsAvailable)
                        {
                            string tikUrl = txtKeySiteUrl.Text + "/ticket/" + titleInfo.TitleID + ".tik";
                            txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Downloading Ticket from " + tikUrl + "..." });
                            try
                            {
                                ticket = new Ticket(wc.DownloadData(tikUrl));
                            }
                            catch (WebException we)
                            {
                                string message = "ERROR! Could not download Ticket from " + tikUrl + "!";
                                throw new WebException(message, we);
                            }
                        }
                        else
                        {
                            txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Generating Fake Ticket..." });
                            ticket = new Ticket();
                            ticket.PatchTitleID(titleInfo.TitleID);
                            ticket.PatchTitleKey(titleInfo.TitleKey);
                            ticket.PatchTitleVersion(tmd.GetTitleVersion());

                            if (titleType == TYPE_DLC && chkDlcUnlock.Checked)
                            {
                                txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Patching Ticket - Applying \"DLC Unlock All\" Patch" });
                                ticket.PatchDLCUnlockAll();
                            }

                            if (titleType == TYPE_DEMO && chkDemoTimeLimit.Checked)
                            {
                                txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Patching Ticket - Applying \"Demo Remove Time Limit\" Patch" });
                                ticket.PatchDemoKillTimeLimit();
                            }

                        }

                    }

                    // Write tik, tmd, and cert to file
                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Saving Ticket - title.tik" });

                    try
                    {
                        File.WriteAllBytes(saveDir + "\\title.tik", ticket.ExportTicketData());
                    }
                    catch (IOException ioe)
                    {
                        string message = "ERROR! Could not save title.tik!";
                        throw new IOException(message, ioe);
                    }


                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Saving title.cert..." });

                    try
                    {
                        //File.Copy(Environment.CurrentDirectory + "\\magic.cert", saveDir + "\\title.cert", true);
                        File.WriteAllBytes(saveDir + "\\title.cert", Utils.GetByteArrayFromHexString("00010003704138EFBBBDA16A987DD901326D1C9459484C88A2861B91A312587AE70EF6237EC50E1032DC39DDE89A96A8E859D76A98A6E7E36A0CFE352CA893058234FF833FCB3B03811E9F0DC0D9A52F8045B4B2F9411B67A51C44B5EF8CE77BD6D56BA75734A1856DE6D4BED6D3A242C7C8791B3422375E5C779ABF072F7695EFA0F75BCB83789FC30E3FE4CC8392207840638949C7F688565F649B74D63D8D58FFADDA571E9554426B1318FC468983D4C8A5628B06B6FC5D507C13E7A18AC1511EB6D62EA5448F83501447A9AFB3ECC2903C9DD52F922AC9ACDBEF58C6021848D96E208732D3D1D9D9EA440D91621C7A99DB8843C59C1F2E2C7D9B577D512C166D6F7E1AAD4A774A37447E78FE2021E14A95D112A068ADA019F463C7A55685AABB6888B9246483D18B9C806F474918331782344A4B8531334B26303263D9D2EB4F4BB99602B352F6AE4046C69A5E7E8E4A18EF9BC0A2DED61310417012FD824CC116CFB7C4C1F7EC7177A17446CBDE96F3EDD88FCD052F0B888A45FDAF2B631354F40D16E5FA9C2C4EDA98E798D15E6046DC5363F3096B2C607A9D8DD55B1502A6AC7D3CC8D8C575998E7D796910C804C495235057E91ECD2637C9C1845151AC6B9A0490AE3EC6F47740A0DB0BA36D075956CEE7354EA3E9A4F2720B26550C7D394324BC0CB7E9317D8A8661F42191FF10B08256CE3FD25B745E5194906B4D61CB4C2E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000526F6F7400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001434130303030303030330000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000007BE8EF6CB279C9E2EEE121C6EAF44FF639F88F078B4B77ED9F9560B0358281B50E55AB721115A177703C7A30FE3AE9EF1C60BC1D974676B23A68CC04B198525BC968F11DE2DB50E4D9E7F071E562DAE2092233E9D363F61DD7C19FF3A4A91E8F6553D471DD7B84B9F1B8CE7335F0F5540563A1EAB83963E09BE901011F99546361287020E9CC0DAB487F140D6626A1836D27111F2068DE4772149151CF69C61BA60EF9D949A0F71F5499F2D39AD28C7005348293C431FFBD33F6BCA60DC7195EA2BCC56D200BAF6D06D09C41DB8DE9C720154CA4832B69C08C69CD3B073A0063602F462D338061A5EA6C915CD5623579C3EB64CE44EF586D14BAAA8834019B3EEBEED3790001000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100042EA66C66CFF335797D0497B77A197F9FE51AB5A41375DC73FD9E0B10669B1B9A5B7E8AB28F01B67B6254C14AA1331418F25BA549004C378DD72F0CE63B1F7091AAFE3809B7AC6C2876A61D60516C43A63729162D280BE21BE8E2FE057D8EB6E204242245731AB6FEE30E5335373EEBA970D531BBA2CB222D9684387D5F2A1BF75200CE0656E390CE19135B59E14F0FA5C1281A7386CCD1C8EC3FAD70FBCE74DEEE1FD05F46330B51F9B79E1DDBF4E33F14889D05282924C5F5DC2766EF0627D7EEDC736E67C2E5B93834668072216D1C78B823A072D34FF3ECF9BD11A29AF16C33BD09AFB2D74D534E027C19240D595A68EBB305ACC44AB38AB820C6D426560C000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000526F6F742D43413030303030303033000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000143503030303030303062000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000137A080BA689C590FD0B2F0D4F56B632FB934ED0739517B33A79DE040EE92DC31D37C7F73BF04BD3E44E20AB5A6FEAF5984CC1F6062E9A9FE56C3285DC6F25DDD5D0BF9FE2EFE835DF2634ED937FAB0214D104809CF74B860E6B0483F4CD2DAB2A9602BC56F0D6BD946AED6E0BE4F08F26686BD09EF7DB325F82B18F6AF2ED525BFD828B653FEE6ECE400D5A48FFE22D538BB5335B4153342D4335ACF590D0D30AE2043C7F5AD214FC9C0FE6FA40A5C86506CA6369BCEE44A32D9E695CF00B4FD79ADB568D149C2028A14C9D71B850CA365B37F70B657791FC5D728C4E18FD22557C4062D74771533C70179D3DAE8F92B117E45CB332F3B3C2A22E705CFEC66F6DA3772B000100010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010004919EBE464AD0F552CD1B72E7884910CF55A9F02E50789641D896683DC005BD0AEA87079D8AC284C675065F74C8BF37C88044409502A022980BB8AD48383F6D28A79DE39626CCB2B22A0F19E41032F094B39FF0133146DEC8F6C1A9D55CD28D9E1C47B3D11F4F5426C2C780135A2775D3CA679BC7E834F0E0FB58E68860A71330FC95791793C8FBA935A7A6908F229DEE2A0CA6B9B23B12D495A6FE19D0D72648216878605A66538DBF376899905D3445FC5C727A0E13E0E2C8971C9CFA6C60678875732A4E75523D2F562F12AABD1573BF06C94054AEFA81A71417AF9A4A066D0FFC5AD64BAB28B1FF60661F4437D49E1E0D9412EB4BCACF4CFD6A3408847982000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000526F6F742D43413030303030303033000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000158533030303030303063000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000137A0894AD505BB6C67E2E5BDD6A3BEC43D910C772E9CC290DA58588B77DCC11680BB3E29F4EABBB26E98C2601985C041BB14378E689181AAD770568E928A2B98167EE3E10D072BEEF1FA22FA2AA3E13F11E1836A92A4281EF70AAF4E462998221C6FBB9BDD017E6AC590494E9CEA9859CEB2D2A4C1766F2C33912C58F14A803E36FCCDCCCDC13FD7AE77C7A78D997E6ACC35557E0D3E9EB64B43C92F4C50D67A602DEB391B06661CD32880BD64912AF1CBCB7162A06F02565D3B0ECE4FCECDDAE8A4934DB8EE67F3017986221155D131C6C3F09AB1945C206AC70C942B36F49A1183BCD78B6E4B47C6C5CAC0F8D62F897C6953DD12F28B70C5B7DF751819A98346526250001000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
                    }
                    catch (IOException ioe)
                    {
                        string message = "ERROR! Could not save title.cert!";
                        throw new IOException(message, ioe);
                    }

                    // Download Content .app and .h3 files
                    uint contentCount = tmd.GetContentCount();
                    for (uint i = 0; i < contentCount; i++)
                    {
                        string cidStr = tmd.GetContentIDString(i);

                        // .app files
                        try
                        {
                            while (wc.IsBusy)
                                System.Threading.Thread.Sleep(5);

                            string currentContentLogStr = String.Format("Downloading Content No. {0} of {1} from Nintendo CDN - {2}.app", i + 1, contentCount, cidStr);

                            lblProgressContent.Invoke(new UpdateProgressContentCallBack(this.UpdateProgressContent), new object[] { currentContentLogStr });

                            string contentFilePath = saveDir + "\\" + cidStr + ".app";
                            if (config.appDlIgnoreExistingContentFiles && File.Exists(contentFilePath) && (ulong)contentFilePath.GetFileLength() == tmd.GetContentSize(i))
                            {
                                txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "File: " + cidStr + ".app already exists with correct file size, skipping download..." });
                            }
                            else
                            {
                                txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { currentContentLogStr });

                                wc.DownloadFileAsync(new Uri(baseUrl + cidStr), saveDir + "\\" + cidStr + ".app");
                            }

                        }
                        catch (WebException we)
                        {
                            string message = "ERROR! Could not download " + cidStr + ".app";
                            throw new WebException(message, we);
                        }
                        catch (IOException ioe)
                        {
                            string message = "ERROR! Could not save " + cidStr + ".app";
                            throw new IOException(message, ioe);
                        }

                        // .h3 files
                        try
                        {
                            while (wc.IsBusy)
                                System.Threading.Thread.Sleep(5);

                            txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { String.Format("Downloading H3 for Content No.{0} from Nintendo CDN - {1}.h3", i + 1, cidStr) });
                            wc.DownloadFile(baseUrl + cidStr + ".h3", saveDir + "\\" + cidStr + ".h3");

                        }
                        catch (WebException we)
                        {
                            if (((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound)
                                txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { String.Format("WARNING: {0}.h3 not found, ignoring...", cidStr) });
                            else
                            {
                                string message = "ERROR! Could not download " + cidStr + ".h3";
                                throw new WebException(message, we);
                            }
                        }
                        catch (IOException ioe)
                        {
                            string message = "ERROR! Could not save " + cidStr + ".h3";
                            throw new IOException(message, ioe);
                        }
                    }
                    string titleCompleteStr = String.Format("Title: {0} completed!", Path.GetFileName(saveDir));
                    lblProgressContent.Invoke(new UpdateProgressContentCallBack(this.UpdateProgressContent), new object[] { titleCompleteStr });
                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { titleCompleteStr + Environment.NewLine });

                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message + Environment.NewLine + ex.InnerException.Message + Environment.NewLine + "ABORTING DOWNLOAD OF THIS TITLE";
                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { errorMessage });
                }

            }
        }

        private void AddTitleToQueue(TitleData _titleData)
        {
            if (!(_titleData.TitleID == null || _titleData.TitleID == ""))
            {
                string titleDesc = String.Format("[{0}] [{1}] {2}", _titleData.Region, GetTitleType(_titleData.TitleID), _titleData.Name.SanitizeFileName());
                KeyValuePair<TitleData, string> listItem = new KeyValuePair<TitleData, string>(_titleData, titleDesc);

                foreach (KeyValuePair<TitleData, string> _listItem in lbxTitleQueue.Items)
                {
                    if (_titleData.TitleID.ToLower() == _listItem.Key.TitleID.ToLower())
                        return;
                }

                lbxTitleQueue.Items.Add(new KeyValuePair<TitleData, string>(_titleData, titleDesc));
                lbxTitleQueue.DisplayMember = "Value";
            }
        }

        private void LoadTitleData()
        {
            if (File.Exists("titlekeys.json"))
            {
                try
                {
                    titles = JsonConvert.DeserializeObject<List<TitleData>>(File.ReadAllText("titlekeys.json"));

                    for (int i = 0; i < titles.Count; i++)
                    {
                        if (titles[i].TitleKey == null && titles[i].TicketIsAvailable == false)
                        {
                            // No Ticket or TitleKey available, immposible to use this entry
                            titles.Remove(titles[i]);
                            i--;
                        }
                    }

                    dgvTitles.DataSource = titles;

                    for (int i = 0; i < dgvTitles.Rows.Count; i++)
                        dgvTitles.Rows[i].Cells["TitleType"].Value = GetTitleType((string)dgvTitles.Rows[i].Cells["TitleID"].Value);

                    dgvTitles.Columns["TitleID"].DisplayIndex = 0;
                    dgvTitles.Columns["TitleType"].Visible = true;
                    dgvTitles.Columns["TitleType"].DisplayIndex = 1;
                    dgvTitles.Columns["Name"].DisplayIndex = 2;
                    dgvTitles.Columns["TitleKey"].Visible = false;

                    for (int i = 0; i < dgvTitles.Columns.Count; i++)
                        dgvTitles.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    ShowHideTitleRows();
                }
                catch (Exception ex)
                {
                    WriteToLog("ERROR! Cannot load data from titlekeys.json!" + Environment.NewLine + ex.Message + Environment.NewLine);
                    WriteToLog("Please check that your titlekeys.json is not corrupt." + Environment.NewLine + "Perhaps Redownload / Update your titlekeys.json and try again?");
                }
            }
        }

        private string GetTitleType(string titleID)
        {
            string titleType = "";
            switch (new string(new char[2] { titleID[6], titleID[7] }))
            {
                case "00":
                    titleType = TYPE_GAME;
                    break;

                case "02":
                    titleType = TYPE_DEMO;
                    break;

                case "0c":
                    titleType = TYPE_DLC;
                    break;

                case "0e":
                    titleType = TYPE_UPDATE;
                    break;

                case "10":
                    titleType = TYPE_SYSAPP;
                    break;

                case "1b":
                    titleType = TYPE_SYSDATA;
                    break;

                case "30":
                    titleType = TYPE_BACKGROUND;
                    break;
            }

            return titleType;
        }

        private void ShowHideTitleRows()
        {
            if (dgvTitles.DataSource != null)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dgvTitles.DataSource];
                cm.SuspendBinding();

                for (int i = 0; i < dgvTitles.Rows.Count; i++)
                {
                    bool show = true;
                    while (show)
                    {
                        switch (GetTitleType(((TitleData)dgvTitles.Rows[i].DataBoundItem).TitleID))
                        {
                            case TYPE_GAME:
                                if (!chkGame.Checked)
                                    show = false;
                                break;

                            case TYPE_DEMO:
                                if (!chkDemo.Checked)
                                    show = false;
                                break;

                            case TYPE_DLC:
                                if (!chkGameDlc.Checked)
                                    show = false;
                                break;

                            case TYPE_UPDATE:
                                if (!chkGameUpdate.Checked)
                                    show = false;
                                break;

                            case TYPE_SYSAPP:
                                if (!chkSysApp.Checked)
                                    show = false;
                                break;

                            case TYPE_SYSDATA:
                                if (!chkSysData.Checked)
                                    show = false;
                                break;

                            case TYPE_BACKGROUND:
                                if (!chkBackTitle.Checked)
                                    show = false;
                                break;
                        }

                        switch (((TitleData)dgvTitles.Rows[i].DataBoundItem).Region)
                        {
                            case REG_JPN:
                                if (!chkRegJpn.Checked)
                                    show = false;
                                break;

                            case REG_USA:
                                if (!chkRegUsa.Checked)
                                    show = false;
                                break;

                            case REG_EUR:
                                if (!chkRegEur.Checked)
                                    show = false;
                                break;

                            case REG_CHN:
                                if (!chkRegChn.Checked)
                                    show = false;
                                break;

                            case REG_KOR:
                                if (!chkRegKor.Checked)
                                    show = false;
                                break;

                            case REG_TWN:
                                if (!chkRegTwn.Checked)
                                    show = false;
                                break;

                            case REG_UNK:
                            default:
                                if (!chkRegUnk.Checked)
                                    show = false;
                                break;
                        }

                        try
                        {
                            if (!(dgvTitles.Rows[i].Cells["TitleID"].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()) || dgvTitles.Rows[i].Cells["TItleKey"].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()) || dgvTitles.Rows[i].Cells["Name"].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower())) && txtSearch.Text != "")
                            {
                                show = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            show = false;
                        }

                        break;
                    }
                    dgvTitles.Rows[i].Visible = show;

                }

                cm.ResumeBinding();
            }

        }

        private void UpdateTitlekeysFile(string url)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    WriteToLog("Updating titlekeys.json...");
                    WriteToLog("Fetching titlekeys.json from: " + url);
                    wc.DownloadFile(url, Environment.CurrentDirectory + "\\titlekeys.json");
                    WriteToLog("titlekeys.json Updated!");
                }
                catch (WebException we)
                {
                    WriteToLog("ERROR! Can't download titlekeys.json!" + Environment.NewLine + we.Message);
                }
                catch (IOException ioe)
                {
                    WriteToLog("ERROR! Can't save titlekeys.json!" + Environment.NewLine + ioe.Message);
                }

            }
        }

        private void ManualTitleKeyErrorDisplay()
        {
            txtManualTitleKey.BackColor = Color.Salmon;
            lblManualTitleKeyError.ForeColor = Color.Red;
            lblManualTitleKeyError.Text = "Please Enter a Valid TitleKey!";
        }

        private void ManualTitleIDErrorDisplay()
        {
            txtManualID.BackColor = Color.Salmon;
            lblManualTitleIDError.ForeColor = Color.Red;
            lblManualTitleIDError.Text = "Please Enter a Valid TitleID!";
        }

        private string CheckUrlPrefix(string url)
        {
            if (!(url.StartsWith("http://") || url.StartsWith("https://")) && url != "")
                url = "http://" + url;

            return url;
        }

        private void UpdateProgressTitle(string line)
        {
            lblProgressTitle.Text = line;
        }

        private void UpdateProgressContent(string line)
        {
            lblProgressContent.Text = line;
        }

        private void UpdateProgressData(string line)
        {
            lblProgressData.Text = line;
        }

        private void UpdateTitleTotalSize(string line)
        {
            lblTitleTotalSize.Text = line;
        }

        private void RemoveFirstTitleFromQueue()
        {
            lbxTitleQueue.Items.Remove(lbxTitleQueue.Items[0]);
        }

        private void EnableDisableDlButton(bool enabled)
        {
            btnDownload.Enabled = enabled;
        }

        private void WriteToLog(string line)
        {
            txtLog.AppendText(line);
            txtLog.AppendText(Environment.NewLine);
        }

        #endregion methods
    }
}
