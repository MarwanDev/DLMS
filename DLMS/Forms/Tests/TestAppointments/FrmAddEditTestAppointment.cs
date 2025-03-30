using DLMS.Properties;
using DLMS_Business;
using System;
using System.Windows.Forms;
using static DLMS.Forms.Tests.FrmTestAppointments;

namespace DLMS.Forms.Tests.TestAppointments
{
    public partial class FrmAddEditTestAppointment : Form
    {
        public FrmAddEditTestAppointment()
        {
            InitializeComponent();
            CurrentMode = Mode.Add;
        }

        public FrmAddEditTestAppointment(TestAppointment testAppointment)
        {
            InitializeComponent();
            CurrentTestAppointment = testAppointment;
            CurrentMode = Mode.Edit;
        }

        private void ModifyCurrentTestTypeId()
        {
            CurrentTestTypeId = CurrentTestMode == TestMode.Vision ? 1 : CurrentTestMode == TestMode.Written ? 2 : 3;
        }

        private void CheckIfTestIsToBeRetaken()
        {
            IsTestToBeRetaken = TestAppointment.DoesLockedTestAppointmentExist(CurrentLocalDLApplication.ID, CurrentTestTypeId) &&
                !TestAppointment.IsTestPassed(CurrentTestTypeId, CurrentLocalDLApplication.ID);
        }

        private void ApplyRetakeTestControlUIModifications()
        {
            ModifyCurrentTestTypeId();
            CheckIfTestIsToBeRetaken();
        }

        TestAppointment CurrentTestAppointment { get; set; }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        enum Mode { Add, Edit };
        private Mode CurrentMode { get; set; }

        private TestType CurrentTestype { get; set; }

        private int CurrentTestTypeId;

        bool IsTestToBeRetaken { get; set; }

        private void ModifyControls()
        {
            ApplyRetakeTestControlUIModifications();
            pbTestType.Image = CurrentTestMode == TestMode.Vision ? Resources.Vision_512 :
                CurrentTestMode == TestMode.Written ? Resources.Written_Test_512 : Resources.Street_Test_32;
            this.Text = CurrentMode == Mode.Add ? "Schedule Test" : "Edit Test";
            gbTestData.Text = CurrentTestMode == TestMode.Vision ? "Vision Test" :
                CurrentTestMode == TestMode.Written ? "Written Test" : "Street Test";
            lblLocalDLApp.Text = CurrentLocalDLApplication.ID.ToString();
            dtpTestDate.MinDate = DateTime.Now.AddDays(1);
            lblLicenceClass.Text = CurrentLocalDLApplication.LicenceClassName;
            lblFullName.Text = CurrentLocalDLApplication.PersonFullName;
            lblTrial.Text = TestAppointment.GetNumberOfTrials(CurrentTestTypeId, CurrentLocalDLApplication.ID).ToString();
            CurrentTestype = TestType.Find(CurrentTestTypeId);
            lblFees.Text = CurrentTestype.Fees.ToString();
            gbRetakeTestInfo.Enabled = IsTestToBeRetaken;
            lblRetakeFees.Text = IsTestToBeRetaken ? "5" : "N/A";
            lblRetakeTestId.Text = IsTestToBeRetaken ? "???" : "N/A";
            lblTotalFees.Text = IsTestToBeRetaken ? $"{decimal.Parse(lblFees.Text) + decimal.Parse(lblRetakeFees.Text)}" : "N/A";
        }

        private void FrmAddEditTestAppointment_Load(object sender, EventArgs e)
        {
            ModifyControls();
        }

        public FrmTestAppointments.TestMode CurrentTestMode { get; set; }

        public LocalDLApplication CurrentLocalDLApplication { get; set; }

        public new event Action OnFormClosed;

        private void FrmAddEditTestAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            CurrentTestAppointment = null;
            OnFormClosed?.Invoke();
        }

        private void SaveAddition()
        {
            TestAppointment testAppointment = new TestAppointment
            {
                TestTypeID = CurrentTestTypeId,
                LocalDLApplicationID = CurrentLocalDLApplication.ID,
                AppointmentDate = dtpTestDate.Value,
                PaidFees = !gbRetakeTestInfo.Enabled ? Convert.ToDecimal(lblFees.Text) :
                Convert.ToDecimal(lblTotalFees.Text),
                CreatedByUserID = UserSession.LoggedInUser.ID,
                IsLocked = false
            };
            if (testAppointment.Save())
            {
                MessageBox.Show($"Test Appointment added succesfully with ID {testAppointment.ID}", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                CurrentMode = Mode.Edit;
                CurrentTestAppointment = testAppointment;
                lblHeader.Text = "Edit Test";
                lblRetakeTestId.Text = IsTestToBeRetaken ? CurrentTestAppointment.ID.ToString() : lblRetakeTestId.Text;
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void SaveUpdate()
        {
            CurrentTestAppointment.AppointmentDate = dtpTestDate.Value;
            if (CurrentTestAppointment.Save())
            {
                MessageBox.Show("Test Appointment updated succesfully", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CurrentMode == Mode.Add)
                SaveAddition();
            else
                SaveUpdate();
        }
    }
}
