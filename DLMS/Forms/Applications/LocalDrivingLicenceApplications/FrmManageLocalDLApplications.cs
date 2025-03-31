using DLMS.Forms.Licence;
using DLMS.Forms.Tests;
using DLMS_Business;
using DLMS_Business.Application;
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

        private int SelectedLocalDLApplicationId { get; set; }

        private void ModifyCMSOptionsAbilityAccordingToPassedTest()
        {
            byte applicationStatus = LocalDLApplication.GetApplicationStatusById(SelectedLocalDLApplicationId);
            if (applicationStatus == 0 || applicationStatus == 3)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
                issueLicenceToolStripMenuItem.Enabled = !LocalDLApplication.DoesLicenceExist(SelectedLocalDLApplicationId);
            }
            else
            {
                int passedTests = LocalDLApplication.GetPassedTestsCount(SelectedLocalDLApplicationId);
                visionTestToolStripMenuItem.Enabled = passedTests == 0;
                writtenTestToolStripMenuItem.Enabled = passedTests == 1;
                streetTestToolStripMenuItem.Enabled = passedTests == 2;
                issueLicenceToolStripMenuItem.Enabled = passedTests == 3;
            }
        }

        private void DgvLocalDLApplications_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                dgvLocalDLApplications.ContextMenuStrip = null;
            else
            {
                SelectedLocalDLApplicationId = Int32.Parse(dgvLocalDLApplications.Rows[e.RowIndex].Cells[0].Value?.ToString());
                ModifyCMSOptionsAbilityAccordingToPassedTest();
                DataGridView.HitTestInfo hit = dgvLocalDLApplications.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvLocalDLApplications.ClearSelection();
                    dgvLocalDLApplications.Rows[hit.RowIndex].Selected = true;
                    dgvLocalDLApplications.CurrentCell = dgvLocalDLApplications.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void DgvLocalDLApplications_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvLocalDLApplications.Columns[e.ColumnIndex].HeaderText;
                Person.ApplySorting(headerText);
                ReloadData();
            }
        }

        private void ReloadData()
        {
            if (tbSearch.Visible && tbSearch.Text.Trim() != "")
            {
                FilterLocalDLApplications(tbSearch.Text.Trim());
            }
            else if (cbStatus.Visible && cbStatus.SelectedIndex != 0)
            {
                FilterLocalDLApplications(cbStatus.Text);
            }
            else
            {
                GetAllLocalDLApplicationsInDGV();
            }
        }

        private void BtnAddLocalDLApp_Click(object sender, EventArgs e)
        {
            FrmAddEditLocalDrivingLicenceApplication frm = new FrmAddEditLocalDrivingLicenceApplication();
            frm.OnFormClosed += ReloadData;
            frm.ShowDialog();
        }

        private void CancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the Local Application with id {SelectedLocalDLApplicationId}?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (LocalDLApplication.CancelLocalDLApplication(SelectedLocalDLApplicationId))
                {
                    MessageBox.Show($"Local Application with id {SelectedLocalDLApplicationId} has been canceled successfully?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);
                    ReloadData();
                }
                else
                    MessageBox.Show("Something Wrong Happened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDLApplication localDLApplication = LocalDLApplication.Find(SelectedLocalDLApplicationId);
            if (localDLApplication != null)
            {
                FrmAddEditLocalDrivingLicenceApplication frm = new FrmAddEditLocalDrivingLicenceApplication(localDLApplication);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }

        private void ShowApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDLApplication localDLApplication = LocalDLApplication.Find(SelectedLocalDLApplicationId);
            if (localDLApplication != null)
            {
                FrmShowLocalDLApplicationDetails frm = new FrmShowLocalDLApplicationDetails(localDLApplication);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }

        private void DeleteApplication()
        {
            if (MessageBox.Show($"Are you sure you want to delete the application with id {SelectedLocalDLApplicationId}?",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int applicationId = LocalDLApplication.GetApplicationId(SelectedLocalDLApplicationId);
                if (LocalDLApplication.DeleteLocalDLApplication(SelectedLocalDLApplicationId))
                {
                    if (ApplicationModel.DeleteApplication(applicationId))
                    {
                        MessageBox.Show($"Application Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"Couldn't delete the application as there are tests attached to it",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                ReloadData();
            }
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteApplication();
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDLApplication localDLApplication = LocalDLApplication.FindInDetails(SelectedLocalDLApplicationId);
            if (localDLApplication != null)
            {
                FrmTestAppointments.TestMode testMode = (ToolStripMenuItem)sender == visionTestToolStripMenuItem ?
                    FrmTestAppointments.TestMode.Vision :
                    (ToolStripMenuItem)sender == writtenTestToolStripMenuItem ?
                    FrmTestAppointments.TestMode.Written :
                    FrmTestAppointments.TestMode.Street;
                FrmTestAppointments frm = new FrmTestAppointments(testMode, localDLApplication);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }

        private void FrmManageLocalDLApplications_FormClosed(object sender, FormClosedEventArgs e)
        {
            Business.DisableSorting();
        }

        private void IssueLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDLApplication localDLApplication = LocalDLApplication.FindInDetails(SelectedLocalDLApplicationId);
            if (localDLApplication != null)
            {
                FrmIssueLicence frm = new FrmIssueLicence(localDLApplication, 1);
                frm.OnFormClosed += ReloadData;
                frm.ShowDialog();
            }
        }
    }
}
