using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            if (!IsLoggedInUser())
            {
                InitializeComponent();
                this.Show();
            }
            else
            {
                UserSession.LoggedInUser = LoggedInUser;
                UserSession.IsLoggedIn = true;
                FrmMain frmMain = new FrmMain();
                frmMain.OnFormClosed += HandleMainFormClose;
                frmMain.ShowDialog();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HandleMainFormClose()
        {
            if (!IsLoggedInUser())
            {
                this.Controls.Clear();
                InitializeComponent();
                this.Show();
            }
            else
            {
                if (!Properties.Settings.Default.RememberMe)
                {
                    Properties.Settings.Default.SavedUsername = "";
                    Properties.Settings.Default.SavedPassword = "";
                    Properties.Settings.Default.Save();
                }
                this.Close();
            }
        }

        private void SaveLoggedInUserData(User user)
        {
            UserSession.LoggedInUser = user;
            UserSession.IsLoggedIn = true;
        }

        private void ShowMainForm()
        {
            FrmMain frmMain = new FrmMain();
            frmMain.OnFormClosed += HandleMainFormClose;
            frmMain.Show();
            this.Hide();
        }

        private void SaveLoginDataInSettings(User user)
        {
            Properties.Settings.Default.SavedUsername = user.UserName;
            Properties.Settings.Default.SavedPassword = user.Password;
            Properties.Settings.Default.Save();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            User user = User.FindByAuth(tbUsername.Text.Trim(), tbPassword.Text);
            if (user != null)
            {
                if (user.IsActive)
                {
                    SaveLoggedInUserData(user);
                    ShowMainForm();
                    SaveLoginDataInSettings(user);
                }
                else
                {
                    MessageBox.Show("Please make sure that the user you're trying to login with is activated!",
                        "Error",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid credentials!",
                    "Incorrect username or password",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
            }
        }

        static bool IsLoggedInUser()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedUsername) &&
                !string.IsNullOrEmpty(Properties.Settings.Default.SavedPassword) &&
                Properties.Settings.Default.RememberMe)
            {
                LoggedInUser = User.FindByAuth(Properties.Settings.Default.SavedUsername, Properties.Settings.Default.SavedPassword);
                return LoggedInUser != null && LoggedInUser.IsActive;
            }
            return false;
        }

        private static User LoggedInUser { get; set; }

        private void CbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberMe = cbRememberMe.Checked;
            Properties.Settings.Default.Save();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            cbRememberMe.Checked = Properties.Settings.Default.RememberMe;
        }
    }
}
