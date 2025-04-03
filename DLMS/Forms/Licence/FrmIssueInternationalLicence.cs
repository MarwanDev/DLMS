using DLMS_Business;
using DLMS_Business.Application;
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
            Driver driver = Driver.Find(ucLicenceSearch1.GetDriverId());
            ApplicationModel application = new ApplicationModel
            {
                ApplicantPersonId = driver.PersonId,
                ApplicationTypeId = 6,
                ApplicationDate = DateTime.Now,
                LastStatusDate = DateTime.Now,
                ApplicationStatus = 3,
                CreatedByUserId = UserSession.LoggedInUser.ID
            };
            int applicationId = -1;
            if (application.AddNewApplication(ref applicationId))
            {
                LicenceModel licence = new LicenceModel
                {
                    ApplicationId = applicationId,
                    DriverId = driver.ID,
                    LocalLicenceId = Int32.Parse(lblLocalLicenceId.Text),
                    IssueDate = DateTime.Parse(lblIssueDate.Text),
                    ExpirationDate = DateTime.Parse(lblExpirationDate.Text),
                    CreatedByUserId = UserSession.LoggedInUser.ID,
                    IsActive = true
                };
                if (licence.AddNewInternationalLicence())
                {
                    MessageBox.Show($"International Licence Issued Successfully with ID {licence.ID}",
                        "Success",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Information);
                    btnIssue.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"Something wrong happened while creating the international licence", "Error",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Something wrong happened while creating the application", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
            }
        }

        private void FrmIssueInternationalLicence_Load(object sender, EventArgs e)
        {
            ApplicationType applicationType = ApplicationType.Find(6);
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = ((int)applicationType.Fees).ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblCreatedBy.Text = UserSession.LoggedInUser.UserName;
        }
    }
}
