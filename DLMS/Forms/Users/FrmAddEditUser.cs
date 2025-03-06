using DLMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLMS.Forms.Users
{
    public partial class FrmAddEditUser : Form
    {
        public FrmAddEditUser()
        {
            InitializeComponent();
        }

        private void TbPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private Person CurrentPerson { get; set; }
        private User CurrentUser { get; set; }

        private void BtnPersonSearch_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
                CurrentPerson = Person.FindByNationalNo(tbSearch.Text.Trim());
            else
                CurrentPerson = Person.Find(Int32.Parse(tbSearch.Text.Trim()));
            if (CurrentPerson != null)
            {
                CurrentUser = User.FindByPersonId(CurrentPerson.ID);
                if (CurrentUser != null)
                {
                    if (cbFilter.SelectedIndex == 0)
                        MessageBox.Show($"A user with national number {CurrentPerson.NationalNo} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show($"A user with person Id {CurrentPerson.ID} already exists",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (cbFilter.SelectedIndex == 0)
                    MessageBox.Show($"No person was found with national number {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"No person was found with person Id {tbSearch.Text.Trim()}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            btnPersonSearch.Enabled = !string.IsNullOrEmpty(tbSearch.Text.Trim());
        }

        private void TbSearch_MouseLeave(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Trim();
        }
    }
}
