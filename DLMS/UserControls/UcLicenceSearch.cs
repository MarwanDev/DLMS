using DLMS.Properties;
using DLMS_Business;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DLMS.UserControls
{
    public partial class UcLicenceSearch : UserControl
    {
        public UcLicenceSearch()
        {
            InitializeComponent();
        }

        private void CheckInternationalLicenceAvailability(LicenceModel licence)
        {
            if (LicenceModel.DoesInternationalLicenceExistWithLocalLicenceId(Int32.Parse(tbSearch.Text.Trim())))
            {
                MessageBox.Show("An international licence already exists under the same local licence",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeIssueButtonAbility(false);
                ModifyControlsUIAccordingToLicence(licence);
                return;
            }
        }

        private void ValidateLicenceId(LicenceModel licence)
        {
            ModifyControlsUIAccordingToLicence(licence);
            if (LicenceModel.GetLicencClassId(licence.ID) != 3)
            {
                MessageBox.Show($"The local licence with id {licence.ID} is not valid for international licence!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeIssueButtonAbility(false);
            }

            if (licence.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"The local licence with id {licence.ID} is expired!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeIssueButtonAbility(false);
                return;
            }

            if (licence.IsActive)
                ChangeIssueButtonAbility();
            else
            {
                MessageBox.Show($"The local licence with id {licence.ID} is not active!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeIssueButtonAbility(false);
            }
        }

        private void BtnLicenceSearch_Click(object sender, EventArgs e)
        {
            LicenceModel licence = LicenceModel.Find(Int32.Parse(tbSearch.Text.Trim()));
            CheckInternationalLicenceAvailability(licence);
            if (licence != null)
                ValidateLicenceId(licence);
            else
            {
                MessageBox.Show("Please enter a valid licence ID!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeIssueButtonAbility(false);
            }
        }

        private void ModifyControlsUIAccordingToLicence(LicenceModel licence)
        {
            lblClassName.Text = licence.ClassName;
            lblName.Text = licence.FullName;
            lblNationalNo.Text = licence.NationalNo;
            lblLicenceId.Text = licence.ID.ToString();
            lblGender.Text = licence.Gender;
            lblIssueDate.Text = licence.IssueDate.ToShortDateString();
            lblIssueReason.Text = licence.IssueReason == 1 ? "First Time" : "Not First Time";
            lblNotes.Text = !string.IsNullOrEmpty(licence.Notes) ? licence.Notes : "No Notes";
            lblIsActive.Text = licence.IsActive ? "Yes" : "No";
            lblDOB.Text = licence.DateOfBirth.ToShortDateString();
            lblDriverId.Text = licence.DriverId.ToString();
            lblExpDate.Text = licence.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = licence.IssueReason == 1 ? "No" : "Yes";
            pbPersonImage.Image = !string.IsNullOrEmpty(licence.ImagePath) && File.Exists(licence.ImagePath) ?
               Image.FromFile(licence.ImagePath) : licence.Gender == "Female" ?
               Resources.Female_512 : Resources.Male_512;
        }

        public event Action<bool> OnIssueButtonAbilityChanged;

        private void ChangeIssueButtonAbility(bool isEnabled = true)
        {
            OnIssueButtonAbilityChanged?.Invoke(isEnabled);
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "\u007f")
                tbSearch.Clear();
            tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, "[^0-9]", "");
            btnLicenceSearch.Enabled = tbSearch.Text.Trim() != "";
        }

        private void TbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
