using DLMS.Forms.Tests.Test;
using DLMS.Forms.Tests.TestAppointments;
using DLMS.Properties;
using DLMS_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Tests
{
    public partial class FrmTestAppointments : Form
    {
        public FrmTestAppointments()
        {
            InitializeComponent();
        }

        public enum TestMode { Vision, Written, Street }
        private TestMode CurrentTestMode { get; set; }
        public LocalDLApplication CurrentLocalDLApplication { get; set; }

        public FrmTestAppointments(TestMode testMode, LocalDLApplication localDLApplication)
        {
            InitializeComponent();
            CurrentTestMode = testMode;
            CurrentLocalDLApplication = localDLApplication;
            ChangeHeaderText();
            ChangeHeaderPictureBoxImage();
            ModifyControlsAccordingToApplication();
            CurrentTestTypeId = CurrentTestMode == TestMode.Vision ? 1 :
                CurrentTestMode == TestMode.Written ? 2 : 3;
        }

        private void GetAllTestAppointmentsInDGV()
        {
            if (CurrentLocalDLApplication != null)
            {
                DataTable localDLApplications = TestAppointment.GetAllTestAppointmentsForLocalDLApplication(CurrentLocalDLApplication.ID, CurrentTestTypeId);
                dgvTestAppointments.DataSource = localDLApplications;
                Utils.DisableDGVColumnSorting(dgvTestAppointments);
                dgvTestAppointments.Refresh();
                UpdateCountLabel();
            }
        }

        int CurrentTestTypeId { get; set; }

        private void UpdateCountLabel()
        {
            lblCount.Text = TestAppointment.GetAllTestAppointmentsCountForLocalDLApplication(CurrentLocalDLApplication.ID).ToString();
        }

        private void ModifyControlsAccordingToApplication()
        {
            ucDLApplicationInfo1.SetLocalDLApplication(CurrentLocalDLApplication);
            ucDLApplicationInfo1.SetApplicant(CurrentLocalDLApplication.PersonFullName);
            ucDLApplicationInfo1.SetApplicationDate(CurrentLocalDLApplication.ApplicationDate);
            ucDLApplicationInfo1.SetApplicationId(CurrentLocalDLApplication.ApplicationID);
            ucDLApplicationInfo1.SetApplicationType(CurrentLocalDLApplication.ApplicationTypeTitle);
            ucDLApplicationInfo1.SetCreatedByUserName(CurrentLocalDLApplication.CreatedByUserName);
            ucDLApplicationInfo1.SetLastStatusDate(CurrentLocalDLApplication.LastStatusDate);
            ucDLApplicationInfo1.SetLicence(CurrentLocalDLApplication.LicenceClassName);
            ucDLApplicationInfo1.SetFees(CurrentLocalDLApplication.PaidFees);
            ucDLApplicationInfo1.SetId(CurrentLocalDLApplication.ID);
            ucDLApplicationInfo1.SetPassedTests(CurrentLocalDLApplication.PassedTests);
            ucDLApplicationInfo1.SetStatus(CurrentLocalDLApplication.StatusText);
            ucDLApplicationInfo1.ChangeShowPersonInfoLinkLabelsAbility();
        }

        private void ChangeHeaderText()
        {
            string testType = CurrentTestMode == TestMode.Vision ? "Vision" :
                CurrentTestMode == TestMode.Written ? "Written" : "Street";
            lblHeader.Text = testType + " Test Appointments";
        }

        private void ChangeHeaderPictureBoxImage()
        {
            pbTestType.Image = CurrentTestMode == TestMode.Vision ? Resources.Vision_Test_Schdule :
                CurrentTestMode == TestMode.Written ? Resources.Written_Test_32_Sechdule : Resources.Street_Test_32;
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmTestAppointments_Load(object sender, System.EventArgs e)
        {
            GetAllTestAppointmentsInDGV();
        }

        public new event Action OnFormClosed;

        private void FrmTestAppointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void BtnAddTestAppointment_Click(object sender, EventArgs e)
        {
            if (TestAppointment.IsTestPassed(CurrentTestTypeId, CurrentLocalDLApplication.ID))
            {
                MessageBox.Show("Test is already passed. Can't add any more",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (TestAppointment.DoesActiveTestAppointmentExist(CurrentLocalDLApplication.ID))
            {
                MessageBox.Show("There is an active test appointment under the same application. Can't add any more",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                FrmAddEditTestAppointment frm = new FrmAddEditTestAppointment
                {
                    CurrentLocalDLApplication = this.CurrentLocalDLApplication,
                    CurrentTestMode = this.CurrentTestMode
                };
                frm.OnFormClosed += GetAllTestAppointmentsInDGV;
                frm.ShowDialog();
            }
        }

        private void EditTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointment testAppointment = TestAppointment.Find(SelectedTestAppointmentId);
            if (testAppointment != null)
            {
                FrmAddEditTestAppointment frm = new FrmAddEditTestAppointment(testAppointment)
                {
                    CurrentTestMode = this.CurrentTestMode,
                    CurrentLocalDLApplication = this.CurrentLocalDLApplication,
                };
                frm.OnFormClosed += GetAllTestAppointmentsInDGV;
                frm.ShowDialog();
            }
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointment testAppointment = TestAppointment.Find(SelectedTestAppointmentId);
            if (testAppointment != null)
            {
                FrmTakeTest frm = new FrmTakeTest(testAppointment)
                {
                    CurrentTestMode = this.CurrentTestMode,
                    CurrentLocalDLApplication = this.CurrentLocalDLApplication,
                };
                frm.OnFormClosed += GetAllTestAppointmentsInDGV;
                frm.ShowDialog();
            }
        }

        int SelectedTestAppointmentId { get; set; }

        private void DgvTestAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                dgvTestAppointments.ContextMenuStrip = null;
            else
            {
                dgvTestAppointments.ContextMenuStrip = cmsTestAppointment;
                SelectedTestAppointmentId = Int32.Parse(dgvTestAppointments.Rows[e.RowIndex].Cells[0].Value?.ToString());
                DataGridView.HitTestInfo hit = dgvTestAppointments.HitTest(e.X, e.Y);
                TestAppointment testAppointment = TestAppointment.Find(SelectedTestAppointmentId);
                if (testAppointment != null && testAppointment.IsLocked)
                {
                    editTestToolStripMenuItem.Enabled = false;
                    takeTestToolStripMenuItem.Enabled = false;
                }
                else
                {
                    takeTestToolStripMenuItem.Enabled = true;
                    editTestToolStripMenuItem.Enabled = true;
                }
                if (hit.RowIndex >= 0)
                {
                    dgvTestAppointments.ClearSelection();
                    dgvTestAppointments.Rows[hit.RowIndex].Selected = true;
                    dgvTestAppointments.CurrentCell = dgvTestAppointments.Rows[hit.RowIndex].Cells[0];
                }
            }
        }
    }
}
