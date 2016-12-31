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

namespace FunKiiUNETThingy
{
    public partial class frmSettings : Form
    {
        public Config config;
        //private string cfgFileName;

        public frmSettings(Config _config, string fileName)
        {
            InitializeComponent();
            this.Icon = FunKiiUNETThingy.Properties.Resources.FunKiiUNETThingy;

            config = _config;
            //cfgFileName = fileName;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            chkAutoUpdateTitlekeys.Checked = config.appAutoUpdateTitlekeys;
            chkAutoLoadData.Checked = config.appAutoLoadData;
            chkFileDownloadSkip.Checked = config.appDlIgnoreExistingContentFiles;
            chkGroupDownloads.Checked = config.appDlGroupDlsIntoSubfolders;
            txtSaveDir.Text = config.saveDir;

            chkFilesize1024.Checked = config.appFilesize1024;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            config.appAutoUpdateTitlekeys = chkAutoUpdateTitlekeys.Checked;
            config.appAutoLoadData = chkAutoLoadData.Checked;
            config.appDlIgnoreExistingContentFiles = chkFileDownloadSkip.Checked;
            config.appDlGroupDlsIntoSubfolders = chkGroupDownloads.Checked;
            config.appFilesize1024 = chkFilesize1024.Checked;

            if (Directory.Exists(txtSaveDir.Text))
                config.saveDir = txtSaveDir.Text;
            else
            {
                txtSaveDir.BackColor = Color.LightSalmon;
                lblSaveResult.ForeColor = Color.Red;
                lblSaveResult.Text = "Please enter/select a valid Downloads Directory!";
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDirSelect_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtSaveDir.Text = fbd.SelectedPath;
                    txtSaveDir.BackColor = Color.White;
                    lblSaveResult.Text = "";
                }
            }
        }
    }
}
