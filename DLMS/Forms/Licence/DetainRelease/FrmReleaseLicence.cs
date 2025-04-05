using DLMS_Business;
using DLMS_Business.Application;
using DLMS_Business.Licence;
using System;
using System.Windows.Forms;

namespace DLMS.Forms.Licence.DetainRelease
{
    public partial class FrmReleaseLicence : Form
    {
        public FrmReleaseLicence()
        {
            InitializeComponent();
            ucLicenceSearch1.CurrentMode = UserControls.UcLicenceSearch.Mode.ReleaseDetained;
            ucLicenceSearch1.OnReleaseeButtonAbilityChanged += ChangeReleaseBtnAbiblity;
            ucLicenceSearch1.OnSubmittingValidLicenceId += ChangeControlsUIAfterLicenceShow;
        }

        public FrmReleaseLicence(LicenceModel licence)
        {
            InitializeComponent();
            CurrentLicence = licence;
            CurrentDetainedLicence = DetainedLicence.FindbyLicenceId(licence.ID);
            ucLicenceSearch1.SearchForValidLicence(licence.ID);
            ucLicenceSearch1.DisableFilterGroupBox();
            ucLicenceSearch1.CurrentLicence = licence;
            ucLicenceSearch1.CurrentMode = UserControls.UcLicenceSearch.Mode.ReleaseDetained;
            ucLicenceSearch1.ModifyControlsUIAccordingToLicence(licence);
            ChangeReleaseBtnAbiblity(true);
            llShowLicenceHistory.Enabled = true;
            llShowNewLiceence.Enabled = true;
            ChangeControlsUIAfterLicenceShow(licence.ID);
        }

        private void ChangeReleaseBtnAbiblity(bool isEnabled)
        {
            btnRelease.Enabled = isEnabled;
        }

        private void ChangeControlsUIAfterLicenceShow(int licenceId)
        {
            lblLicenceId.Text = licenceId != -1 ? licenceId.ToString() : "???";
            CurrentLicence = ucLicenceSearch1.CurrentLicence;
            llShowLicenceHistory.Enabled = true;
            CurrentPerson = Person.FindByNationalNo(ucLicenceSearch1.GetNationalNumber());
            CurrentDetainedLicence = DetainedLicence.FindbyLicenceId(CurrentLicence.ID);
            lblDetainedId.Text = CurrentDetainedLicence.ID.ToString();
            lblDetainDate.Text = CurrentDetainedLicence.ReleaseDate.ToShortDateString();
            lblFineFees.Text = CurrentDetainedLicence.FineFees.ToString();
            lblDetainedBy.Text = UserSession.LoggedInUser.UserName;
            CurrentApplicationType = ApplicationType.Find(5);
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = CurrentApplicationType?.Fees.ToString();
            lblTotalFees.Text = (decimal.Parse(lblApplicationFees.Text) + decimal.Parse(lblFineFees.Text)).ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRelease_Click(object sender, EventArgs e)
        {
            int applicationId = -1;
            Driver driver = Driver.Find(ucLicenceSearch1.GetDriverId());
            ApplicationModel application = new ApplicationModel
            {
                ApplicantPersonId = driver.PersonId,
                ApplicationDate = DateTime.Now,
                ApplicationTypeId = 5,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = CurrentApplicationType.Fees,
                CreatedByUserId = UserSession.LoggedInUser.ID
            };
            if (application.AddNewApplication(ref applicationId))
            {
                lblApplicationId.Text = applicationId.ToString();
                CurrentDetainedLicence.ReleaseDate = DateTime.Now;
                CurrentDetainedLicence.ReleaseApplicationId = applicationId;
                CurrentDetainedLicence.ReleasedByUserId = UserSession.LoggedInUser.ID;
                if (CurrentDetainedLicence.ReleaseDetainedLicence())
                {
                    MessageBox.Show($"Licence Released Successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Information);
                    ChangeReleaseBtnAbiblity(false);
                    llShowNewLiceence.Enabled = true;
                }
                else
                {
                    MessageBox.Show($"Something wrong happened while Releasing licence", "Error",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Something wrong happened while creating release application", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
            }
        }

        private Person CurrentPerson { get; set; }
        DetainedLicence CurrentDetainedLicence { get; set; }
        private LicenceModel CurrentLicence { get; set; }
        private ApplicationType CurrentApplicationType { get; set; }

        private void FrmReleaseLicence_Load(object sender, EventArgs e)
        {
            CurrentApplicationType = ApplicationType.Find(5);
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = CurrentApplicationType?.Fees.ToString();
        }

        private void LlShowLicenceHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentPerson != null)
            {
                FrmLicenceHistory frm = new FrmLicenceHistory(CurrentPerson);
                frm.ShowDialog();
            }
        }

        private void LlShowNewLiceence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicence frm = new FrmShowLicence(CurrentLicence);
            frm.ShowDialog();
        }

        public new event Action OnFormClosed;

        private void FrmReleaseLicence_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }
    }
}
