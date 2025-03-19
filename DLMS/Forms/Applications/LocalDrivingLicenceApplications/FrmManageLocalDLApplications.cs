using DLMS_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DLMS.Forms.Applications.LocalDrivingLicenceApplications
{
    public partial class FrmManageLocalDLApplications : Form
    {
        public FrmManageLocalDLApplications()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void FrmManageLocalDLApplications_Load(object sender, EventArgs e)
        {
            GetAllLocalDLApplicationsInDGV();
            dgvLocalDLApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cbFilter.SelectedIndex = 0;
        }

        private enum Mode { All, Filter };

        private static Mode CurrentMode;

        private void GetAllLocalDLApplicationsInDGV()
        {
            DataTable localDLApplications = LocalDLApplication.GetAllLocalDLApplications();
            dgvLocalDLApplications.DataSource = localDLApplications;
            Utils.DisableDGVColumnSorting(dgvLocalDLApplications);
            dgvLocalDLApplications.Refresh();
            CurrentMode = Mode.All;
            UpdateCountLabel();
        }

        private void UpdateCountLabel(string searchQuery = "")
        {
            //lblCount.Text = CurrentMode == Mode.All ?
            //    Person.GetAllPeopleCount().ToString() :
            //    Person.GetFilteredPeopleCount(searchQuery).ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageFilterControlsUI()
        {
            tbSearch.Visible = cbFilter.SelectedIndex != 0 && cbFilter.SelectedIndex != 4;
            cbStatus.Visible = cbFilter.SelectedIndex == 4;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageFilterControlsUI();
            Business.DisableSorting();
            tbSearch.Text = "";
            GetAllLocalDLApplicationsInDGV();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "\u007f")
            {
                tbSearch.Clear();
                GetAllLocalDLApplicationsInDGV();
            }
            //FilterPeople(tbSearch.Text.Trim());
        }

        private void CbStatus_VisibleChanged(object sender, EventArgs e)
        {
            if (cbStatus.Visible)
            {
                cbStatus.Location = new Point(359, 245);
            }
        }
    }
}
