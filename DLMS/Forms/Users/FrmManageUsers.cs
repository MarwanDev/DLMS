using DLMS.Properties;
using System.Data;
using System.Windows.Forms;
using DLMS_Business;
using System;

namespace DLMS.Forms.Users
{
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();
            ucHeader1.SetText("Manage Users");
            ucHeader1.SetImage(Resources.Users_2_400);
            ucHeader1.SetColor(System.Drawing.Color.Red);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private enum Mode { All, Filter };

        private static Mode CurrentMode;

        private void UpdateCountLabel(string searchQuery = "")
        {
            lblCount.Text = CurrentMode == Mode.All ?
                User.GetAllUsersCount().ToString() :
                User.GetFilteredUsersCount(searchQuery).ToString();
        }

        private void GetAllUsersInDGV()
        {
            DataTable users = User.GetAllUsers();
            dgvUsers.DataSource = users;
            Utils.DisableDGVColumnSorting(dgvUsers);
            dgvUsers.Refresh();
            UpdateCountLabel();
            CurrentMode = Mode.All;
        }

        private void FrmManageUsers_Load(object sender, System.EventArgs e)
        {
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GetAllUsersInDGV();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cbFilter.SelectedIndex = 0;
        }

        private void ManageFilterControlsUI()
        {
            if (cbFilter.SelectedIndex != 0 && cbFilter.SelectedIndex != 5)
            {
                pnlActivationStatus.Visible = false;
                tbSearch.Visible = true;
            }
            else if (cbFilter.SelectedIndex == 5)
            {
                tbSearch.Visible = false;
                pnlActivationStatus.Location = new System.Drawing.Point(358, 270);
                pnlActivationStatus.Visible = true;
            }
            else
            {
                tbSearch.Visible = false;
                pnlActivationStatus.Visible = false;
            }
        }

        private void CbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ManageFilterControlsUI();
            User.DisableSorting();
            rdbActive.Checked = false;
            rdbInactive.Checked = false;
            tbSearch.Text = "";
            GetAllUsersInDGV();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void TbSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                GetAllUsersInDGV();
                return;
            }
            if (tbSearch.Text == "\u007f")
            {
                tbSearch.Clear();
                GetAllUsersInDGV();
            }
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2)
            {
                tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, "[^0-9]", "");
            }
            FilterUsers(tbSearch.Text.Trim());
        }

        private string GetFilterParameter()
        {
            switch (cbFilter.Text)
            {
                case "Name":
                    return "FullName";
                default:
                    return cbFilter.Text;
            }
        }

        private void FilterUsers(string filterKeyWord)
        {
            DataTable filteredUsers = !string.IsNullOrEmpty(tbSearch.Text) ?
                User.FilterUsers(GetFilterParameter(), filterKeyWord) :
                User.FilterUsers("IsActive", filterKeyWord);
            dgvUsers.DataSource = filteredUsers;
            Utils.DisableDGVColumnSorting(dgvUsers);
            dgvUsers.Refresh();
            CurrentMode = Mode.Filter;
            UpdateCountLabel(filterKeyWord);
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

        private string GetSortingParameter(string sortingParam)
        {
            switch (sortingParam)
            {
                case "Full Name":
                    return "FullName";
                case "Is Active":
                    return "IsActive";
                case "User ID":
                    return "UserID";
                case "Person ID":
                    return "PersonID";
                default:
                    return sortingParam;
            }
        }

        private void FilterWithActivationStatus()
        {
            string searchKeyWord = rdbActive.Checked ? "1" : "0";
            FilterUsers(searchKeyWord);
        }

        private void ReloadData()
        {
            if (tbSearch.Visible && tbSearch.Text.Trim() != "")
            {
                FilterUsers(tbSearch.Text.Trim());
            }
            else if (rdbActive.Visible && rdbInactive.Visible && (rdbInactive.Checked || rdbActive.Checked))
            {
                FilterWithActivationStatus();
            }
            else
            {
                GetAllUsersInDGV();
            }
        }

        private int SelectedUserId { get; set; }

        private void DgvUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvUsers.Columns[e.ColumnIndex].HeaderText;
                User.ApplySorting(GetSortingParameter(headerText));
                ReloadData();
            }
        }

        private void DgvUsers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                dgvUsers.ContextMenuStrip = null;
            else
            {
                dgvUsers.ContextMenuStrip = ctmsUser;
                SelectedUserId = Int32.Parse(dgvUsers.Rows[e.RowIndex].Cells[0].Value?.ToString());
                DataGridView.HitTestInfo hit = dgvUsers.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvUsers.ClearSelection();
                    dgvUsers.Rows[hit.RowIndex].Selected = true;
                    dgvUsers.CurrentCell = dgvUsers.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void RdbACtivation_CheckedChanged(object sender, System.EventArgs e)
        {
            FilterWithActivationStatus();
        }

        private void ViewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SelectedUserId.ToString());
        }
    }
}
