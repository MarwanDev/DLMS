using DLMS.Properties;
using DLMS_Business;
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
        private TestMode CurrentTestMode {  get; set; }
        private LocalDLApplication CurrentLocalDLApplication { get; set; }

        public FrmTestAppointments(TestMode testMode, LocalDLApplication localDLApplication)
        {
            InitializeComponent();
            CurrentTestMode = testMode;
            CurrentLocalDLApplication = localDLApplication;
            ChangeHeaderText();
            ChangeHeaderPictureBoxImage();
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

        }
    }
}
