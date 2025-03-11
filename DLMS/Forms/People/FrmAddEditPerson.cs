using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DLMS.Properties;
using DLMS_Business;
using System.IO;

namespace DLMS.Forms
{
    public partial class FrmAddEditPerson : Form
    {
        public FrmAddEditPerson()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private static int CountryID { set; get; }

        private Person CurrentPerson { get; set; }

        public FrmAddEditPerson(Person person)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            ModifyControlsAccordingToPerson(person);
        }

        private void ModifyControlsAccordingToPerson(Person person)
        {
            CurrentPerson = person ?? null;
            lblId.Text = person.ID.ToString();
            tbFirstName.Text = person.FirstName;
            tbSecondName.Text = person.SecondName;
            tbThirdName.Text = person.ThirdName;
            tbLastName.Text = person.LastName;
            tbNationalNumber.Text = person.NationalNo;
            dtpDOB.Value = person.DateOfBirth;
            tbEmail.Text = person.Email;
            rtbAddress.Text = person.Address;
            tbPhone.Text = person.Phone;
            rdbFemale.Checked = person.Gender == 0;
            rdbMale.Checked = person.Gender == 1;
            FillCountriesCb();
            CountryID = person.NationalityCountryID;
            ChangeSetImageLinkLabelText();
        }

        public enum Mode { Add, Edit };

        public Mode CurrentMode { get; set; }

        private Person Person { set; get; }

        private readonly Dictionary<Control, string> errorTracker = new Dictionary<Control, string>();

        private void SetError(Control control, string errorMessage)
        {
            errorProvider1.SetError(control, errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
                errorTracker[control] = errorMessage;
            else
                errorTracker.Remove(control);
        }

        private int GetActiveErrorCount()
        {
            return errorTracker.Count;
        }

        private void ChangeRemoveImageLinkLabelVisibility(bool isOnLoad = true)
        {
            if (isOnLoad)
                llRemoveImage.Visible = CurrentPerson != null &&
                    !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
                    File.Exists(CurrentPerson.ImagePath);
            else
                llRemoveImage.Visible = !string.IsNullOrEmpty(TempImagePath) &&
                    File.Exists(TempImagePath);
        }

        private void ChangeSetImageLinkLabelText(bool isOnLoad = true)
        {
            //llSetImage.Text = CurrentPerson != null &&
            //    !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
            //    File.Exists(CurrentPerson.ImagePath) &&
            //    !string.IsNullOrEmpty(NewImagePath) &&
            //    File.Exists(NewImagePath) && !string.IsNullOrEmpty(TempImagePath) &&
            //    File.Exists(TempImagePath) ? "Change Image" : "Set Image";
            if (isOnLoad)
                llSetImage.Text = CurrentPerson != null &&
                    !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
                    File.Exists(CurrentPerson.ImagePath) ? "Change Image" : "Set Image";
            else
                llSetImage.Text = !string.IsNullOrEmpty(TempImagePath) &&
                    File.Exists(TempImagePath) ? "Change Image" : "Set Image";
        }

        private void FrmAddEditPerson_Load(object sender, EventArgs e)
        {
            ResetInputsPlacehodlers();
            SetMaxDate();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            FillCountriesCb();
            ChangeRemoveImageLinkLabelVisibility();
            if (CurrentMode == Mode.Add)
            {
                rdbMale.Checked = false;
                rdbFemale.Checked = false;
                pbPersonImage.Image = Resources.question_mark_96;
            }
            else
            {
                cbCountry.SelectedValue = CountryID;
            }
            lblHeader.Text = CurrentMode == Mode.Add ? "Add New Person" : "Edit Person";
            timer1.Enabled = true;
        }

        private void FillCountriesCb()
        {
            DataTable dataTable = Country.GetAllCountries();
            cbCountry.DataSource = dataTable;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
        }

        private void ResetInputsPlacehodlers()
        {
            if (CurrentMode == Mode.Add)
            {
                tbFirstName.Text = tbFirstName.Tag.ToString();
                tbSecondName.Text = tbSecondName.Tag.ToString();
                tbThirdName.Text = tbThirdName.Tag.ToString();
                tbLastName.Text = tbLastName.Tag.ToString();
                tbFirstName.ForeColor = System.Drawing.Color.LightGray;
                tbSecondName.ForeColor = System.Drawing.Color.LightGray;
                tbThirdName.ForeColor = System.Drawing.Color.LightGray;
                tbLastName.ForeColor = System.Drawing.Color.LightGray;
            }
        }

        private void SetMaxDate()
        {
            DateTime dtNow = DateTime.Now;
            dtpDOB.MaxDate = dtNow.AddYears(-18);
        }

        private void TbName_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == tb.Tag.ToString())
                {
                    tb.ForeColor = System.Drawing.Color.Black;
                    tb.Text = "";
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void TbNationalNumber_Leave(object sender, EventArgs e)
        {
            if (Person.DoesPersonExist("NationalNo", tbNationalNumber.Text.Trim()) && tbNationalNumber.Text.Trim() != "")
            {
                SetError(tbNationalNumber, $"A person with the National Number {tbNationalNumber.Text} already exists");
            }
            else if (tbNationalNumber.Text.Trim() == "")
            {
                SetError(tbNationalNumber, $"Please enter your national number");
            }
            else
            {
                SetError(tbNationalNumber, "");
            }
            tbNationalNumber.Text = tbNationalNumber.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void TbName_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text.Trim() == "")
                {
                    tb.Text = tb.Tag.ToString();
                    tb.ForeColor = System.Drawing.Color.LightGray;
                    SetError(tb, $"Pleas enter a valid {tb.Tag}");
                }
                else
                    SetError(tb, "");
                tb.Text = tb.Text.Trim();
                ChangeSaveBtnAbilityIfPossible();
            }
        }

        private bool ShouldSaveBtnBeEnabled()
        {
            return GetActiveErrorCount() == 0 &&
                (rdbFemale.Checked || rdbMale.Checked) &&
                tbFirstName.Text.Trim() != "" &&
                tbSecondName.Text.Trim() != "" &&
                tbThirdName.Text.Trim() != "" &&
                tbLastName.Text.Trim() != "" &&
                tbNationalNumber.Text.Trim() != "" &&
                tbPhone.Text.Trim() != "" &&
                rtbAddress.Text.Trim() != "";
        }

        private void ChangeSaveBtnAbilityIfPossible()
        {
            if (ShouldSaveBtnBeEnabled())
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void TbEmail_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(tbEmail.Text.Trim()) && tbEmail.Text.Trim() != "")
            {
                SetError(tbEmail, $"Please enter a valid email");
            }
            else
            {
                SetError(tbEmail, "");
            }
            tbEmail.Text = tbEmail.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void RtbAddress_Leave(object sender, EventArgs e)
        {
            if (rtbAddress.Text.Trim() == "")
                SetError(rtbAddress, "Please enter address");
            else
                SetError(rtbAddress, "");
            rtbAddress.Text = rtbAddress.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void TbPhone_Leave(object sender, EventArgs e)
        {
            if (tbPhone.Text.Trim() == "")
                SetError(tbPhone, "Please enter a valid phone number");
            else
                SetError(tbPhone, "");
            tbPhone.Text = tbPhone.Text.Trim();
            ChangeSaveBtnAbilityIfPossible();
        }

        private void RdbGender_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = TempImagePath != null ? Image.FromFile(TempImagePath) :
                ((CurrentPerson != null && !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
                File.Exists(CurrentPerson.ImagePath)) ?
                Image.FromFile(CurrentPerson.ImagePath) :
                rdbFemale.Checked ? Resources.Female_512 : Resources.Male_512);
            ChangeSaveBtnAbilityIfPossible();
        }

        private string GetToBeSavedPersonImagePath()
        {
            if (IsImageRemoved)
                return null;
            //return pbPersonImage.Image != Resources.Male_512 &&
            //    pbPersonImage.Image != Resources.Female_512 &&
            //    pbPersonImage.Image != Resources.question_mark_96 &&
            //    pbPersonImage.Image != null ?
            //    !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
            //    File.Exists(CurrentPerson.ImagePath) &&
            //    //!string.IsNullOrEmpty(NewImagePath) &&
            //    //File.Exists(NewImagePath) &&
            //    !IsImageRemoved ? CurrentPerson.ImagePath :
            //    !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
            //    File.Exists(CurrentPerson.ImagePath) &&
            //    IsImageRemoved ? null : !string.IsNullOrEmpty(NewImagePath) && 
            //    File.Exists(NewImagePath) ? NewImagePath : null : null;
            return pbPersonImage.Image != Resources.Male_512 &&
                    pbPersonImage.Image != Resources.Female_512 &&
                    pbPersonImage.Image != Resources.question_mark_96 &&
                    pbPersonImage.Image != null ?
                    !string.IsNullOrEmpty(NewImagePath) ?
                    NewImagePath :
                    CurrentPerson != null &&
                    !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
                    File.Exists(CurrentPerson.ImagePath) ? CurrentPerson.ImagePath : null : null;
        }

        private bool IsImageRemoved { get; set; }

        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        private void SaveAddition()
        {
            Person = new Person
            {
                FirstName = tbFirstName.Text,
                SecondName = tbSecondName.Text,
                ThirdName = tbThirdName.Text,
                LastName = tbLastName.Text,
                NationalNo = tbNationalNumber.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
                Address = rtbAddress.Text,
                DateOfBirth = dtpDOB.Value.Date,
                NationalityCountryID = cbCountry.SelectedIndex + 1,
                Gender = (byte)(rdbFemale.Checked ? 0 : 1),
                ImagePath = GetToBeSavedPersonImagePath()
            };
            if (Person.Save())
            {
                MessageBox.Show($"Person added succesfully with PersonId {Person.ID}", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                lblId.Text = Person.ID.ToString();
                SaveNewImageFile();
                CurrentMode = Mode.Edit;
                CurrentPerson = Person;
                lblHeader.Text = "Edit Person";
                DataBack?.Invoke(this, CurrentPerson.ID);
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void SaveUpdate()
        {
            CurrentPerson.FirstName = tbFirstName.Text;
            CurrentPerson.SecondName = tbSecondName.Text;
            CurrentPerson.ThirdName = tbThirdName.Text;
            CurrentPerson.LastName = tbLastName.Text;
            CurrentPerson.NationalNo = tbNationalNumber.Text;
            CurrentPerson.Email = tbEmail.Text;
            CurrentPerson.Phone = tbPhone.Text;
            CurrentPerson.Address = rtbAddress.Text;
            CurrentPerson.DateOfBirth = dtpDOB.Value.Date;
            CurrentPerson.NationalityCountryID = Int32.Parse(cbCountry.SelectedValue.ToString());
            CurrentPerson.Gender = (byte)(rdbFemale.Checked ? 0 : 1);
            CurrentPerson.ImagePath = GetToBeSavedPersonImagePath();
            if (CurrentPerson.Save())
            {
                MessageBox.Show($"Person updated succesfully", "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                if (CurrentPerson.ImagePath != OldImagePath)
                    DeleteOldImage();
                SaveNewImageFile();
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CurrentMode == Mode.Add)
                SaveAddition();
            else
                SaveUpdate();
        }

        private string OldImagePath { set; get; }

        private string NewImagePath { set; get; }

        private void DeleteOldImage()
        {
            if (File.Exists(OldImagePath))
            {
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(OldImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong. Please try again! {ex}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SaveNewImageFile()
        {
            if (!string.IsNullOrEmpty(NewImagePath))
            {
                try
                {
                    File.Copy(TempImagePath, NewImagePath, true);
                }
                catch (Exception)
                {
                    //MessageBox.Show($"Error Saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string NewFileExtension { set; get; }

        private string TempImagePath { set; get; }

        private void LlSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentPerson != null &&
                !string.IsNullOrEmpty(CurrentPerson.ImagePath) &&
                File.Exists(CurrentPerson.ImagePath))
            {
                OldImagePath = CurrentPerson.ImagePath;
            }
            if (fdPersonImage.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = fdPersonImage.FileName;
                FileInfo fi = new FileInfo(sourceFilePath);
                NewFileExtension = fi.Extension;
                string targetDirectory = @"C:\dlms-people\images";
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                string uniqueId = Guid.NewGuid().ToString();
                string fileName = Path.GetFileName(uniqueId) + NewFileExtension;
                string targetFilePath = Path.Combine(targetDirectory, fileName);
                NewImagePath = targetFilePath;
                try
                {
                    TempImagePath = sourceFilePath;
                    pbPersonImage.Image = Image.FromFile(TempImagePath);
                    ChangeRemoveImageLinkLabelVisibility(false);
                    IsImageRemoved = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public new event Action OnFormClosed;

        private void FrmAddEditPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        private void ChangePictureBoxImageWithNoImageSet()
        {
            pbPersonImage.Image = rdbFemale.Checked ? Resources.Female_512 :
                rdbMale.Checked ? Resources.Male_512 : Resources.question_mark_96;
        }

        private void ClearAssignedImagePaths()
        {
            TempImagePath = null;
            NewImagePath = null;
        }

        private void LlRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePictureBoxImageWithNoImageSet();
            ClearAssignedImagePaths();
            ChangeSetImageLinkLabelText(false);
            ChangeRemoveImageLinkLabelVisibility(false);
            IsImageRemoved = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentPerson != null && CurrentMode == Mode.Edit)
                Utils.CheckPersonAvailabilityWithTimer(timer1, CurrentPerson.ID, this);
        }
    }
}
