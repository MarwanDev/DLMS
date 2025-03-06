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
                if (cbFilter.SelectedIndex == 0)
                    MessageBox.Show($"No person was found with national number {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"No person was found with person Id {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            btnPersonSearch.Enabled = !string.IsNullOrEmpty(tbSearch.Text.Trim());
        }

        private void TbSearch_MouseLeave(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Trim();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {

        }
    }
}
