using DLMS.Forms;
using DLMS.Forms.Applications.ApplicationTypes;
using DLMS.Forms.Tests.TestTypes;
using DLMS.Forms.Users;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DLMS
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void PeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPeople frmPeople = new FrmPeople();
            frmPeople.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void ManageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageUsers frmManageUsers = new FrmManageUsers();
            frmManageUsers.ShowDialog();
        }

        public new event Action OnFormClosed;

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void ClearSavedUserData()
        {
            Properties.Settings.Default.SavedUsername = "";
            Properties.Settings.Default.SavedPassword = "";
            Properties.Settings.Default.Save();
        }

        private void ClearUserSession()
        {
            UserSession.LoggedInUser = null;
            UserSession.IsLoggedIn = false;
        }

        private void SignOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearSavedUserData();
            ClearUserSession();
            this.Close();
        }

        private void CurrentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowUserDetails frmShowUserDetails = new FrmShowUserDetails(UserSession.LoggedInUser.ID);
            frmShowUserDetails.ShowDialog();
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword(UserSession.LoggedInUser.ID);
            frmChangePassword.ShowDialog();
        }

        private void ManageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes frmManageApplicationTypes = new FrmManageApplicationTypes();
            frmManageApplicationTypes.ShowDialog();
        }

        private void ManageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageTestType frmManageTestType = new FrmManageTestType();
            frmManageTestType.ShowDialog();
        }
    }
}
