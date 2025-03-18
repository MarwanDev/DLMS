using DLMS.UserControls;
using DLMS_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Applications.LocalDrivingLicenceApplications
{
    public partial class FrmAddEditLocalDrivingLicenceApplication : Form
    {
        public FrmAddEditLocalDrivingLicenceApplication()
        {
            InitializeForm();
            ModifyControls();
            CurrentMode = Mode.Add;
        }

        private readonly decimal LocalApplicationTypeFees = ApplicationType.Find(1).Fees;

        private void ModifyControls()
        {
            FillLicenceClassesCb();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = LocalApplicationTypeFees.ToString();
            lblCreatedBy.Text = UserSession.LoggedInUser.ID.ToString();
            cbLicenceClass.SelectedIndex = 0;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            tcApplicationInfo.SelectedIndex = 1;
        }

        private void FillLicenceClassesCb()
        {
            DataTable dataTable = LicenceClass.GetAllLicenceClassesForDropDown();
            cbLicenceClass.DataSource = dataTable;
            cbLicenceClass.DisplayMember = "ClassName";
            cbLicenceClass.ValueMember = "LicenseClassID";
        }

        private void InitializeForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            ucPersonSearch1.OnNextButtonAbilityChanged += UcPersonSearch1_OnNextButtonAbilityChanged;
            ucPersonSearch1.OnPersonIsShown += UcPersonSearch1_OnPersonIsShown;
            ucPersonSearch1.OnPersonDataReloaded += HandlePersonDataReloaded;
            ucPersonSearch1.OnPersonAdded += HandlePersonAdded;
        }

        private void HandlePersonAdded(bool isPersonAdded = true)
        {
            CurrentDLApplication = isPersonAdded ? null : CurrentDLApplication;
        }

        private void HandlePersonDataReloaded(int personId)
        {
            //User user = User.FindByPersonId(personId);
            //if (user != null)
            //    CurrentUser = user;
        }

        private void UcPersonSearch1_OnNextButtonAbilityChanged(bool isEnabled)
        {
            btnNext.Enabled = isEnabled;
        }

        private static Person CurrentPerson { get; set; }
        private static LocalDLApplication CurrentDLApplication { get; set; }

        private void UcPersonSearch1_OnPersonIsShown(bool isSuccessful = true)
        {
            if (isSuccessful)
            {
                CurrentPerson = UcPersonSearch.CurrentPerson;
                //CurrentUser = User.FindByPersonId(CurrentPerson.ID);
                //if (CurrentUser != null)
                //{
                //    if (ucPersonSearch1.GetFilterIndex() == 0)
                //        MessageBox.Show($"A user with national number {CurrentPerson.NationalNo} already exists",
                //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    else
                //        MessageBox.Show($"A user with person Id {CurrentPerson.ID} already exists",
                //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //ChangeSaveBtnAbilityIfPossible();
            }
        }

        public enum Mode { Add, Edit };

        public Mode CurrentMode { get; set; }

        private void FrmAddEditLocalDrivingLicenceApplication_Load(object sender, EventArgs e)
        {
            ucPersonSearch1.InitializeFilterComboBox();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblFormHeader.Text = CurrentMode == Mode.Add ? "New Local Driving Licence Appllication" : "Update Local Driving Licence Appllication";
            this.Text = CurrentMode == Mode.Add ? "New Local Driving Licence Appllication" : "Update Local Driving Licence Appllication";
            ChangeSaveBtnAbilityIfPossible();
        }

        private void ChangeSaveBtnAbilityIfPossible()
        {
            if (ShouldSaveBtnBeEnabled())
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private bool ShouldSaveBtnBeEnabled()
        {
            //return GetActiveErrorCount() == 0 &&
            //    tbUserName.Text.Trim() != "" &&
            //    tbPassword.Text.Trim() != "" &&
            //    tbConfirmPassword.Text.Trim() != "";
            return true;
        }

        private void FrmAddEditLocalDrivingLicenceApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveLocalDLApplication()
        {
            if (CurrentMode == Mode.Add)
                SaveAddition();
            else
                SaveUpdate();
        }

        private void SaveAddition()
        {
            LocalDLApplication localDLApplication = new LocalDLApplication
            {
                ApplicantPersonID = CurrentPerson.ID,
                ApplicationDate = DateTime.Parse(lblApplicationDate.Text),
                ApplicationTypeID = 1,
                ApplicationStatus = 1,
                LastStatusDate = DateTime.Parse(lblApplicationDate.Text),
                PaidFees = LocalApplicationTypeFees,
                CreatedByUserID = UserSession.LoggedInUser.ID,
                LicenceClassID = Int32.Parse(cbLicenceClass.SelectedValue.ToString()),
            };
            if (localDLApplication.Save())
            {
                MessageBox.Show($"Local Driving Licence Appllication added Successfully with ID {localDLApplication.ID}",
                    "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                lblApplicationId.Text = localDLApplication.ID.ToString();
                CurrentDLApplication = localDLApplication;
                CurrentMode = Mode.Edit;
                lblFormHeader.Text = "Update Local Driving Licence Appllication";
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void SaveUpdate()
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveLocalDLApplication();
        }
    }
}
