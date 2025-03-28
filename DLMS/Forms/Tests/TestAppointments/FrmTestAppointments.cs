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
        private LocalDLApplication CurrentLocalDLApplication { get; set; }

        public FrmTestAppointments(TestMode testMode, LocalDLApplication localDLApplication)
        {
            InitializeComponent();
            CurrentTestMode = testMode;
            CurrentLocalDLApplication = localDLApplication;
            ChangeHeaderText();
            ChangeHeaderPictureBoxImage();
            ModifyControlsAccordingToApplication();
        }

        private void GetAllTestAppointmentsInDGV()
        {
            if (CurrentLocalDLApplication != null)
            {
                DataTable localDLApplications = TestAppointment.GetAllTestAppointmentsForLocalDLApplication(CurrentLocalDLApplication.ID);
                dgvTestAppointments.DataSource = localDLApplications;
                Utils.DisableDGVColumnSorting(dgvTestAppointments);
                dgvTestAppointments.Refresh();
                UpdateCountLabel();
            }
        }

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
            dgvTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public new event Action OnFormClosed;

        private void FrmTestAppointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }
    }
}
