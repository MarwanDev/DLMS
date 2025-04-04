using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.Forms.Licence.DetainRelease
{
    public partial class FrmDetainLicence : Form
    {
        public FrmDetainLicence()
        {
            InitializeComponent();
            ucLicenceSearch1.CurrentMode = UserControls.UcLicenceSearch.Mode.DetainReleased;
            ucLicenceSearch1.OnSubmittingValidLicenceId += ChangeControlsUIAfterLicenceShow;
            ucLicenceSearch1.OnDetainButtonAbilityChanged += ChangeDetainBtnAbiblity;
        }

        private void ChangeControlsUIAfterLicenceShow(int licenceId)
        {
            lblLicenceId.Text = licenceId != -1 ? licenceId.ToString() : "???";
            CurrentLicence = ucLicenceSearch1.CurrentLicence;
            llShowLicenceHistory.Enabled = true;
            CurrentPerson = Person.FindByNationalNo(ucLicenceSearch1.GetNationalNumber());
        }

        private void ChangeDetainBtnAbiblity(bool isEnabled)
        {
            btnDetain.Enabled = isEnabled;
        }

        private Person CurrentPerson { get; set; }
        private LicenceModel CurrentLicence { get; set; }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbFine_TextChanged(object sender, EventArgs e)
        {
            if (tbFine.Text == "\u007f")
                tbFine.Clear();

            tbFine.Text = System.Text.RegularExpressions.Regex.Replace(tbFine.Text, @"[^0-9.]", "");

            int dotIndex = tbFine.Text.IndexOf('.');
            if (dotIndex != -1)
            {
                tbFine.Text = tbFine.Text.Substring(0, dotIndex + 1) +
                                tbFine.Text.Substring(dotIndex + 1).Replace(".", "");
            }

            tbFine.SelectionStart = tbFine.Text.Length;
        }

        private void TbFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar == '.' && (sender is TextBox tb && !tb.Text.Contains(".")))
            {
                e.Handled = false;
                return;
            }

            e.Handled = true;
        }

        private void BtnDetain_Click(object sender, EventArgs e)
        {
            CurrentLicence.DetainDate = DateTime.Now;
            CurrentLicence.FineFees = !string.IsNullOrEmpty(tbFine.Text) ? decimal.Parse(tbFine.Text) : 0;
            CurrentLicence.DetainedByUserId = UserSession.LoggedInUser.ID;
            CurrentLicence.IsReleased = false;
            if (CurrentLicence.DetainLicecne())
            {
                MessageBox.Show($"Licence Detained Successfully with ID {CurrentLicence.DetainId}",
                    "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                    ChangeDetainBtnAbiblity(false);
                lblDetainedId.Text = CurrentLicence.DetainId.ToString();
                llShowNewLiceence.Enabled = true;
            }
            else
            {
                MessageBox.Show($"Something wrong happened while Detaining licence", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
            }
        }

        private void FrmDetainLicence_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
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
    }
}
