using DLMS.Forms;
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
    }
}
