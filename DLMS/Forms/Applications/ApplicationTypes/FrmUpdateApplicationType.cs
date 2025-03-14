using DLMS_Business;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DLMS.Forms.Applications.ApplicationTypes
{
    public partial class FrmUpdateApplicationType : Form
    {
        public FrmUpdateApplicationType()
        {
            InitializeComponent();
        }

        public FrmUpdateApplicationType(ApplicationType applicationType)
        {
            InitializeComponent();
            CurrentApplicationType = applicationType;
            MofidyControlsAccordingToApplicationType(applicationType);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void MofidyControlsAccordingToApplicationType(ApplicationType applicationType)
        {
            lblId.Text = applicationType.ID.ToString();
            tbFees.Text = applicationType.Fees.ToString();
            tbTitle.Text = applicationType.Title.ToString();
        }

        private void FrmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public new event Action OnFormClosed;

        private void FrmUpdateApplicationType_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbFees_TextChanged(object sender, EventArgs e)
        {
            string text = tbFees.Text;

            text = System.Text.RegularExpressions.Regex.Replace(text, "[^0-9.]", "");

            int dotCount = text.Count(c => c == '.');
            if (dotCount > 1)
            {
                int firstDotIndex = text.IndexOf('.');
                text = text.Substring(0, firstDotIndex + 1) + text.Substring(firstDotIndex + 1).Replace(".", "");
            }

            if (text == ".")
            {
                text = "0.";
            }

            tbFees.Text = text;
            tbFees.SelectionStart = text.Length;
        }

        private void TbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' && (sender is TextBox textBox && !textBox.Text.Contains(".")))
            {
                return;
            }

            e.Handled = true;
        }

        ApplicationType CurrentApplicationType { get; set; }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CurrentApplicationType.Title = tbTitle.Text.Trim();
            CurrentApplicationType.Fees = Convert.ToDecimal(tbFees.Text);
            if (CurrentApplicationType.Save())
                MessageBox.Show("Application Type Updated Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show("Somehting wrong happened!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
