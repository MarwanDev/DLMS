﻿using DLMS.Properties;
using DLMS_Business;
using DLMS_Business.Licence;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DLMS.Forms.Licence
{
    public partial class FrmShowLicence : Form
    {
        public FrmShowLicence()
        {
            InitializeComponent();
        }

        private LicenceModel CurrentLicence { get; set; }

        public FrmShowLicence(LicenceModel licence)
        {
            InitializeComponent();
            CurrentLicence = licence;
            ChangeControlsUIAccordingToLicence();
        }

        private void ChangeControlsUIAccordingToLicence()
        {
            lblClassName.Text = CurrentLicence.ClassName;
            lblName.Text = CurrentLicence.FullName;
            lblbLicenceId.Text = CurrentLicence.ID.ToString();
            lblNatinalNo.Text = CurrentLicence.NationalNo;
            lblGender.Text = CurrentLicence.Gender;
            lblIssueDate.Text = CurrentLicence.IssueDate.ToShortDateString();
            lblExpDate.Text = CurrentLicence.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = CurrentLicence.IssueReason == 1 ? "First Time" :
                CurrentLicence.IssueReason == 2 ? "Renew" : 
                CurrentLicence.IssueReason == 3 ? "Replacement for lost" :
                CurrentLicence.IssueReason == 4 ? "Replacement for damaged" :
                CurrentLicence.IssueReason == 5 ? "Release for detained" : "";
            lblNotes.Text = !string.IsNullOrEmpty(CurrentLicence.Notes) ? CurrentLicence.Notes : "No Notes";
            lblIsActive.Text = CurrentLicence.IsActive ? "Yes" : "No";
            lblDOB.Text = CurrentLicence.IssueDate.ToShortDateString();
            lblDriverId.Text = CurrentLicence.DriverId.ToString();
            lblIsDetained.Text = DetainedLicence.IsLicenceDetained(CurrentLicence.ID) ? "Yes" : "No";
            pbPersonImage.Image = !string.IsNullOrEmpty(CurrentLicence.ImagePath) && File.Exists(CurrentLicence.ImagePath) ?
               Image.FromFile(CurrentLicence.ImagePath) : CurrentLicence.Gender == "Female" ?
               Resources.Female_512 : Resources.Male_512;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public new event Action OnFormClosed;

        private void FrmShowLicence_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke();
        }
    }
}
