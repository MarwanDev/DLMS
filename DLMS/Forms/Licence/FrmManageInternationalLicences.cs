using DLMS_Business;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Licence
{
    public partial class FrmManageInternationalLicences : Form
    {
        public FrmManageInternationalLicences()
        {
            InitializeComponent();
        }

        private void FrmManageInternationalLicences_FormClosed(object sender, FormClosedEventArgs e)
        {
            Business.DisableSorting();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmManageInternationalLicences_Load(object sender, System.EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            GetAllInternationalLicencesInDGV();
        }

        private enum Mode { All, Filter };

        private static Mode CurrentMode;

        private void GetAllInternationalLicencesInDGV()
        {
            DataTable internationalLicences = LicenceModel.GetAllInternationalLicences();
            dgvInternationalLicences.DataSource = internationalLicences;
            Utils.DisableDGVColumnSorting(dgvInternationalLicences);
            dgvInternationalLicences.Refresh();
            CurrentMode = Mode.All;
            UpdateCountLabel();
        }

        private void UpdateCountLabel(string searchQuery = "")
        {
            lblCount.Text = CurrentMode == Mode.All ?
                LicenceModel.GetAllInternationalLicenceCount().ToString() :
                LicenceModel.GetFilteredInternationalLicencesCount(searchQuery).ToString();
        }

        private void CbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            tbSearch.Clear();
            Business.DisableSorting();
            ReloadData();
            tbSearch.Visible = cbFilter.SelectedIndex != 0;
        }

        private void ReloadData()
        {
            if (tbSearch.Visible && tbSearch.Text.Trim() != "")
            {
                FilterInternationalLicences(tbSearch.Text.Trim());
            }
            else
            {
                GetAllInternationalLicencesInDGV();
            }
        }

        private void FilterInternationalLicences(string searchKeyWord)
        {
            DataTable filteredInternationlLicences =
                LicenceModel.FilterInternationalLicences(cbFilter.Text, searchKeyWord);
            dgvInternationalLicences.DataSource = filteredInternationlLicences;
            Utils.DisableDGVColumnSorting(dgvInternationalLicences);
            dgvInternationalLicences.Refresh();
            CurrentMode = Mode.Filter;
            UpdateCountLabel(searchKeyWord);
        }

        private void TbSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (tbSearch.Text == "\u007f")
                tbSearch.Clear();
            if (tbSearch.Text == "")
                GetAllInternationalLicencesInDGV();
            else
                FilterInternationalLicences(tbSearch.Text.Trim());
        }
    }
}
