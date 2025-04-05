using DLMS.Forms.People;
using DLMS_Business;
using DLMS_Business.Licence;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Licence.DetainRelease
{
    public partial class FrmManageDetainedLicences : Form
    {
        public FrmManageDetainedLicences()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private enum Mode { All, Filter };

        private static Mode CurrentMode;

        private void FrmManageDetainedLicences_Load(object sender, EventArgs e)
        {
            GetAllDetainedLicencesInDGV();
            cbFilter.SelectedIndex = 0;
        }

        private void GetAllDetainedLicencesInDGV()
        {
            DataTable detainedLicences = DetainedLicence.GetAllDetainedLicences();
            dgvDetainedLicences.DataSource = detainedLicences;
            Utils.DisableDGVColumnSorting(dgvDetainedLicences);
            dgvDetainedLicences.Refresh();
            CurrentMode = Mode.All;
            UpdateCountLabel();
        }

        private void UpdateCountLabel(string searchQuery = "")
        {
            lblCount.Text = CurrentMode == Mode.All ?
                DetainedLicence.GetAllDetainedLicencesCount().ToString() :
                DetainedLicence.GetFilteredDetainedLicencesCount(searchQuery).ToString();
        }

        private void ManageFilterControlsUI()
        {
            if (cbFilter.SelectedIndex != 0 && cbFilter.SelectedIndex != 4)
            {
                pnlIsReleased.Visible = false;
                tbSearch.Visible = true;
            }
            else if (cbFilter.SelectedIndex == 4)
            {
                tbSearch.Visible = false;
                pnlIsReleased.Location = new System.Drawing.Point(358, 230);
                pnlIsReleased.Visible = true;
            }
            else
            {
                tbSearch.Visible = false;
                pnlIsReleased.Visible = false;
            }
            tbSearch.Clear();
            rdbNo.Checked = false;
            rdbYes.Checked = false;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageFilterControlsUI();
            GetAllDetainedLicencesInDGV();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                GetAllDetainedLicencesInDGV();
                return;
            }
            if (tbSearch.Text == "\u007f")
            {
                tbSearch.Clear();
                GetAllDetainedLicencesInDGV();
            }
            if (cbFilter.SelectedIndex == 1 ||
                cbFilter.SelectedIndex == 2 ||
                cbFilter.SelectedIndex == 7)
            {
                tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, "[^0-9]", "");
            }
            if (cbFilter.SelectedIndex == 3)
            {
                tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, @"[^0-9.]", "");

                int dotIndex = tbSearch.Text.IndexOf('.');
                if (dotIndex != -1)
                {
                    tbSearch.Text = tbSearch.Text.Substring(0, dotIndex + 1) +
                                    tbSearch.Text.Substring(dotIndex + 1).Replace(".", "");
                }

                tbSearch.SelectionStart = tbSearch.Text.Length;
            }
            FilterDetainedLicences(tbSearch.Text.Trim());
        }

        private void FilterDetainedLicences(string searchKeyWord)
        {
            DataTable filteredDetainedLicences = tbSearch.Text != "" ?
                DetainedLicence.FilterDetainedLicences(cbFilter.Text.Trim(), searchKeyWord) :
                DetainedLicence.FilterDetainedLicences("Is Released", searchKeyWord);
            dgvDetainedLicences.DataSource = filteredDetainedLicences;
            Utils.DisableDGVColumnSorting(dgvDetainedLicences);
            dgvDetainedLicences.Refresh();
            CurrentMode = Mode.Filter;
            UpdateCountLabel(searchKeyWord);
        }

        private void TbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1 ||
                cbFilter.SelectedIndex == 2 ||
                cbFilter.SelectedIndex == 7)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            if (cbFilter.SelectedIndex == 2)
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                    return;
                }

                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                    return;
                }

                if (e.KeyChar == '.' && (sender is TextBox tb && !tb.Text.Contains(".")))
                {
                    e.Handled = false;
                    return;
                }

                e.Handled = true;
            }
        }

        private void RdbIsReleased_CheckedChanged(object sender, EventArgs e)
        {
            FilterWithIsReleased();
        }

        private void FilterWithIsReleased()
        {
            if (rdbYes.Checked)
                FilterDetainedLicences("1");
            else FilterDetainedLicences("0");
        }

        private void ReloadData()
        {
            if (tbSearch.Visible && tbSearch.Text.Trim() != "")
            {
                FilterDetainedLicences(tbSearch.Text.Trim());
            }
            else if (pnlIsReleased.Visible && (rdbYes.Checked || rdbNo.Checked))
            {
                FilterWithIsReleased();
            }
            else
            {
                GetAllDetainedLicencesInDGV();
            }
        }

        private void BtnRelease_Click(object sender, EventArgs e)
        {
            FrmReleaseLicence frm = new FrmReleaseLicence();
            frm.OnFormClosed += ReloadData;
            frm.ShowDialog();
        }

        private void BtnDetain_Click(object sender, EventArgs e)
        {
            FrmDetainLicence frm = new FrmDetainLicence();
            frm.OnFormClosed += ReloadData;
            frm.ShowDialog();
        }

        public new event Action OnFormClosed;

        private void FrmManageDetainedLicences_FormClosed(object sender, FormClosedEventArgs e)
        {
            Business.DisableSorting();
            OnFormClosed?.Invoke();
        }

        private void DgvDetainedLicences_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvDetainedLicences.Columns[e.ColumnIndex].HeaderText;
                Person.ApplySorting(headerText);
                ReloadData();
            }
        }

        private int SelectedDetainId { get; set; }

        private DetainedLicence CurrentDetaineLicence { get; set; }

        private void ModifyCMSOptionsAbilityAccordingToPassedTest()
        {
            DetainedLicence detainedLicence = DetainedLicence.Find(SelectedDetainId);
            if (detainedLicence != null)
            {
                releaseDetainedLicenceToolStripMenuItem.Enabled = DetainedLicence.IsLicenceDetained(detainedLicence.LicenceID);
                CurrentDetaineLicence = detainedLicence;
            }
        }

        private void DgvDetainedLicences_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                dgvDetainedLicences.ContextMenuStrip = null;
            else
            {
                SelectedDetainId = Int32.Parse(dgvDetainedLicences.Rows[e.RowIndex].Cells[0].Value?.ToString());
                ModifyCMSOptionsAbilityAccordingToPassedTest();
                DataGridView.HitTestInfo hit = dgvDetainedLicences.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvDetainedLicences.ClearSelection();
                    dgvDetainedLicences.Rows[hit.RowIndex].Selected = true;
                    dgvDetainedLicences.CurrentCell = dgvDetainedLicences.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = Person.Find(DetainedLicence.GetPersonIdByDetainLicenceId(SelectedDetainId));
            if (person != null)
            {
                FrmShowPersonDetails frm = new FrmShowPersonDetails(person);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }

        private void ShowLicenceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceModel licence = LicenceModel.Find(CurrentDetaineLicence.LicenceID);
            if (licence != null)
            {
                FrmShowLicence frm = new FrmShowLicence(licence);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }

        private void ShowPersonLicenceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = Person.Find(DetainedLicence.GetPersonIdByDetainLicenceId(SelectedDetainId));
            if (person != null)
            {
                FrmLicenceHistory frm = new FrmLicenceHistory(person);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }
    }
}
