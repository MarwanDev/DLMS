using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.Forms.People
{
    public partial class FrmShowPersonDetails : Form
    {
        public FrmShowPersonDetails(Person person)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            Utils.ChangeUcPersonInfoControllersUI(ucPersonInfo2, person);
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmShowPersonDetails_Load(object sender, System.EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            timer1.Start();
        }

        public new event Action OnFormClosed;

        private void FrmShowPersonDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucPersonInfo2.SetPerson(null);
            timer1.Stop();
            OnFormClosed?.Invoke();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Utils.CheckPersonAvailabilityWithTimer(timer1, ucPersonInfo2.CurrentPerson.ID, this);
        }
    }
}
