using DLMS_Business;
using DLMS_Business.Application;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DLMS.Forms.Licence
{
    public partial class FrmRenewLicence : Form
    {
        public FrmRenewLicence()
        {
            InitializeComponent();
            ucLicenceSearch1.CurrentMode = UserControls.UcLicenceSearch.Mode.Renew;
            ucLicenceSearch1.OnSubmittingValidLicenceId += ChangeControlsUIAfterLicenceShow;
            ucLicenceSearch1.OnRenewButtonAbilityChanged += ChangeRenewBtnAbiblity;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeRenewBtnAbiblity(bool isEnabled)
        {
            btnRenew.Enabled = isEnabled;
        }

        private void ChangeControlsUIAfterLicenceShow(int licenceId)
        {
            lblOldLicenceId.Text = licenceId != -1 ? licenceId.ToString() : "???";
            CurrentLicence = ucLicenceSearch1.CurrentLicence;
            llShowLicenceHistory.Enabled = true;
            CurrentPerson = Person.FindByNationalNo(ucLicenceSearch1.GetNationalNumber());
        }

        private LicenceModel CurrentLicence { get; set; }

        private bool RenewLicence(ref int newLicenceId, ref int newApplicaitonId)
        {
            ApplicationModel application = new ApplicationModel
            {
                ApplicantPersonId = Driver.Find(ucLicenceSearch1.GetDriverId()) != null ?
                Driver.Find(ucLicenceSearch1.GetDriverId()).PersonId : -1,
                ApplicationTypeId = 3,
                ApplicationDate = DateTime.Now,
                LastStatusDate = DateTime.Now,
                ApplicationStatus = 3,
                CreatedByUserId = UserSession.LoggedInUser.ID
            };
            if (application.AddNewApplication(ref newApplicaitonId) && application.ApplicantPersonId != -1)
            {
                newLicenceId = CurrentLicence.RenewLicence(UserSession.LoggedInUser.ID, application.ID, rtbNotes.Text);
                if (newLicenceId != -1)
                {
                    MessageBox.Show($"Licence Renewed Successfully with ID {CurrentLicence.ID}",
                        "Success",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Information);
                    ChangeRenewBtnAbiblity(false);
                    return true;
                }
                else
                {
                    MessageBox.Show($"Something wrong happened while renewing licence", "Error",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error);
                }
            }
            return false;
        }

        private void BtnRenew_Click(object sender, EventArgs e)
        {
            int newLicenceId = -1, newApplicaitonId = -1;
            if (CurrentLicence != null)
            {
                if (RenewLicence(ref newLicenceId, ref newApplicaitonId))
                {
                    lblRenewedLicenceId.Text = newLicenceId.ToString();
                    lblApplicationId.Text = newApplicaitonId.ToString();
                    lblLicenceFees.Text = CurrentLicence.PaidFees.ToString();
                    llShowNewLiceence.Enabled = true;
                    lblTotalFees.Text = ((decimal.Parse(lblApplicationFees.Text)) +
                        (decimal.Parse(lblLicenceFees.Text))).ToString();
                }
            }
        }

        private void FrmRenewLicence_Load(object sender, EventArgs e)
        {
            ApplicationType applicationType = ApplicationType.Find(2);
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblCreatedBy.Text = UserSession.LoggedInUser.UserName;
            lblApplicationFees.Text = applicationType?.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
        }

        private Person CurrentPerson {  get; set; }

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
    }
}
