using System;
using System.Windows.Forms;

namespace DLMS.Forms.Licence.Local
{
    public partial class FrmReplaceLicence : Form
    {
        public FrmReplaceLicence()
        {
            InitializeComponent();
            ucLicenceSearch1.CurrentMode = UserControls.UcLicenceSearch.Mode.Lost;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {

        }
    }
}
