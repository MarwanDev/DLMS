using DLMS_Business;
using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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

        public FrmAddEditUser(int userId)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            gbPersonSearch.Enabled = false;
            CurrentMode = Mode.Edit;
            User user = User.Find(userId);
            CurrentUser = user;
            CurrentPerson = Person.Find(CurrentUser.PersonID);
            ShowPersonData();
            UpdateUserLoginInfo();
        }

        private void TbPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private static Person CurrentPerson { get; set; }
        private static User CurrentUser { get; set; }

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
                FrmAddEditPerson frmAddEditPerson1 = new FrmAddEditPerson(CurrentPerson);
                frmAddEditPerson1.OnFormClosed += ReloadData;
                if (CurrentUser != null)
                {
                    if (cbFilter.SelectedIndex == 0)
                        MessageBox.Show($"A user with national number {CurrentPerson.NationalNo} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show($"A user with person Id {CurrentPerson.ID} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnNext.Enabled = true;
            }
            else
            {
                ClearPersonData();
                btnNext.Enabled = false;
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
            ucPersonInfo1.HideEditLinkLabel();
            ucPersonInfo1.Refresh();
        }

        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblFormHeader.Text = CurrentMode == Mode.Add ? "Add New User" : "Update User";
            timer1.Start();
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            btnPersonSearch.Enabled = !string.IsNullOrEmpty(tbSearch.Text.Trim());
            if (cbFilter.SelectedIndex == 1)
                tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, "[^0-9]", "");
        }

        private void TbSearch_MouseLeave(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Trim();
        }

        public enum Mode { Add, Edit };

        private bool IsValidUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return false;
            string userNamePattern = @"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$";
            return Regex.IsMatch(userName, userNamePattern) || !string.IsNullOrEmpty(userName);
        }

        public Mode CurrentMode { get; set; }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPerson != null && CurrentUser == null && CurrentMode == Mode.Add)
            {
                tcUserInfo.SelectedIndex = 1;
            }
            else if (CurrentUser != null && CurrentMode == Mode.Add)
            {
                if (
                MessageBox.Show("A user exists under the current person. Do you wanna update user details?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes
                    )
                {
                    CurrentMode = Mode.Edit;
                    lblFormHeader.Text = "Update User";
                    tcUserInfo.SelectedIndex = 1;
                    UpdateUserLoginInfo();
                }
            }
            else if (CurrentMode == Mode.Edit && CurrentUser != null)
            {
                tcUserInfo.SelectedIndex = 1;
            }
        }

        private void UpdateUserLoginInfo()
        {
            lblUserId.Text = CurrentUser.ID.ToString();
            tbUserName.Text = CurrentUser.UserName.ToString();
            tbPassword.Text = CurrentUser.Password;
            tbConfirmPassword.Text = CurrentUser.Password;
            cbIsActive.Checked = CurrentUser.IsActive;
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TcUserInfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabLoginInfo)
            {
                if (CurrentPerson == null || (CurrentPerson != null && CurrentUser != null && CurrentMode == Mode.Add))
                {
                    e.Cancel = true;
                }
            }
        }

        private void TbUserName_Leave(object sender, EventArgs e)
        {
            tbUserName.Text = tbUserName.Text.Trim();
            if (!IsValidUserName(tbUserName.Text))
            {
                SetError(tbUserName, "Please enter a valid username!");
            }
            else
            {
                SetError(tbUserName, "");
            }
            ChangeSaveBtnAbilityIfPossible();
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
                tbUserName.Text.Trim() != "" &&
                tbPassword.Text.Trim() != "" &&
                tbConfirmPassword.Text.Trim() != "";
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

        private void TbPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
                SetError(tbPassword, "Please enter a valid password!");
            else
                SetError(tbPassword, "");
            ChangeSaveBtnAbilityIfPossible();
        }

        private void TbConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPassword.Text) && tbConfirmPassword.Text != tbPassword.Text)
                SetError(tbConfirmPassword, "Password must match password confirmation!");
            else
                SetError(tbConfirmPassword, "");
            ChangeSaveBtnAbilityIfPossible();
        }

        private void SaveUpdate()
        {
            CurrentUser.PersonID = CurrentPerson.ID;
            CurrentUser.UserName = tbUserName.Text;
            CurrentUser.Password = tbPassword.Text;
            CurrentUser.IsActive = cbIsActive.Checked;
            if (CurrentUser.Save())
                MessageBox.Show($"User Updated Successfully", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
            else
                MessageBox.Show($"Something Went Wrong", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private User User { get; set; }

        private void SaveAddition()
        {
            User = new User
            {
                PersonID = CurrentPerson.ID,
                UserName = tbUserName.Text,
                Password = tbPassword.Text,
                IsActive = cbIsActive.Checked
            };
            if (User.Save())
            {
                MessageBox.Show($"User added Successfully with UserId {User.ID}", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                lblUserId.Text = User.ID.ToString();
                CurrentUser = User;
                CurrentMode = Mode.Edit;
                lblFormHeader.Text = "Update User";
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CurrentMode == Mode.Add)
                SaveAddition();
            else
                SaveUpdate();
        }

        private void ReloadCurrentPersonData()
        {
            ucPersonInfo1.SetPerson(CurrentPerson);
            ucPersonInfo1.SetAddress(CurrentPerson.Address);
            ucPersonInfo1.SetPersonId(CurrentPerson.ID.ToString());
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
            this.Refresh();
        }

        private void ReloadData()
        {
            CurrentPerson = ucPersonInfo1.CurrentPerson;
            ReloadCurrentPersonData();
            User user = User.FindByPersonId(Int32.Parse(ucPersonInfo1.GetPersonId()));
            if (user != null)
                CurrentUser = user;
        }

        private void FromAddEditPerson_DataBack(object sender, int PersonID)
        {
            CurrentPerson = Person.Find(PersonID);
            if (CurrentPerson != null)
            {
                ucPersonInfo1.SetPersonId(PersonID.ToString());
                ucPersonInfo1.ReloadData();
            }
        }

        private void BtnAddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson frmAddEditPerson = new FrmAddEditPerson
            {
                CurrentMode = FrmAddEditPerson.Mode.Add
            };
            frmAddEditPerson.DataBack += FromAddEditPerson_DataBack;
            frmAddEditPerson.ShowDialog();
        }

        public new event Action OnFormClosed;

        private void FrmAddEditUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentUser != null)
                Utils.CheckUserAvailabilityWithTimer(timer1, CurrentUser.ID, this);
        }
    }
}
