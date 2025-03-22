using DLMS_Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace DLMS.Forms.Applications.LocalDrivingLicenceApplications
{
    public partial class FrmShowLocalDLApplicationDetails : Form
    {
        public FrmShowLocalDLApplicationDetails()
        {
            InitializeForm();
        }

        public FrmShowLocalDLApplicationDetails(LocalDLApplication localDLApplication)
        {
            InitializeForm();
            CurrentLocalDLApplication = localDLApplication;
            ModifyControlsAccordingToCurrentLocalDLAppication();
        }


        private void InitializeForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private static LocalDLApplication CurrentLocalDLApplication { get; set; }
        private static Person CurrentPerson { get; set; }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyControlsAccordingToCurrentLocalDLAppication()
        {
            CurrentPerson = Person.Find(CurrentLocalDLApplication.ApplicantPersonID);
            ucPersonInfo1.SetPerson(CurrentPerson);
            ShowPersonData();
            lblApplicationId.Text = CurrentLocalDLApplication.ID.ToString();
            lblApplicationDate.Text = CurrentLocalDLApplication.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = CurrentLocalDLApplication.PaidFees.ToString();
            lblCreatedBy.Text = CurrentLocalDLApplication.CreatedByUserName;
            lblLicenceClass.Text = CurrentLocalDLApplication.LicenceClassName;
        }

        private void ShowPersonData()
        {
            ucPersonInfo1.SetPerson(CurrentPerson);
            ucPersonInfo1.SetPersonId(CurrentPerson.ID.ToString());
            ucPersonInfo1.SetAddress(CurrentPerson.Address);
            ucPersonInfo1.SetPersonName(CurrentPerson.FirstName + " " +
                CurrentPerson.SecondName + " " +
                CurrentPerson.ThirdName + " " +
                CurrentPerson.LastName);
            ucPersonInfo1.SetNationalNo(CurrentPerson.NationalNo);
            ucPersonInfo1.SetGender(CurrentPerson.Gender == 0 ? "Female" : "Male");
            ucPersonInfo1.SetEmail(CurrentPerson.Email);
            ucPersonInfo1.SetCountry(CurrentPerson.Country);
            ucPersonInfo1.SetDateOfBirth(CurrentPerson.DateOfBirth.Date.ToString());
            ucPersonInfo1.SetPhone(CurrentPerson.Phone);
            if (!string.IsNullOrEmpty(CurrentPerson.ImagePath) && File.Exists(CurrentPerson.ImagePath))
            {
                ucPersonInfo1.SetImage(CurrentPerson.ImagePath);
                ucPersonInfo1.RefreshImageBox();
            }
            else
            {
                ucPersonInfo1.SetImageForNoImageUser();
            }
            ucPersonInfo1.ShowEditLinkLabel();
            ucPersonInfo1.Refresh();
        }

        private void FrmShowLocalDLApplicationDetails_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public new event Action OnFormClosed;

        private void FrmShowLocalDLApplicationDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
            CurrentLocalDLApplication = null;
            CurrentPerson = null;
        }
    }
}
