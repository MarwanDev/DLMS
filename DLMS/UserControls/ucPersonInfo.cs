using DLMS.Forms;
using DLMS.Properties;
using DLMS_Business;
using System;
using System.Drawing;
using System.IO;
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

        public Image GetImage() => pbPersonImage.Image;

        public void SetImage(string value) => pbPersonImage.Image = !string.IsNullOrEmpty(value) &&
            File.Exists(value) ? Image.FromFile(value) :
            CurrentPerson.Gender == 0 ? Resources.Female_512 :
            Resources.Male_512;

        public Person CurrentPerson { get; set; }

        private string TempImagePath { get; set; }

        private void CreateTempImage()
        {
            string sourceFilePath = CurrentPerson.ImagePath;
            FileInfo fi = new FileInfo(sourceFilePath);
            string fileExtension = fi.Extension;
            string targetDirectory = @"C:\dlms-people\temp";
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            string uniqueId = Guid.NewGuid().ToString();
            string fileName = Path.GetFileName(uniqueId) + fileExtension;
            string targetFilePath = Path.Combine(targetDirectory, fileName);
            File.Copy(CurrentPerson.ImagePath, targetFilePath);
            try
            {
                TempImagePath = targetFilePath;
                SetImage(TempImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetPerson(Person person) => CurrentPerson = person;

        private void UcPersonInfo_Load(object sender, System.EventArgs e)
        {
            if (CurrentPerson != null)
            {
                if (!string.IsNullOrEmpty(CurrentPerson.ImagePath) && File.Exists(CurrentPerson.ImagePath))
                {
                    SetImage(CurrentPerson.ImagePath);
                }
                else
                {
                    pbPersonImage.Image = CurrentPerson.Gender == 0 ? Resources.Female_512 : Resources.Male_512;
                }
            }
        }

        public void SetImageForNoImageUser()
        {
            pbPersonImage.Image = CurrentPerson.Gender == 0 ? Resources.Female_512 : Resources.Male_512;
        }

        public void SetImageForNoData()
        {
            pbPersonImage.Image = Resources.question_mark_96;
        }

        public void RefreshImageBox()
        {
            pbPersonImage.Refresh();
        }

        private void ReloadData()
        {
            SetPerson(Person.Find(Convert.ToInt32(GetPersonId())));
            SetAddress(CurrentPerson.Address);
            SetPersonName(CurrentPerson.FirstName + " " +
                CurrentPerson.SecondName + " " +
                CurrentPerson.ThirdName + " " +
                CurrentPerson.LastName);
            SetNationalNo(CurrentPerson.NationalNo);
            SetGender(CurrentPerson.Gender == 0 ? "Female" : "Male");
            SetEmail(CurrentPerson.Email);
            SetCountry(CurrentPerson.Country);
            SetDateOfBirth(CurrentPerson.DateOfBirth.Date.ToString());
            SetPhone(CurrentPerson.Phone);
            if (!string.IsNullOrEmpty(CurrentPerson.ImagePath) && File.Exists(CurrentPerson.ImagePath))
            {
                SetImage(CurrentPerson.ImagePath);
                pbPersonImage.Refresh();
            }
            else
            {
                pbPersonImage.Image = CurrentPerson.Gender == 0 ? Resources.Female_512 : Resources.Male_512;
            }
            this.Refresh();
        }

        private void LblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person person = Person.Find(Convert.ToInt32(GetPersonId()));
            FrmAddEditPerson frmAddEditPerson = new FrmAddEditPerson(person)
            {
                CurrentMode = FrmAddEditPerson.Mode.Edit
            };
            if (!string.IsNullOrEmpty(CurrentPerson.ImagePath) && File.Exists(CurrentPerson.ImagePath))
            {
                CreateTempImage();
            }
            frmAddEditPerson.OnFormClosed += ReloadData;
            frmAddEditPerson.ShowDialog();
        }
    }
}
