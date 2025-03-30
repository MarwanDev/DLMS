using DLMS.Properties;
using DLMS_Business;
using DLMS_Business.Test;
using System;
using System.Windows.Forms;
using static DLMS.Forms.Tests.FrmTestAppointments;

namespace DLMS.Forms.Tests.Test
{
    public partial class FrmTakeTest : Form
    {
        public FrmTakeTest()
        {
            InitializeComponent();
        }

        public FrmTakeTest(TestAppointment testAppointment)
        {
            InitializeComponent();
            CurrentTestAppointment = testAppointment;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TestModel testModel = new TestModel
            {
                TestAppointmentID = CurrentTestAppointment.ID,
                TestResult = rdbPass.Checked,
                Notes = rtbNotes.Text.Trim(),
                CreatedByUserID = UserSession.LoggedInUser.ID
            };
            if (testModel.Save())
            {
                if (TestAppointment.LockTestAppointment(CurrentTestAppointment.ID))
                {
                    MessageBox.Show($"Test data saved succesfully with Id {testModel.ID}", "Success",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Information);
                    if (CurrentTestMode == TestMode.Street && rdbPass.Checked)
                    {
                        if (LocalDLApplication.ChangeApplicationStatus(CurrentLocalDLApplication.ID, 3))
                        {
                            MessageBox.Show($"Application Completed Successfully", "Success",
                                MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Something wrong happened while changing Application status", "Error",
                                MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Error);
                        }
                    }
                    lblTestId.Text = testModel.ID.ToString();
                    btnSave.Enabled = false;
                }
                else
                    MessageBox.Show($"Something wrong happened", "Error",
                        MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error);
            }
            else
                MessageBox.Show($"Something wrong happened when saveing the test info", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        public FrmTestAppointments.TestMode CurrentTestMode { get; set; }

        TestAppointment CurrentTestAppointment { get; set; }

        public LocalDLApplication CurrentLocalDLApplication { get; set; }

        public new event Action OnFormClosed;

        private void ModifyControls()
        {
            pbTestType.Image = CurrentTestMode == TestMode.Vision ? Resources.Vision_512 :
                CurrentTestMode == TestMode.Written ? Resources.Written_Test_512 : Resources.Street_Test_32;
            gbTestData.Text = CurrentTestMode == TestMode.Vision ? "Vision Test" :
                CurrentTestMode == TestMode.Written ? "Written Test" : "Street Test";
            lblLocalDLApp.Text = CurrentLocalDLApplication.ID.ToString();
            lblLicenceClass.Text = CurrentLocalDLApplication.LicenceClassName;
            lblDate.Text = CurrentTestAppointment.AppointmentDate.ToShortDateString();
            lblFullName.Text = CurrentLocalDLApplication.PersonFullName;
            CurrentTestTypeId = CurrentTestMode == TestMode.Vision ? 1 : CurrentTestMode == TestMode.Written ? 2 : 3;
            lblTrial.Text = TestAppointment.GetNumberOfTrials(CurrentTestTypeId, CurrentLocalDLApplication.ID).ToString();
            CurrentTestype = TestType.Find(CurrentTestTypeId);
            lblFees.Text = CurrentTestype.Fees.ToString();
        }

        private int CurrentTestTypeId;
        private TestType CurrentTestype { get; set; }

        private void FrmTakeTest_Load(object sender, EventArgs e)
        {
            ModifyControls();
        }

        private void FrmTakeTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }
    }
}
