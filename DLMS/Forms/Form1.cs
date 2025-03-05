using DLMS.Forms;
using DLMS.Forms.Users;
using System;
using System.Windows.Forms;

namespace DLMS
{
    public partial class frmMain: Form
    {
        public frmMain()
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
    }
}
