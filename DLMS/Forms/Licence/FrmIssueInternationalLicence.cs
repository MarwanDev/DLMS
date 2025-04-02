using System;
using System.Windows.Forms;

namespace DLMS.Forms.Licence
{
    public partial class FrmIssueInternationalLicence : Form
    {
        public FrmIssueInternationalLicence()
        {
            InitializeComponent();
            ucLicenceSearch1.OnIssueButtonAbilityChanged += IssueButtonAbilityChanged;
        }

        private void IssueButtonAbilityChanged(bool isEnabled)
        {
            btnIssue.Enabled = isEnabled;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {

        }
    }
}
