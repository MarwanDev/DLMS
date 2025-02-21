using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DLMS.Properties;
using DLMS_Business;

namespace DLMS.Forms
{
    public partial class FrmAddEditPerson : Form
    {
        public FrmAddEditPerson()
        {
            InitializeComponent();
        }

        private readonly Dictionary<Control, string> errorTracker = new Dictionary<Control, string>();

        private void SetError(Control control, string errorMessage)
        {
            errorProvider1.SetError(control, errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
                errorTracker[control] = errorMessage;
            else
                errorTracker.Remove(control);
        }

        private int GetActiveErrorCount()
        {
            return errorTracker.Count;
        }


        private void FrmAddEditPerson_Load(object sender, EventArgs e)
        {
            ResetInputsPlacehodlers();
            SetMaxDate();
            FillCountriesCB();
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            pbPersonImage.Image = Resources.question_mark_96;
        }

        private void FillCountriesCB()
        {
            DataTable dataTable = Country.GetAllCountries();
            cbCountry.DataSource = dataTable;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
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

        private void SetMaxDate()
        {
            DateTime dtNow = DateTime.Now;
            dtpDOB.MaxDate = dtNow.AddYears(-18);
        }

        private void TbName_Enter(object sender, EventArgs e)
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void TbNationalNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void TbNationalNumber_Leave(object sender, EventArgs e)
        {
            if (Person.DoesPersonExist("NationalNo", tbNationalNumber.Text.Trim()) && tbNationalNumber.Text.Trim() != "")
            {
                SetError(tbNationalNumber, $"A person with the National Number {tbNationalNumber.Text} already exists");
            }
            else if (tbNationalNumber.Text.Trim() == "")
            {
                SetError(tbNationalNumber, $"Please enter your national number");
            }
            else
            {
                SetError(tbNationalNumber, "");
            }
            tbNationalNumber.Text = tbNationalNumber.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void TbName_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text.Trim() == "")
                {
                    tb.Text = tb.Tag.ToString();
                    tb.ForeColor = System.Drawing.Color.LightGray;
                    SetError(tb, $"Pleas enter a valid {tb.Tag}");
                }
                else
                    SetError(tb, "");
                tb.Text = tb.Text.Trim();
                ChangeSaveBtnAbilityIfPossible();
            }
        }

        private bool ShouldSaveBtnBeEnabled()
        {
            return GetActiveErrorCount() == 0 &&
                (rdbFemale.Checked || rdbMale.Checked) &&
                tbFirstName.Text.Trim() != "" &&
                tbSecondName.Text.Trim() != "" &&
                tbThirdName.Text.Trim() != "" &&
                tbLastName.Text.Trim() != "" &&
                tbNationalNumber.Text.Trim() != "" &&
                tbPhone.Text.Trim() != "" &&
                rtbAddress.Text.Trim() != "";
        }

        private void ChangeSaveBtnAbilityIfPossible()
        {
            if (ShouldSaveBtnBeEnabled())
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void RtbAddress_TextChanged(object sender, EventArgs e)
        {
        }

        private void TbEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void TbEmail_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(tbEmail.Text.Trim()) && tbEmail.Text.Trim() != "")
            {
                SetError(tbEmail, $"Please enter a valid email");
            }
            else
            {
                SetError(tbEmail, "");
            }
            tbEmail.Text = tbEmail.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void RtbAddress_Leave(object sender, EventArgs e)
        {
            if (rtbAddress.Text.Trim() == "")
                SetError(rtbAddress, "Please enter address");
            else
                SetError(rtbAddress, "");
            rtbAddress.Text = rtbAddress.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void TbPhone_TextChanged(object sender, EventArgs e)
        {
        }

        private void TbPhone_Leave(object sender, EventArgs e)
        {
            if (tbPhone.Text.Trim() == "")
                SetError(tbPhone, "Please enter a valid phone number");
            else
                SetError(tbPhone, "");
            tbPhone.Text = tbPhone.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void RdbGender_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = rdbFemale.Checked ? Resources.Female_512 : Resources.Male_512;
            ChangeSaveBtnAbilityIfPossible();
        }
    }
}
