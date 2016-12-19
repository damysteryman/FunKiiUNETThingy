using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunKiiUNETThingy
{
    public partial class frmSettings : Form
    {
        private Config config;
        private string cfgFileName;

        public frmSettings(Config _config, string fileName)
        {
            InitializeComponent();
            this.Icon = FunKiiUNETThingy.Properties.Resources.FunKiiUNETThingy;

            config = _config;
            cfgFileName = fileName;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            chkAutoUpdateTitlekeys.Checked = config.appAutoUpdateTitlekeys;
            chkAutoLoadData.Checked = config.appAutoLoadData;
            chkFileDownloadSkip.Checked = config.appDlIgnoreExistingContentFiles;
            chkGroupDownloads.Checked = config.appDlGroupDlsIntoSubfolders;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            config.appAutoUpdateTitlekeys = chkAutoUpdateTitlekeys.Checked;
            config.appAutoLoadData = chkAutoLoadData.Checked;
            config.appDlIgnoreExistingContentFiles = chkFileDownloadSkip.Checked;
            config.appDlGroupDlsIntoSubfolders = chkGroupDownloads.Checked;

            try
            {
                config.SaveToFile(cfgFileName);
                lblSaveResult.ForeColor = Color.DarkGreen;
                lblSaveResult.Text = cfgFileName + " saved successfully!";
            }
            catch (Exception ex)
            {
                lblSaveResult.ForeColor = Color.Red;
                lblSaveResult.Text = String.Format("ERROR! Failed to save {0}!" + Environment.NewLine + "{1}", cfgFileName, ex.Message);
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
