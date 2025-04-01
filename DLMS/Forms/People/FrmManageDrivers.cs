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
                Driver.GetFilteredDriversCount(searchQuery).ToString();
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
            if (tbSearch.Text == "\u007f")
                tbSearch.Clear();
            if (tbSearch.Text == "")
                GetAllDriversInDGV();
            else
                FilterDrivers(tbSearch.Text.Trim());
        }

        private void FilterDrivers(string searchKeyWord)
        {
            DataTable filteredDrivers = tbSearch.Text != "" ?
                Driver.FilterDrivers(cbFilter.Text, searchKeyWord) : Driver.GetAllDrivers();
            dgvDrivers.DataSource = filteredDrivers;
            Utils.DisableDGVColumnSorting(dgvDrivers);
            dgvDrivers.Refresh();
            CurrentMode = Mode.Filter;
            UpdateCountLabel(searchKeyWord);
        }

        private void TbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void DgvDrivers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvDrivers.Columns[e.ColumnIndex].HeaderText;
                Person.ApplySorting(headerText);
                ReloadData();
            }
        }

        private void ReloadData()
        {
            if (tbSearch.Visible && tbSearch.Text.Trim() != "")
            {
                FilterDrivers(tbSearch.Text.Trim());
            }
            else
            {
                GetAllDriversInDGV();
            }
        }
    }
}
