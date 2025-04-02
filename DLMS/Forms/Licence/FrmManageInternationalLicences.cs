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
            //lblCount.Text = CurrentMode == Mode.All ?
            //    LocalDLApplication.GetAllLocalDLApplicationsCount().ToString() :
            //    LocalDLApplication.GetFilteredLocalDLApplicationsCount(searchQuery).ToString();
        }
    }
}
