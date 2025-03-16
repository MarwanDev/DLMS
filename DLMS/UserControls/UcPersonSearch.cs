using DLMS.Forms;
using System.IO;
using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.UserControls
{
    public partial class UcPersonSearch : UserControl
    {
        public UcPersonSearch()
        {
            InitializeComponent();
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        public static Person CurrentPerson { get; set; }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            btnPersonSearch.Enabled = !string.IsNullOrEmpty(tbSearch.Text.Trim());
            if (cbFilter.SelectedIndex == 1)
                tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, "[^0-9]", "");
        }

        private void TbSearch_MouseLeave(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Trim();
        }

        private void BtnPersonSearch_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
                CurrentPerson = Person.FindByNationalNo(tbSearch.Text.Trim());
            else
                CurrentPerson = Person.Find(Int32.Parse(tbSearch.Text.Trim()));
            if (CurrentPerson != null)
            {
                ShowPersonData();
                FrmAddEditPerson frmAddEditPerson = new FrmAddEditPerson(CurrentPerson);
                frmAddEditPerson.OnFormClosed += ReloadData;
                HandlePersonShow();
                ChangeNextButtonAbility();
            }
            else
            {
                ClearPersonData();
                ChangeNextButtonAbility(false);
                if (cbFilter.SelectedIndex == 0)
                    MessageBox.Show($"No person was found with national number {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"No person was found with person Id {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetFilterIndex()
        {
            return cbFilter.SelectedIndex;
        }

        private void HandlePersonShow()
        {
            OnPersonIsShown?.Invoke(true);
        }

        public event Action<bool> OnNextButtonAbilityChanged;
        public event Action<bool> OnPersonIsShown;
        public event Action<bool> OnPersonAdded;

        private void ChangeNextButtonAbility(bool isEnabled = true)
        {
            OnNextButtonAbilityChanged?.Invoke(isEnabled);
        }

        public void SetPerson(Person person)
        {
            CurrentPerson = person;
            ucPersonInfo1.SetPerson(person);
        }

        private void ReloadCurrentPersonData()
        {
            ucPersonInfo1.SetPerson(CurrentPerson);
            ucPersonInfo1.SetAddress(CurrentPerson.Address);
            ucPersonInfo1.SetPersonId(CurrentPerson.ID.ToString());
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
            this.Refresh();
        }

        private void ReloadData()
        {
            CurrentPerson = ucPersonInfo1.CurrentPerson;
            ReloadCurrentPersonData();
            if (int.TryParse(ucPersonInfo1.GetPersonId(), out int personId))
            {
                OnPersonDataReloaded?.Invoke(personId);
            }
        }

        public event Action<int> OnPersonDataReloaded;

        public void ChangePersonSearchGroupBoxAbility(bool isEnabled = true)
        {
            gbPersonSearch.Enabled = isEnabled;
        }

        public void InitializeFilterComboBox()
        {
            cbFilter.SelectedIndex = 0;
        }

        public void ShowPersonData()
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

        private void ClearPersonData()
        {
            ucPersonInfo1.SetPerson(null);
            ucPersonInfo1.SetPersonId("???");
            ucPersonInfo1.SetAddress("???");
            ucPersonInfo1.SetPersonName("???");
            ucPersonInfo1.SetNationalNo("???");
            ucPersonInfo1.SetGender("???");
            ucPersonInfo1.SetEmail("???");
            ucPersonInfo1.SetCountry("???");
            ucPersonInfo1.SetDateOfBirth("???");
            ucPersonInfo1.SetPhone("???");
            ucPersonInfo1.SetImageForNoData();
            ucPersonInfo1.HideEditLinkLabel();
            ucPersonInfo1.Refresh();
        }

        private void FromAddEditPerson_DataBack(object sender, int PersonID)
        {
            CurrentPerson = Person.Find(PersonID);
            if (CurrentPerson != null)
            {
                ucPersonInfo1.SetPersonId(PersonID.ToString());
                ucPersonInfo1.ReloadData();
                OnPersonAdded?.Invoke(true);
                HandlePersonShow();
            }
        }

        private void BtnAddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson frmAddEditPerson = new FrmAddEditPerson
            {
                CurrentMode = FrmAddEditPerson.Mode.Add
            };
            frmAddEditPerson.DataBack += FromAddEditPerson_DataBack;
            frmAddEditPerson.ShowDialog();
        }

        private void TbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
