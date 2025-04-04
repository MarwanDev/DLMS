using DLMS.Forms;
using DLMS.Forms.Applications.ApplicationTypes;
using DLMS.Forms.Applications.LocalDrivingLicenceApplications;
using DLMS.Forms.Licence;
using DLMS.Forms.Licence.DetainRelease;
using DLMS.Forms.Licence.Local;
using DLMS.Forms.People;
using DLMS.Forms.Tests.TestTypes;
using DLMS.Forms.Users;
using DLMS_Business;
using System;
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
            frmPeople.OnFormClosed += HandleManagementFormClose;
            frmPeople.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void ManageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageUsers frmManageUsers = new FrmManageUsers();
            frmManageUsers.OnFormClosed += HandleManagementFormClose;
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
            FrmShowUserDetails frm = new FrmShowUserDetails(UserSession.LoggedInUser.ID);
            frm.ShowDialog();
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(UserSession.LoggedInUser.ID);
            frm.ShowDialog();
        }

        private void HandleManagementFormClose()
        {
            Business.DisableSorting();
        }

        private void ManageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes frm = new FrmManageApplicationTypes();
            frm.OnFormClosed += HandleManagementFormClose;
            frm.ShowDialog();
        }

        private void ManageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageTestType frm = new FrmManageTestType();
            frm.OnFormClosed += HandleManagementFormClose;
            frm.ShowDialog();
        }

        private void LocalLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditLocalDrivingLicenceApplication frm = new FrmAddEditLocalDrivingLicenceApplication();
            frm.ShowDialog();
        }

        private void LocalDrivingLicenceApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageLocalDLApplications frm = new FrmManageLocalDLApplications();
            frm.ShowDialog();
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageDrivers frm = new FrmManageDrivers();
            frm.ShowDialog();
        }

        private void InternationalLicenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmIssueInternationalLicence frm = new FrmIssueInternationalLicence();
            frm.ShowDialog();
        }

        private void InternationalDrivingLicenceApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageInternationalLicences frm = new FrmManageInternationalLicences();
            frm.ShowDialog();
        }

        private void RenewDrivingLicenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRenewLicence frm = new FrmRenewLicence();
            frm.ShowDialog();
        }

        private void ReplacementForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReplaceLicence frm = new FrmReplaceLicence();
            frm.ShowDialog();
        }

        private void DetainLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetainLicence frm = new FrmDetainLicence();
            frm.ShowDialog();
        }
    }
}
