using DLMS.UserControls;
using DLMS_Business;
using DLMS_Business.Application;
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
            ucLicenceSearch1.OnSubmittingValidLicenceId += ChangeControlsUIAfterLicenceShow;
            ucLicenceSearch1.OnChangingCurrentMode += ChangeControlsUIAfterModeChange;
            ucLicenceSearch1.OnReplaceButtonAbilityChanged += ChangeReplaceButtonAbility;
        }

        private void ChangeReplaceButtonAbility(bool isEnabled)
        {
            btnReplace.Enabled = isEnabled;
        }
        UserControls.UcLicenceSearch.Mode CurrentMode { get; set; }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeControlsUIAfterModeChange(UcLicenceSearch.Mode mode)
        {
            int applicationTypeId = mode == UcLicenceSearch.Mode.Damaged ? 4 : 3;
            ApplicationType applicationType = ApplicationType.Find(applicationTypeId);
            lblApplicationFees.Text = applicationType?.Fees.ToString();
        }

        private void ChangeControlsUIAfterLicenceShow(int licenceId)
        {
            lblOldLicenceId.Text = licenceId != -1 ? licenceId.ToString() : "???";
            CurrentLicence = ucLicenceSearch1.CurrentLicence;
            llShowLicenceHistory.Enabled = true;
            CurrentPerson = Person.FindByNationalNo(ucLicenceSearch1.GetNationalNumber());
        }

        private Person CurrentPerson { get; set; }
        private LicenceModel CurrentLicence { get; set; }

        private bool ReplaceLicence(ref int newLicenceId, ref int newApplicaitonId)
        {
            ApplicationModel application = new ApplicationModel
            {
                ApplicantPersonId = Driver.Find(ucLicenceSearch1.GetDriverId()) != null ?
                Driver.Find(ucLicenceSearch1.GetDriverId()).PersonId : -1,
                ApplicationTypeId = 3,
                ApplicationDate = DateTime.Now,
                LastStatusDate = DateTime.Now,
                ApplicationStatus = 3,
                PaidFees = decimal.Parse(lblApplicationFees.Text),
                CreatedByUserId = UserSession.LoggedInUser.ID
            };

            if (application.AddNewApplication(ref newApplicaitonId) && application.ApplicantPersonId != -1)
            {
                byte issueReason = (byte)(CurrentMode == UcLicenceSearch.Mode.Damaged ? 4 : 3);
                newLicenceId = CurrentLicence.ReplaceLicence(UserSession.LoggedInUser.ID, application.ID, issueReason);
                if (newLicenceId != -1)
                {
                    MessageBox.Show($"Licence Replaced Successfully with ID {CurrentLicence.ID}",
                        "Success",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Information);
                    ChangeReplaceButtonAbility(false);
                    return true;
                }
                else
                {
                    MessageBox.Show($"Something wrong happened while replacing licence", "Error",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error);
                }
            }
            return false;
        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            int newLicenceId = -1, newApplicaitonId = -1;
            if (CurrentLicence != null)
            {
                if (ReplaceLicence(ref newLicenceId, ref newApplicaitonId))
                {
                    lblReplacedLicenceId.Text = newLicenceId.ToString();
                    lblApplicationId.Text = newApplicaitonId.ToString();
                    llShowNewLiceence.Enabled = true;
                }
            }
        }

        private void FrmReplaceLicence_Load(object sender, EventArgs e)
        {
            int applicationTypeId = CurrentMode == UcLicenceSearch.Mode.Damaged ? 4 : 3;
            ApplicationType applicationType = ApplicationType.Find(applicationTypeId);
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = UserSession.LoggedInUser.UserName;
            lblApplicationFees.Text = applicationType?.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
        }

        private void LlShowNewLiceence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicence frm = new FrmShowLicence(CurrentLicence);
            frm.ShowDialog();
        }

        private void LlShowLicenceHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentPerson != null)
            {
                FrmLicenceHistory frm = new FrmLicenceHistory(CurrentPerson);
                frm.ShowDialog();
            }
        }
    }
}
