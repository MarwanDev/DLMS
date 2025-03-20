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

        private void FilterLocalDLApplications(string searchKeyWord)
        {
            DataTable filteredLocalDLApplications = tbSearch.Text != "" ?
                LocalDLApplication.FilterLocalDLApplications(cbFilter.Text, searchKeyWord) :
                LocalDLApplication.FilterLocalDLApplications("Status", searchKeyWord);
            dgvLocalDLApplications.DataSource = filteredLocalDLApplications;
            Utils.DisableDGVColumnSorting(dgvLocalDLApplications);
            dgvLocalDLApplications.Refresh();
            CurrentMode = Mode.Filter;
            UpdateCountLabel(searchKeyWord);
        }

        private void UpdateCountLabel(string searchQuery = "")
        {
            lblCount.Text = CurrentMode == Mode.All ?
                LocalDLApplication.GetAllLocalDLApplicationsCount().ToString() :
                LocalDLApplication.GetFilteredLocalDLApplicationsCount(searchQuery).ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageFilterControlsUI()
        {
            tbSearch.Visible = cbFilter.SelectedIndex != 0 && cbFilter.SelectedIndex != 4;
            cbStatus.Visible = cbFilter.SelectedIndex == 4;
            cbStatus.SelectedIndex = 0;
            tbSearch.Text = "";
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageFilterControlsUI();
            Business.DisableSorting();
            GetAllLocalDLApplicationsInDGV();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "\u007f")
                tbSearch.Clear();
            if (tbSearch.Text == "")
                GetAllLocalDLApplicationsInDGV();
            else
                FilterLocalDLApplications(tbSearch.Text.Trim());
        }

        private void CbStatus_VisibleChanged(object sender, EventArgs e)
        {
            if (cbStatus.Visible)
            {
                cbStatus.Location = new Point(359, 245);
            }
        }

        private void CbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedIndex != 0)
                FilterLocalDLApplications(cbStatus.Text);
            else
                GetAllLocalDLApplicationsInDGV();
        }
    }
}
