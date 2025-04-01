using DLMS_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.People
{
    public partial class FrmManageDrivers : Form
    {
        public FrmManageDrivers()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageDrivers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Business.DisableSorting();
        }

        private void GetAllDriversInDGV()
        {
            DataTable localDLApplications = Driver.GetAllDrivers();
            dgvDrivers.DataSource = localDLApplications;
            Utils.DisableDGVColumnSorting(dgvDrivers);
            dgvDrivers.Refresh();
            CurrentMode = Mode.All;
            UpdateCountLabel();
        }

        private enum Mode { All, Filter };

        private static Mode CurrentMode;

        private void UpdateCountLabel(string searchQuery = "")
        {
            lblCount.Text = CurrentMode == Mode.All ?
                Driver.GetAllDriversCount().ToString() :
                Driver.GetFilteredDriversCount(tbSearch.Text.Trim()).ToString();
        }

        private void FrmManageDrivers_Load(object sender, EventArgs e)
        {
            GetAllDriversInDGV();
            cbFilter.SelectedIndex = 0;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = cbFilter.SelectedIndex != 0;
            tbSearch.Text = "";
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
