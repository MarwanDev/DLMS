using DLMS_Business;
using DLMS_Business.Licence;
using System;
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
            if (rdbYes.Checked)
                FilterDetainedLicences("1");
            else FilterDetainedLicences("0");
        }
    }
}
