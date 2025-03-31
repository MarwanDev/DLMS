using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.Forms.Licence
{
    public partial class FrmIssueLicence : Form
    {
        public FrmIssueLicence()
        {
            InitializeComponent();
        }

        public LocalDLApplication CurrentLocalDLApplication { get; set; }
        public byte CurrentIssueReason { get; set; }

        public FrmIssueLicence(LocalDLApplication localDLApplication, byte issueReason)
        {
            InitializeComponent();
            CurrentLocalDLApplication = localDLApplication;
            CurrentIssueReason = issueReason;
            ChangeFormText();
            ModifyControlsAccordingToApplication();
        }

        private void ModifyControlsAccordingToApplication()
        {
            ucDLApplicationInfo1.SetLocalDLApplication(CurrentLocalDLApplication);
            ucDLApplicationInfo1.SetApplicant(CurrentLocalDLApplication.PersonFullName);
            ucDLApplicationInfo1.SetApplicationDate(CurrentLocalDLApplication.ApplicationDate);
            ucDLApplicationInfo1.SetApplicationId(CurrentLocalDLApplication.ApplicationID);
            ucDLApplicationInfo1.SetApplicationType(CurrentLocalDLApplication.ApplicationTypeTitle);
            ucDLApplicationInfo1.SetCreatedByUserName(CurrentLocalDLApplication.CreatedByUserName);
            ucDLApplicationInfo1.SetLastStatusDate(CurrentLocalDLApplication.LastStatusDate);
            ucDLApplicationInfo1.SetLicence(CurrentLocalDLApplication.LicenceClassName);
            ucDLApplicationInfo1.SetFees(CurrentLocalDLApplication.PaidFees);
            ucDLApplicationInfo1.SetId(CurrentLocalDLApplication.ID);
            ucDLApplicationInfo1.SetPassedTests(CurrentLocalDLApplication.PassedTests);
            ucDLApplicationInfo1.SetStatus(CurrentLocalDLApplication.StatusText);
            ucDLApplicationInfo1.ChangeShowPersonInfoLinkLabelsAbility();
        }

        private void ChangeFormText()
        {
            this.Text = CurrentIssueReason == 1 ? "Issue Driving Licence First Time" : "Issue Driving Licence";
        }

        public new event Action OnFormClosed;

        private void FrmIssueLicence_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver
            {
                PersonId = LocalDLApplication.GetPersonApplicantId(CurrentLocalDLApplication.ID),
                CreatedByUserId = UserSession.LoggedInUser.ID,
                CreatedDate = DateTime.Now
            };
            if (driver.AddNewDriver())
            {
                LicenceModel licence = new LicenceModel
                {
                    ApplicationId = LocalDLApplication.GetApplicationId(CurrentLocalDLApplication.ID),
                    LicenceClassId = LocalDLApplication.GetLicenceClassId(CurrentLocalDLApplication.ID),
                    DriverId = driver.ID,
                    IssueDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                    ExpirationDate = DateTime.Parse(DateTime.Now.AddYears(10).ToShortDateString()),
                    IsActive = true,
                    Notes = rtbNotes.Text.Trim(),
                    PaidFees = CurrentLocalDLApplication.PaidFees,
                    IssueReason = CurrentIssueReason,
                    CreatedByUserId = UserSession.LoggedInUser.ID
                };
                if (licence.AddNewLicence())
                {
                    MessageBox.Show($"Licence Issued Successfully with ID {licence.ID}",
                        "Success",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Information);
                    if (LocalDLApplication.ChangeApplicationStatus(CurrentLocalDLApplication.ID, 3))
                    {
                        MessageBox.Show($"Application Completed Successfully", "Success",
                            MessageBoxButtons.OK,
                            icon: MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Something wrong happened while changing Application status", "Error",
                            MessageBoxButtons.OK,
                            icon: MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show($"Something wrong happened while saving the licence", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
            }
            else
                MessageBox.Show($"Something wrong happened while saving the driver info",
                "Error",
                MessageBoxButtons.OK,
                icon: MessageBoxIcon.Error);
        }
    }
}
