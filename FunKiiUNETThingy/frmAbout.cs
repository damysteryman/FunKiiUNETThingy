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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            this.Icon = FunKiiUNETThingy.Properties.Resources.FunKiiUNETThingy;
            this.pbxPicture.Image = new Bitmap(FunKiiUNETThingy.Properties.Resources.FunKiiUNETThingyPNG, 128, 128);
            this.lblAppTitle.Text = String.Format("{0} v{1}", Application.ProductName, Application.ProductVersion);
            this.lblAuthor.Text = String.Format("By {0}", Application.CompanyName);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
