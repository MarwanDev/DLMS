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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        enum Mode { Add, Edit };
        private Mode CurrentMode { get; set; }

        private TestType CurrentTestype { get; set; }

        private int CurrentTestTypeId;

        private void ModifyControlsForAddition()
        {
            pbTestType.Image = CurrentTestMode == TestMode.Vision ? Resources.Vision_Test_Schdule :
                CurrentTestMode == TestMode.Written ? Resources.Written_Test_32_Sechdule : Resources.Street_Test_32;
            this.Text = CurrentMode == Mode.Add ? "Schedule Test" : "Edit Test";
            lblLocalDLApp.Text = CurrentLocalDLApplication.ID.ToString();
            dtpTestDate.MinDate = DateTime.Now.AddDays(1);
            lblLicenceClass.Text = CurrentLocalDLApplication.LicenceClassName;
            lblFullName.Text = CurrentLocalDLApplication.PersonFullName;
            CurrentTestTypeId = CurrentTestMode == TestMode.Vision ? 1 : CurrentTestMode == TestMode.Written ? 2 : 3;
            lblTrial.Text = TestAppointment.GetNumberOfTrials(CurrentTestTypeId, CurrentLocalDLApplication.ID).ToString();
            CurrentTestype = TestType.Find(CurrentTestTypeId);
            lblFees.Text = CurrentTestype.Fees.ToString();
            lblRetakeFees.Text = "5";
            gbRetakeTestInfo.Enabled = false;
            //lblRetakeTestId.Text = "1";
            //lblTotalFees.Text = "";
        }

        private void FrmAddEditTestAppointment_Load(object sender, EventArgs e)
        {
            ModifyControlsForAddition();
        }

        public FrmTestAppointments.TestMode CurrentTestMode { get; set; }

        public LocalDLApplication CurrentLocalDLApplication { get; set; }

        public new event Action OnFormClosed;

        private void FrmAddEditTestAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {
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
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void SaveUpdate()
        {

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
