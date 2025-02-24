using DLMS_Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace DLMS.Forms.People
{
    public partial class FrmShowPersonDetails : Form
    {
        public FrmShowPersonDetails()
        {
            InitializeComponent();
        }

        public FrmShowPersonDetails(Person person)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            ucPersonInfo2.SetPerson(person);
            ucPersonInfo2.SetPersonId(person.ID.ToString());
            ucPersonInfo2.SetPersonName(person.FirstName + " " +
                person.SecondName + " " +
                person.ThirdName + " " +
                person.LastName);
            ucPersonInfo2.SetNationalNo(person.NationalNo);
            ucPersonInfo2.SetGender(person.Gender == 0 ? "Female" : "Male");
            ucPersonInfo2.SetEmail(person.Email);
            ucPersonInfo2.SetAddress(person.Address);
            ucPersonInfo2.SetCountry(person.Country);
            ucPersonInfo2.SetDateOfBirth(person.DateOfBirth.ToString());
            ucPersonInfo2.SetPhone(person.Phone);
            if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath))
                ucPersonInfo2.SetImage(person.ImagePath);
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
