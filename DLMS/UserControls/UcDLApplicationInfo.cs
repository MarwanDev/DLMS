using DLMS_Business;
using System;
using System.Windows.Forms;

namespace DLMS.UserControls
{
    public partial class UcDLApplicationInfo : UserControl
    {
        public UcDLApplicationInfo()
        {
            InitializeComponent();
        }

        public LocalDLApplication CurrentLocalDLApplication { get; set; }

        public void SetLocalDLApplication(LocalDLApplication localDLApplication)
        {
            CurrentLocalDLApplication = localDLApplication;
        }

        public void SetId(int value)
        {
            lblApplicationId.Text = value.ToString();
        }

        public int GetId()
        {
            return Int32.Parse(lblApplicationId.Text);
        }

        public int GetLocalDLApplicationId()
        {
            return Int32.Parse(lblApplicationId.Text);
        }

        public void SetLicence(string value)
        {
            lblLicenceClassTitle.Text = value;
        }

        public string GetLicence()
        {
            return lblLicenceClassTitle.Text;
        }

        public void SetPassedTests(int value)
        {
            lblPassedTests.Text = value.ToString() + "/3";
        }

        public int GetPassedTests()
        {
            return Int32.Parse((string)lblPassedTests.Text.Substring(0, 1));
        }

        public void SetApplicationId(int value)
        {
            lblApplicationId.Text = value.ToString();
        }

        public int GetApplicationId()
        {
            return Int32.Parse(lblApplicationId.Text);
        }

        public void SetApplicationDate(DateTime value)
        {
            lblDate.Text = value.ToShortDateString();
        }

        public DateTime GetApplicationDate()
        {
            return DateTime.Parse(lblDate.Text);
        }

        public void SetLastStatusDate(DateTime value)
        {
            lblStatusDate.Text = value.ToShortDateString();
        }

        public DateTime GetLastStatusDate()
        {
            return DateTime.Parse(lblStatusDate.Text);
        }

        public void SetStatus(string value)
        {
            lblStatus.Text = value;
        }

        public string GetStatus()
        {
            return lblStatus.Text;
        }

        public void SetFees(decimal value)
        {
            lblFees.Text = value.ToString();
        }

        public decimal GetFees()
        {
            return decimal.Parse(lblFees.Text);
        }

        public void SetCreatedByUserName(string value)
        {
            lblCreatedBy.Text = value;
        }

        public string GetCreatedByUserName()
        {
            return lblCreatedBy.Text;
        }

        public void SetApplicationType(string value)
        {
            lblApplicationType.Text = value;
        }

        public string GetApplicationType()
        {
            return lblApplicationType.Text;
        }

        public void SetApplicant(string value)
        {
            lblApplicantFullName.Text = value;
        }

        public string GetApplicant()
        {
            return lblApplicantFullName.Text;
        }
    }
}
