using DLMS_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Licence
{
    public partial class FrmLicenceHistory : Form
    {
        public FrmLicenceHistory()
        {
            InitializeComponent();
        }

        public FrmLicenceHistory(Person person)
        {
            InitializeComponent();
            CurrentPerson = person;
            GetAllLocalLicencesInDGV();
            GetAllInternationalLicencesInDGV();
            Utils.ChangeUcPersonInfoControllersUI(ucPersonInfo2, person);
        }

        private Person CurrentPerson { get; set; }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetAllLocalLicencesInDGV()
        {
            DataTable localLicences = LicenceModel.GetAllLocalLicencesPerPerson(CurrentPerson.ID);
            dgvLocalLicences.DataSource = localLicences;
            Utils.DisableDGVColumnSorting(dgvLocalLicences);
            dgvLocalLicences.Refresh();
            UpdateCountLabels();
        }

        private void GetAllInternationalLicencesInDGV()
        {
            DataTable localLicences = LicenceModel.GetAllInternationalLicencesPerPerson(CurrentPerson.ID);
            dgvInternationalLicences.DataSource = localLicences;
            Utils.DisableDGVColumnSorting(dgvInternationalLicences);
            dgvInternationalLicences.Refresh();
            UpdateCountLabels();
        }

        private void UpdateCountLabels()
        {
            lblLocalCount.Text = LicenceModel.GetAllLocalLicencePerPersonCount(CurrentPerson.ID).ToString();
            lblInternationalCount.Text = LicenceModel.GetAllInternationalLicencePerPersonCount(CurrentPerson.ID).ToString();
            lblLocalCount.Refresh();
            lblInternationalCount.Refresh();
        }

        private void FrmLicenceHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }

        public new event Action OnFormClosed;
    }
}
