using DLMS_Business;
using System;
using System.Windows.Forms;
using System.IO;

namespace DLMS.Forms.Users
{
    public partial class FrmAddEditUser : Form
    {
        public FrmAddEditUser()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void TbPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private Person CurrentPerson { get; set; }
        private User CurrentUser { get; set; }

        private void ShowPersonData()
        {
            ucPersonInfo1.SetPerson(CurrentPerson);
            ucPersonInfo1.SetPersonId(CurrentPerson.ID.ToString());
            ucPersonInfo1.SetAddress(CurrentPerson.Address);
            ucPersonInfo1.SetPersonName(CurrentPerson.FirstName + " " +
                CurrentPerson.SecondName + " " +
                CurrentPerson.ThirdName + " " +
                CurrentPerson.LastName);
            ucPersonInfo1.SetNationalNo(CurrentPerson.NationalNo);
            ucPersonInfo1.SetGender(CurrentPerson.Gender == 0 ? "Female" : "Male");
            ucPersonInfo1.SetEmail(CurrentPerson.Email);
            ucPersonInfo1.SetCountry(CurrentPerson.Country);
            ucPersonInfo1.SetDateOfBirth(CurrentPerson.DateOfBirth.Date.ToString());
            ucPersonInfo1.SetPhone(CurrentPerson.Phone);
            if (!string.IsNullOrEmpty(CurrentPerson.ImagePath) && File.Exists(CurrentPerson.ImagePath))
            {
                ucPersonInfo1.SetImage(CurrentPerson.ImagePath);
                ucPersonInfo1.RefreshImageBox();
            }
            else
            {
                ucPersonInfo1.SetImageForNoImageUser();
            }
            ucPersonInfo1.Refresh();
        }

        private void BtnPersonSearch_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
                CurrentPerson = Person.FindByNationalNo(tbSearch.Text.Trim());
            else
                CurrentPerson = Person.Find(Int32.Parse(tbSearch.Text.Trim()));
            if (CurrentPerson != null)
            {
                ShowPersonData();
                CurrentUser = User.FindByPersonId(CurrentPerson.ID);
                if (CurrentUser != null)
                {
                    if (cbFilter.SelectedIndex == 0)
                        MessageBox.Show($"A user with national number {CurrentPerson.NationalNo} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show($"A user with person Id {CurrentPerson.ID} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ClearPersonData();
                if (cbFilter.SelectedIndex == 0)
                    MessageBox.Show($"No person was found with national number {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"No person was found with person Id {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPersonData()
        {
            ucPersonInfo1.SetPerson(null);
            ucPersonInfo1.SetPersonId("???");
            ucPersonInfo1.SetAddress("???");
            ucPersonInfo1.SetPersonName("???");
            ucPersonInfo1.SetNationalNo("???");
            ucPersonInfo1.SetGender("???");
            ucPersonInfo1.SetEmail("???");
            ucPersonInfo1.SetCountry("???");
            ucPersonInfo1.SetDateOfBirth("???");
            ucPersonInfo1.SetPhone("???");
            ucPersonInfo1.SetImageForNoData();
            ucPersonInfo1.Refresh();
        }

        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            btnPersonSearch.Enabled = !string.IsNullOrEmpty(tbSearch.Text.Trim());
            if(cbFilter.SelectedIndex == 1)
                tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, "[^0-9]", "");
        }

        private void TbSearch_MouseLeave(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Trim();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {

        }

        private void TbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
