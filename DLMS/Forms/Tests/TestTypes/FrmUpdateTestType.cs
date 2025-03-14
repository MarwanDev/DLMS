using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.Forms.Tests.TestTypes
{
    public partial class FrmUpdateTestType: Form
    {
        public FrmUpdateTestType()
        {
            InitializeComponent();
        }

        private TestType CurrentTestType {  get; set; }

        public FrmUpdateTestType(TestType testType)
        {
            InitializeComponent();
            CurrentTestType = testType;
            MofidyControlsAccordingToTestType(testType);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void MofidyControlsAccordingToTestType(TestType tesyType)
        {
            lblId.Text = tesyType.ID.ToString();
            tbFees.Text = tesyType.Fees.ToString();
            tbTitle.Text = tesyType.Title;
            tbDescription.Text = tesyType.Description;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public new event Action OnFormClosed;

        private void FrmUpdateTestType_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FrmUpdateTestType_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CurrentTestType.Title = tbTitle.Text.Trim();
            CurrentTestType.Description = tbDescription.Text.Trim();
            CurrentTestType.Fees = Convert.ToDecimal(tbFees.Text);
            if (CurrentTestType.Save())
                MessageBox.Show("Test Type Updated Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show("Somehting wrong happened!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void TbFees_TextChanged(object sender, EventArgs e)
        {
            Utils.HandleTbMoneyTextChanged(tbFees);
        }

        private void TbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.HandleTbMoneyKeyPress(tbFees, e);
        }
    }
}
