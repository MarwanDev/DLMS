using DLMS_Business;
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
            ucLicenceSearch1.OnSubmittingValidLicenceId += ChangeCurrentLicencId;
        }

        private void IssueButtonAbilityChanged(bool isEnabled)
        {
            btnIssue.Enabled = isEnabled;
        }

        private void ChangeCurrentLicencId(int licenceId)
        {
            lblLocalLicenceId.Text = licenceId != -1 ? licenceId.ToString() : "???";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {

        }

        private void FrmIssueInternationalLicence_Load(object sender, EventArgs e)
        {
            ApplicationType applicationType = ApplicationType.Find(6);
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDaate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = ((int)applicationType.Fees).ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblCreatedBy.Text = UserSession.LoggedInUser.ID.ToString();
        }
    }
}
