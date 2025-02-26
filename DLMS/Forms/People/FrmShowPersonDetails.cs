using DLMS_Business;
using System;
using System.IO;
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
            ucPersonInfo2.SetPerson(person);
            ucPersonInfo2.SetPersonId(ucPersonInfo2.CurrentPerson.ID.ToString());
            ucPersonInfo2.SetPersonName(ucPersonInfo2.CurrentPerson.FirstName + " " +
                ucPersonInfo2.CurrentPerson.SecondName + " " +
                ucPersonInfo2.CurrentPerson.ThirdName + " " +
                ucPersonInfo2.CurrentPerson.LastName);
            ucPersonInfo2.SetNationalNo(ucPersonInfo2.CurrentPerson.NationalNo);
            ucPersonInfo2.SetGender(ucPersonInfo2.CurrentPerson.Gender == 0 ? "Female" : "Male");
            ucPersonInfo2.SetEmail(ucPersonInfo2.CurrentPerson.Email);
            ucPersonInfo2.SetAddress(ucPersonInfo2.CurrentPerson.Address);
            ucPersonInfo2.SetCountry(ucPersonInfo2.CurrentPerson.Country);
            ucPersonInfo2.SetDateOfBirth(ucPersonInfo2.CurrentPerson.DateOfBirth.Date.ToString());
            ucPersonInfo2.SetPhone(ucPersonInfo2.CurrentPerson.Phone);
            if (!string.IsNullOrEmpty(ucPersonInfo2.CurrentPerson.ImagePath) && File.Exists(person.ImagePath))
                ucPersonInfo2.SetImage(ucPersonInfo2.CurrentPerson.ImagePath);
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmShowPersonDetails_Load(object sender, System.EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public new event Action OnFormClosed;

        private void FrmShowPersonDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }
    }
}
