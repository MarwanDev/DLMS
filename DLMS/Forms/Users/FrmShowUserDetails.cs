using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.Forms.Users
{
    public partial class FrmShowUserDetails: Form
    {
        public FrmShowUserDetails()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        public FrmShowUserDetails(int userId)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            CurrentUser = User.Find(userId);
            if (CurrentUser != null)
            {
                ucPersonInfo1.SetPersonId(CurrentUser.PersonID.ToString());
                ucPersonInfo1.ReloadData();
                ucLoginInfo1.SetUserId(CurrentUser.ID);
                ucLoginInfo1.SetUserName(CurrentUser.UserName);
                ucLoginInfo1.SetIsActive(CurrentUser.IsActive);
            }
        }

        public new event Action OnFormClosed;

        private User CurrentUser { get; set; }

        private void FrmShowUserDetails_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShowUserDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentUser != null)
                Utils.CheckUserAvailabilityWithTimer(timer1, CurrentUser.ID, this);
        }
    }
}
