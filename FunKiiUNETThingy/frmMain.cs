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
            this.pbxPicture.Image = new Bitmap(FunKiiUNETThingy.Properties.Resources.FunKiiUNETThingyPNG, 96, 96);
        }

        #endregion init

        #region events

        private void frmMain_Load(object sender, EventArgs e)
        {
            WriteToLog("FunKiiUNETThingy Loaded!" + Environment.NewLine);
            WriteToLog("Titles will be saved in " + Environment.CurrentDirectory + "\\install\\" + Environment.NewLine);

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

            lbxTitleQueue.MouseDown += lbxTitleQueue_MouseDown;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("titlekeys.json"))
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
                    lblProgressData.Text = String.Format("Downloaded {0:n0} / {1:n0} bytes - {2}%", e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage);
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
                    string saveDir = String.Format(@"{0}\install\{1} ({2}) [{3}] [{4}]", Environment.CurrentDirectory, titleInfo.Name.SanitizeFileName(), titleInfo.Region, titleType, titleInfo.TitleID);

                    if (!(Directory.Exists(Environment.CurrentDirectory + "\\install")))
                        Directory.CreateDirectory(Environment.CurrentDirectory + "\\install");
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

                    string titleSizeStr = String.Format("Estimated Content Size: {0:n0} bytes. (Approx. {1})", titleSize, ((double)titleSize).ConvertByteToText());
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


                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { "Copying over title.cert" });

                    try
                    {
                        File.Copy(Environment.CurrentDirectory + "\\magic.cert", saveDir + "\\title.cert", true);
                    }
                    catch (IOException ioe)
                    {
                        string message = "ERROR! Could not copy title.cert!";
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
                            txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { currentContentLogStr });

                            wc.DownloadFileAsync(new Uri(baseUrl + cidStr), saveDir + "\\" + cidStr + ".app");
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
                //catch (IOException ioe)
                //{
                //    string errorMessage = ioe.Message + Environment.NewLine + "ABORTING DOWNLOAD OF THIS TITLE";
                //    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { errorMessage });
                //}
                //catch (WebException we)
                //{
                //    Console.WriteLine(we.ToString());

                //    string errorMessage = we.Message + Environment.NewLine + we.InnerException.Message + Environment.NewLine + "ABORTING DOWNLOAD OF THIS TITLE";
                //    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { errorMessage });
                //}
                catch (Exception ex)
                {
                    string errorMessage = ex.Message + Environment.NewLine + ex.InnerException.Message + Environment.NewLine + "ABORTING DOWNLOAD OF THIS TITLE";
                    txtLog.Invoke(new WriteToLogCallBack(this.WriteToLog), new object[] { errorMessage });
                }

            }
        }

        private void AddTitleToQueue(TitleData _titleData)
        {
            if (_titleData.TitleID != null)
            {
                string titleDesc = String.Format("[{0}] [{1}] {2}", _titleData.Region, GetTitleType(_titleData.TitleID), _titleData.Name.SanitizeFileName());
                KeyValuePair<TitleData, string> listItem = new KeyValuePair<TitleData, string>(_titleData, titleDesc);
                if (!(lbxTitleQueue.Items.Contains(listItem)))
                {
                    lbxTitleQueue.Items.Add(new KeyValuePair<TitleData, string>(_titleData, titleDesc));
                    lbxTitleQueue.DisplayMember = "Value";
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

        //private string CheckTitleKeyUrl(string url)
        //{
        //    //byte[] thatSiteMd5 = Encoding.ASCII.GetBytes("d098abb93c29005dbd07deb43d81c5df");
        //    byte[] thatSiteMd5 = new byte[16] { 0xd0, 0x98, 0xab, 0xb9, 0x3c, 0x29, 0x00, 0x5d, 0xbd, 0x07, 0xde, 0xb4, 0x3d, 0x81, 0xc5, 0xdf };
        //    MD5 md5 = MD5.Create();
        //    byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(url));

        //    if (hash.SequenceEqual(thatSiteMd5))
        //        url = "http://" + url + "/json";

        //    Console.WriteLine(url);

        //    return url;
        //}

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
