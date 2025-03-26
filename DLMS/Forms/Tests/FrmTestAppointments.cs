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
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
