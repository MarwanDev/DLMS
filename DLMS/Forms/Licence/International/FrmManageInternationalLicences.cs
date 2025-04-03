using DLMS.Forms.People;
using DLMS_Business;
using System;
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

        private void DgvInternationalLicences_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvInternationalLicences.Columns[e.ColumnIndex].HeaderText;
                Person.ApplySorting(headerText);
                ReloadData();
            }
        }

        private int SelectedInternationalLicenceId { get; set; }

        private void DgvInternationalLicences_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                dgvInternationalLicences.ContextMenuStrip = null;
            else
            {
                SelectedInternationalLicenceId = Int32.Parse(dgvInternationalLicences.Rows[e.RowIndex].Cells[0].Value?.ToString());
                DataGridView.HitTestInfo hit = dgvInternationalLicences.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvInternationalLicences.ClearSelection();
                    dgvInternationalLicences.Rows[hit.RowIndex].Selected = true;
                    dgvInternationalLicences.CurrentCell = dgvInternationalLicences.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceModel licence = LicenceModel.FindInternationalLicence(SelectedInternationalLicenceId);
            Person person = Person.FindByNationalNo(licence.NationalNo);
            if (person != null)
            {
                FrmShowPersonDetails frm = new FrmShowPersonDetails(person);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }

        private void ShowLicenceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceModel licence = LicenceModel.FindInternationalLicence(SelectedInternationalLicenceId);
            if (licence != null)
            {
                FrmShowInternationalLicence frm = new FrmShowInternationalLicence(licence);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }

        private void ShowPersonLicenceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceModel licence = LicenceModel.FindInternationalLicence(SelectedInternationalLicenceId);
            Person person = Person.FindByNationalNo(licence.NationalNo);
            if (person != null)
            {
                FrmLicenceHistory frm = new FrmLicenceHistory(person);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }
    }
}
