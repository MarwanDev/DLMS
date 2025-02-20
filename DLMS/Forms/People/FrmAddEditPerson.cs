using System;
using System.Windows.Forms;

namespace DLMS.Forms
{
    public partial class FrmAddEditPerson: Form
    {
        public FrmAddEditPerson()
        {
            InitializeComponent();
        }

        private void FrmAddEditPerson_Load(object sender, EventArgs e)
        {
            ucFormHeader1.SetTitleText("Add New Person");
            ucFormHeader1.SetIdLabelText("Person ID: ");
            ucFormHeader1.SetId(-1);
            ResetInputsPlacehodlers();
            SetMinDate();
        }

        private void ResetInputsPlacehodlers()
        {
            tbFirstName.Text = "First Name";
            tbSecondName.Text = "Second Name";
            tbThirdName.Text = "Third Name";
            tbLastName.Text = "Last Name";
            tbFirstName.ForeColor = System.Drawing.Color.LightGray;
            tbSecondName.ForeColor = System.Drawing.Color.LightGray;
            tbThirdName.ForeColor = System.Drawing.Color.LightGray;
            tbLastName.ForeColor = System.Drawing.Color.LightGray;
        }

        private void SetMinDate()
        {
            DateTime dtNow = DateTime.Now;
            DateTime minDate = dtNow.AddYears(-18);
            dtpDOB.MinDate = minDate;
        }

        private void Tb_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == tb.Tag.ToString())
                {
                    tb.ForeColor = System.Drawing.Color.Black;
                    tb.Text = "";
                }
            }
        }

        private void Tb_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.ForeColor = System.Drawing.Color.LightGray;
                tb.Text = tb.Tag.ToString();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
