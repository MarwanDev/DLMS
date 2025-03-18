using DLMS_Business;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using DLMS.UserControls;

namespace DLMS.Forms.Users
{
    public partial class FrmAddEditUser : Form
    {
        public FrmAddEditUser()
        {
            InitializeForm();
        }

        public FrmAddEditUser(int userId)
        {
            InitializeForm();
            ucPersonSearch1.ChangePersonSearchGroupBoxAbility(false);
            CurrentMode = Mode.Edit;
            User user = User.Find(userId);
            CurrentUser = user;
            CurrentPerson = Person.Find(CurrentUser.PersonID);
            ucPersonSearch1.SetPerson(CurrentPerson);
            ucPersonSearch1.ShowPersonData();
            UpdateUserLoginInfo();
        }

        private void InitializeForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            ucPersonSearch1.OnNextButtonAbilityChanged += UcPersonSearch1_OnNextButtonAbilityChanged;
            ucPersonSearch1.OnPersonIsShown += UcPersonSearch1_OnPersonIsShown;
            ucPersonSearch1.OnPersonDataReloaded += HandlePersonDataReloaded;
            ucPersonSearch1.OnPersonAdded += HandlePersonAdded;
        }

        private void HandlePersonAdded(bool isPersonAdded = true)
        {
            CurrentUser = isPersonAdded ? null : CurrentUser;
        }

        private void HandlePersonDataReloaded(int personId)
        {
            User user = User.FindByPersonId(personId);
            if (user != null)
                CurrentUser = user;
        }

        private void UcPersonSearch1_OnPersonIsShown(bool isSuccessful = true)
        {
            if (isSuccessful)
            {
                CurrentPerson = UcPersonSearch.CurrentPerson;
                CurrentUser = User.FindByPersonId(CurrentPerson.ID);
                if (CurrentUser != null)
                {
                    if (ucPersonSearch1.GetFilterIndex() == 0)
                        MessageBox.Show($"A user with national number {CurrentPerson.NationalNo} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show($"A user with person Id {CurrentPerson.ID} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ChangeSaveBtnAbilityIfPossible();
            }
        }

        private void UcPersonSearch1_OnNextButtonAbilityChanged(bool isEnabled)
        {
            btnNext.Enabled = isEnabled;
        }

        private void TbPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private static Person CurrentPerson { get; set; }
        private static User CurrentUser { get; set; }

        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            ucPersonSearch1.InitializeFilterComboBox();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblFormHeader.Text = CurrentMode == Mode.Add ? "Add New User" : "Update User";
            this.Text = CurrentMode == Mode.Add ? "Add New User" : "Update User";
            ChangeSaveBtnAbilityIfPossible();
            timer1.Start();
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

        private void SaveAddition()
        {
            User user = new User
            {
                PersonID = CurrentPerson.ID,
                UserName = tbUserName.Text,
                Password = tbPassword.Text,
                IsActive = cbIsActive.Checked
            };
            if (user.Save())
            {
                MessageBox.Show($"User added Successfully with UserId {user.ID}", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                lblUserId.Text = user.ID.ToString();
                CurrentUser = user;
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
