using DLMS.Properties;
using DLMS_Business;
using DLMS_Business.Licence;
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

        public enum Mode { InternationlLicence, Renew, Lost, Damaged, DetainReleased, ReleaseDetained };
        public Mode CurrentMode { get; set; } = Mode.InternationlLicence;

        private void ValidateLicenceId(LicenceModel licence)
        {
            if (LicenceModel.DoesInternationalLicenceExistWithLocalLicenceId(Int32.Parse(tbSearch.Text.Trim())) &&
                CurrentMode == Mode.InternationlLicence)
            {
                MessageBox.Show("An international licence already exists under the same local licence",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeIssueButtonAbility(false);
                ModifyControlsUIAccordingToLicence(licence);
                SubmitValidLicenceId(-1);
                return;
            }
            ModifyControlsUIAccordingToLicence(licence);
            if (LicenceModel.GetLicenceClassId(licence.ID) != 3 && CurrentMode == Mode.InternationlLicence)
            {
                MessageBox.Show($"The local licence with id {licence.ID} is not valid for international licence!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (CurrentMode == Mode.InternationlLicence)
                    ChangeIssueButtonAbility(false);
                if (CurrentMode == Mode.Lost || CurrentMode == Mode.Damaged)
                    ChangeReplaceButtonAbility(false);
                SubmitValidLicenceId(-1);
            }

            if (licence.ExpirationDate < DateTime.Now &&
                (CurrentMode == Mode.InternationlLicence ||
                CurrentMode == Mode.Lost ||
                CurrentMode == Mode.Damaged ||
                CurrentMode == Mode.DetainReleased ||
                CurrentMode == Mode.ReleaseDetained))
            {
                MessageBox.Show($"The local licence with id {licence.ID} is expired!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (CurrentMode == Mode.Lost || CurrentMode == Mode.Damaged)
                    ChangeReplaceButtonAbility(false);
                if (CurrentMode == Mode.InternationlLicence)
                    ChangeIssueButtonAbility(false);
                if (CurrentMode == Mode.ReleaseDetained)
                    ChangeReleaseButtonAbility(false);
                if (CurrentMode == Mode.DetainReleased)
                    ChangeDetainButtonAbility(false);
                SubmitValidLicenceId(-1);
                return;
            }

            if (licence.ExpirationDate > DateTime.Now && CurrentMode == Mode.Renew)
            {
                MessageBox.Show($"The local licence with id {licence.ID} is not expired!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeRenewButtonAbility(false);
                SubmitValidLicenceId(-1);
                return;
            }

            if (DetainedLicence.IsLicenceDetained(licence.ID) && CurrentMode == Mode.DetainReleased)
            {
                MessageBox.Show($"The local licence with id {licence.ID} is already detained!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeDetainButtonAbility(false);
                SubmitValidLicenceId(-1);
                return;
            }

            if (!DetainedLicence.IsLicenceDetained(licence.ID) && CurrentMode == Mode.ReleaseDetained)
            {
                MessageBox.Show($"The local licence with id {licence.ID} is not detained!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ChangeReleaseButtonAbility(false);
                SubmitValidLicenceId(-1);
                return;
            }

            if (licence.IsActive)
            {
                if (CurrentMode == Mode.InternationlLicence)
                    ChangeIssueButtonAbility();
                if (CurrentMode == Mode.Renew)
                    ChangeRenewButtonAbility();
                if (CurrentMode == Mode.Lost || CurrentMode == Mode.Damaged)
                    ChangeReplaceButtonAbility();
                if (CurrentMode == Mode.DetainReleased)
                    ChangeDetainButtonAbility();
                if (CurrentMode == Mode.ReleaseDetained)
                    ChangeReleaseButtonAbility();
                CurrentLicence = licence;
                SubmitValidLicenceId(licence.ID);
            }
            else
            {
                MessageBox.Show($"The local licence with id {licence.ID} is not active!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (CurrentMode == Mode.InternationlLicence)
                    ChangeIssueButtonAbility(false);
                if (CurrentMode == Mode.Renew)
                    ChangeRenewButtonAbility(false);
                if (CurrentMode == Mode.Lost || CurrentMode == Mode.Damaged)
                    ChangeReplaceButtonAbility(false);
                if (CurrentMode == Mode.DetainReleased)
                    ChangeDetainButtonAbility(false);
                if (CurrentMode == Mode.ReleaseDetained)
                    ChangeReleaseButtonAbility(false);
            }
        }

        public LicenceModel CurrentLicence { get; private set; }

        private void BtnLicenceSearch_Click(object sender, EventArgs e)
        {
            LicenceModel licence = LicenceModel.Find(Int32.Parse(tbSearch.Text.Trim()));
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

        public int GetDriverId()
        {
            return Int32.Parse(lblDriverId.Text);
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
        public event Action<bool> OnRenewButtonAbilityChanged;
        public event Action<bool> OnReplaceButtonAbilityChanged;
        public event Action<bool> OnDetainButtonAbilityChanged;
        public event Action<bool> OnReleaseeButtonAbilityChanged;
        public event Action<int> OnSubmittingValidLicenceId;
        public event Action<Mode> OnChangingCurrentMode;

        private void ChangeCurrentMode()
        {
            OnChangingCurrentMode?.Invoke(CurrentMode);
        }

        private void ChangeReleaseButtonAbility(bool isEnabled = true)
        {
            OnReleaseeButtonAbilityChanged?.Invoke(isEnabled);
        }

        private void ChangeDetainButtonAbility(bool isEnabled = true)
        {
            OnDetainButtonAbilityChanged?.Invoke(isEnabled);
        }

        private void ChangeIssueButtonAbility(bool isEnabled = true)
        {
            OnIssueButtonAbilityChanged?.Invoke(isEnabled);
        }

        private void ChangeReplaceButtonAbility(bool isEnabled = true)
        {
            OnReplaceButtonAbilityChanged?.Invoke(isEnabled);
        }

        private void ChangeRenewButtonAbility(bool isEnabled = true)
        {
            OnRenewButtonAbilityChanged?.Invoke(isEnabled);
        }

        public string GetNationalNumber()
        {
            return lblNationalNo.Text;
        }

        private void SubmitValidLicenceId(int licenceId)
        {
            OnSubmittingValidLicenceId?.Invoke(licenceId);
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

        private void RdbLicenceMode_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = rdbLost.Checked ? Mode.Lost : Mode.Damaged;
            ChangeCurrentMode();
        }

        private void UcLicenceSearch_Load(object sender, EventArgs e)
        {
            gbReplacementFor.Visible = CurrentMode == Mode.Lost || CurrentMode == Mode.Damaged;
        }
    }
}
