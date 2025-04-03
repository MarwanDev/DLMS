using DLMS.Properties;
using DLMS_Business;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DLMS.Forms.Licence
{
    public partial class FrmShowInternationalLicence : Form
    {
        public FrmShowInternationalLicence()
        {
            InitializeComponent();
        }

        public FrmShowInternationalLicence(LicenceModel licence)
        {
            InitializeComponent();
            CurrentLicence = licence;
            ChangeControlsUIAccordingToLicence();
        }

        private LicenceModel CurrentLicence { get; set; }

        public new event Action OnFormClosed;

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeControlsUIAccordingToLicence()
        {
            lblName.Text = CurrentLicence.FullName;
            lblInternationalLicenceId.Text = CurrentLicence.ID.ToString();
            lblLicenceId.Text = CurrentLicence.LocalLicenceId.ToString();
            lblApplicationId.Text = CurrentLicence.ApplicationId.ToString();
            lblNatinalNo.Text = CurrentLicence.NationalNo;
            lblGender.Text = CurrentLicence.Gender;
            lblIssueDate.Text = CurrentLicence.IssueDate.ToShortDateString();
            lblExpDate.Text = CurrentLicence.IssueDate.ToShortDateString();
            lblIsActive.Text = CurrentLicence.IsActive ? "Yes" : "No";
            lblDOB.Text = CurrentLicence.IssueDate.ToShortDateString();
            lblDriverId.Text = CurrentLicence.DriverId.ToString();
            pbPersonImage.Image = !string.IsNullOrEmpty(CurrentLicence.ImagePath) && File.Exists(CurrentLicence.ImagePath) ?
               Image.FromFile(CurrentLicence.ImagePath) : CurrentLicence.Gender == "Female" ?
               Resources.Female_512 : Resources.Male_512;
        }

        private void FrmShowInternationalLicence_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }
    }
}
