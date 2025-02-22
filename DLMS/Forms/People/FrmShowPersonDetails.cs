using DLMS_Business;
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
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
