using DLMS.UserControls;
using DLMS_Business;
using System;
using System.Collections.Generic;
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

        public FrmAddEditLocalDrivingLicenceApplication(LocalDLApplication localDLApplication)
        {
            InitializeForm();
            CurrentLocalDLApplication = localDLApplication;
            ModifyControlsAccordingToCurrentLocalDLAppication();
            CurrentMode = Mode.Edit;
        }

        private void ModifyControlsAccordingToCurrentLocalDLAppication()
        {
            FillLicenceClassesCb();
            CurrentPerson = Person.Find(CurrentLocalDLApplication.ApplicantPersonID);
            ucPersonSearch1.SetPerson(CurrentPerson);
            ucPersonSearch1.ShowPersonData();
            ucPersonSearch1.ChangePersonSearchGroupBoxAbility(false);
            lblApplicationId.Text = CurrentLocalDLApplication.ID.ToString();
            lblApplicationDate.Text = CurrentLocalDLApplication.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = CurrentLocalDLApplication.PaidFees.ToString();
            lblCreatedBy.Text = CurrentLocalDLApplication.CreatedByUserName;
            cbLicenceClass.SelectedValue = CurrentLocalDLApplication.LicenceClassID;
        }

        private readonly decimal LocalApplicationTypeFees = ApplicationType.Find(1).Fees;

        private void ModifyControls()
        {
            FillLicenceClassesCb();
            ucPersonSearch1.ChangePersonSearchGroupBoxAbility();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = LocalApplicationTypeFees.ToString();
            lblCreatedBy.Text = UserSession.LoggedInUser.UserName;
            cbLicenceClass.SelectedIndex = 0;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPerson != null && CurrentLocalDLApplication == null && CurrentMode == Mode.Add)
            {
                tcApplicationInfo.SelectedIndex = 1;
            }
            else if (CurrentMode == Mode.Edit && CurrentLocalDLApplication != null)
            {
                tcApplicationInfo.SelectedIndex = 1;
            }
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
            CurrentLocalDLApplication = isPersonAdded ? null : CurrentLocalDLApplication;
        }

        private void HandlePersonDataReloaded(int personId)
        {
        }

        private void UcPersonSearch1_OnNextButtonAbilityChanged(bool isEnabled)
        {
            btnNext.Enabled = isEnabled;
        }

        private static Person CurrentPerson { get; set; }
        private static LocalDLApplication CurrentLocalDLApplication { get; set; }

        private void UcPersonSearch1_OnPersonIsShown(bool isSuccessful = true)
        {
            if (isSuccessful)
            {
                CurrentPerson = UcPersonSearch.CurrentPerson;
                HandleSelectIndexChangeForLicenceClassComboBox();
            }
        }

        public enum Mode { Add, Edit };

        public Mode CurrentMode { get; set; }

        private bool IsApplicationDuplicated()
        {
            return LocalDLApplication.
                GetApplicationIdForSamePersonAndLicenceClass(
                Int32.Parse(cbLicenceClass.SelectedValue.ToString()),
                CurrentPerson.ID) != 0;
        }

        private void SetDuplicationErrorForComboBox()
        {
            if (IsApplicationDuplicated())
            {
                int duplicateDLApplicationId = LocalDLApplication.
                GetApplicationIdForSamePersonAndLicenceClass(
                Int32.Parse(cbLicenceClass.SelectedValue.ToString()),
                CurrentPerson.ID);
                SetError(cbLicenceClass, $"An active application with the same licence class is " +
                    $"still active for the same person with ID {duplicateDLApplicationId}");
            }
            else
                SetError(cbLicenceClass, "");
        }

        private void CheckIfApplicationIsDuplicated()
        {
            if (!string.IsNullOrEmpty(cbLicenceClass.SelectedValue.ToString()))
            {
                if (CurrentLocalDLApplication == null ||
                    (CurrentLocalDLApplication != null &&
                    CurrentLocalDLApplication.LicenceClassID != Int32.Parse(cbLicenceClass.SelectedValue.ToString())))
                    SetDuplicationErrorForComboBox();
                else
                    SetError(cbLicenceClass, "");
            }
        }

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

        private void FrmAddEditLocalDrivingLicenceApplication_Load(object sender, EventArgs e)
        {
            ucPersonSearch1.InitializeFilterComboBox();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblFormHeader.Text = CurrentMode == Mode.Add ?
                "New Local Driving Licence Appllication" :
                "Update Local Driving Licence Appllication";
            this.Text = CurrentMode == Mode.Add ?
                "New Local Driving Licence Appllication" :
                "Update Local Driving Licence Appllication";
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
            return CurrentLocalDLApplication == null ? CurrentPerson != null && GetActiveErrorCount() == 0 :
                CurrentPerson != null && GetActiveErrorCount() == 0 &&
                cbLicenceClass.SelectedValue.ToString() != CurrentLocalDLApplication.LicenceClassID.ToString();
        }

        private void FrmAddEditLocalDrivingLicenceApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
            CurrentLocalDLApplication = null;
            CurrentPerson = null;
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
                CurrentLocalDLApplication = localDLApplication;
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
            CurrentLocalDLApplication.LicenceClassID = Int32.Parse(cbLicenceClass.SelectedValue.ToString());
            if (CurrentLocalDLApplication.Save())
            {
                MessageBox.Show("Local Driving Licence Applicatison is saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Something wrong happened", "Error",
                    MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveLocalDLApplication();
        }

        private void TcApplicationInfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabApplicationInfo)
            {
                if (CurrentPerson == null || (CurrentPerson != null && CurrentLocalDLApplication != null && CurrentMode == Mode.Add))
                {
                    e.Cancel = true;
                }
            }
        }

        private void HandleSelectIndexChangeForLicenceClassComboBox()
        {
            if (CurrentPerson != null)
            {
                CheckIfApplicationIsDuplicated();
                ChangeSaveBtnAbilityIfPossible();
            }
        }

        private void CbLicenceClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleSelectIndexChangeForLicenceClassComboBox();
        }

        public new event Action OnFormClosed;
    }
}
