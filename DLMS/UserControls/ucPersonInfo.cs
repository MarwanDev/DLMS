using DLMS.Forms;
using DLMS.Properties;
using System.Windows.Forms;

namespace DLMS.UserControls
{
    public partial class UcPersonInfo : UserControl
    {
        public UcPersonInfo()
        {
            InitializeComponent();
        }

        public string GetPersonId() => lblPersonId.Text;
        public void SetPersonId(string value) => lblPersonId.Text = value;

        public string GetPersonName() => lblName.Text;
        public void SetPersonName(string value)
        {
            lblName.Text = value;
        }

        public string GetNationalNo() => lblNationalNo.Text;
        public void SetNationalNo(string value) => lblNationalNo.Text = value;

        public string GetGender() => lblGender.Text;
        public void SetGender(string value) => lblGender.Text = value;

        public string GetEmail() => lblEmail.Text;
        public void SetEmail(string value) => lblEmail.Text = value;

        public string GetAddress() => lblAddress.Text;
        public void SetAddress(string value) => lblAddress.Text = value;

        public string GetDateOfBirth() => lblDOB.Text;
        public void SetDateOfBirth(string value) => lblDOB.Text = value;

        public string GetPhone() => lblPhone.Text;
        public void SetPhone(string value) => lblPhone.Text = value;

        public string GetCountry() => lblCountry.Text;
        public void SetCountry(string value) => lblCountry.Text = value;

        private void UcPersonInfo_Load(object sender, System.EventArgs e)
        {
            pbPersonImage.Image = GetGender() == "Female" ? Resources.Female_512 : Resources.Male_512;
        }

        private void LblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditPerson frmAddEditPerson = new FrmAddEditPerson();
            frmAddEditPerson.ShowDialog();
        }
    }
}
