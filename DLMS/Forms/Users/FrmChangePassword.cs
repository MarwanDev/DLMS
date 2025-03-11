using DLMS_Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace DLMS.Forms.Users
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        public FrmChangePassword(int userId)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            User user = User.Find(userId);
            CurrentUser = user;
            CurrentPerson = Person.Find(CurrentUser.PersonID);
            ShowPersonData();
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            if (CurrentUser != null)
            {
                ucPersonInfo1.SetPersonId(CurrentUser.PersonID.ToString());
                ucPersonInfo1.ReloadData();
                ucLoginInfo1.SetUserId(CurrentUser.ID);
                ucLoginInfo1.SetUserName(CurrentUser.UserName);
                ucLoginInfo1.SetIsActive(CurrentUser.IsActive);
            }
        }

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
            ucPersonInfo1.ShowEditLinkLabel();
            ucPersonInfo1.Refresh();
        }

        public new event Action OnFormClosed;

        private static Person CurrentPerson { get; set; }
        private static User CurrentUser { get; set; }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeSaveBtnAbilityIfPossible()
        {
            if (ShouldSaveBtnBeEnabled())
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private bool ShouldSaveBtnBeEnabled()
        {
            return GetActiveErrorCount() == 0 &&
                tbNewPassword.Text != "" &&
                tbConfirmPassword.Text != "" &&
                tbCurrentPassword.Text != "";
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (User.ChangePassword(CurrentUser.ID, tbNewPassword.Text))
                MessageBox.Show($"User Password Updated Successfully", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
            else
                MessageBox.Show($"Something Went Wrong", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void TbCurrentPassword_Leave(object sender, EventArgs e)
        {
            if (tbCurrentPassword.Text != User.GetUserPassword(CurrentUser.ID))
                SetError(tbCurrentPassword, "Please enter current password!");
            else
                SetError(tbCurrentPassword, "");
            ChangeSaveBtnAbilityIfPossible();
        }

        private void TbNewPassword_Leave(object sender, EventArgs e)
        {
            ChangeSaveBtnAbilityIfPossible();
        }

        private void TbConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (tbNewPassword.Text != tbConfirmPassword.Text)
                SetError(tbConfirmPassword, "New password and confirmation must match!");
            else
                SetError(tbConfirmPassword, "");
            ChangeSaveBtnAbilityIfPossible();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FrmChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }
    }
}
