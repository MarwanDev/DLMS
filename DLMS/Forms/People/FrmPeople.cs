using DLMS.Properties;
using System.Data;
using System.Windows.Forms;
using DLMS_Business;
using System;
using DLMS.Forms.People;

namespace DLMS.Forms
{
    public partial class FrmPeople : Form
    {
        public FrmPeople()
        {
            InitializeComponent();
            ucHeader1.SetText("Manage People");
            ucHeader1.SetImage(Resources.People_400);
            ucHeader1.SetColor(System.Drawing.Color.Red);
            MinimizeBox = false;
            MaximizeBox = false;
            dgvPeople.ContextMenuStrip = cmsPerson;
        }

        private enum Mode { All, Filter };

        private static Mode CurrentMode;

        private void UpdateCountLabel(string searchQuery = "")
        {
            lblCount.Text = CurrentMode == Mode.All ?
                Person.GetAllPeopleCount().ToString() :
                Person.GetFilteredPeopleCount(searchQuery).ToString();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void GetAllPeopleInDGV()
        {
            DataTable people = Person.GetAllPeople();
            dgvPeople.DataSource = people;
            Utils.DisableDGVColumnSorting(dgvPeople);
            dgvPeople.Refresh();
            CurrentMode = Mode.All;
            UpdateCountLabel();
        }

        private void FrmPeople_Load(object sender, System.EventArgs e)
        {
            GetAllPeopleInDGV();
            dgvPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            AdjustTableColumWidths();
            cbFilter.Text = "None";
        }

        private void AdjustTableColumWidths()
        {
            int totalWidth = dgvPeople.ClientSize.Width;
            dgvPeople.Columns[0].Width = (int)(totalWidth * 0.05);
            dgvPeople.Columns[1].Width = (int)(totalWidth * 0.05);
        }

        private void BtnAddPerson_Click(object sender, System.EventArgs e)
        {
            FrmAddEditPerson frmAddEditPerson = new FrmAddEditPerson
            {
                CurrentMode = FrmAddEditPerson.Mode.Add
            };
            frmAddEditPerson.OnFormClosed += ReloadData;
            frmAddEditPerson.ShowDialog();
        }

        private string GetSortingParameter(string sortingParam)
        {
            switch (sortingParam)
            {
                case "National No.":
                    return "NationalNo";
                case "First Name":
                    return "FirstName";
                case "Second Name":
                    return "SecondName";
                case "Third Name":
                    return "ThirdName";
                case "Last Name":
                    return "LastName";
                case "Image Path":
                    return "ImagePath";
                default:
                    return sortingParam;
            }
        }

        private string GetFilterParameter()
        {
            switch (cbFilter.Text)
            {
                case "National No.":
                    return "NationalNo";
                case "First Name":
                    return "FirstName";
                case "Second Name":
                    return "SecondName";
                case "Third Name":
                    return "ThirdName";
                case "Last Name":
                    return "LastName";
                case "Nationality":
                    return "Country";
                default:
                    return cbFilter.Text;
            }
        }

        private void ManageFilterControlsUI()
        {
            if (cbFilter.Text == "First Name" ||
                cbFilter.Text == "National No." ||
                cbFilter.Text == "Second Name" ||
                cbFilter.Text == "Third Name" ||
                cbFilter.Text == "Last Name" ||
                cbFilter.Text == "Nationality" ||
                cbFilter.Text == "Phone" ||
                cbFilter.Text == "PersonId" ||
                cbFilter.Text == "Email")
            {
                pnlGender.Visible = false;
                tbSearch.Visible = true;
            }
            else if (cbFilter.Text == "Gender")
            {
                tbSearch.Visible = false;
                pnlGender.Location = new System.Drawing.Point(358, 270);
                pnlGender.Visible = true;
            }
            else
            {
                tbSearch.Visible = false;
                pnlGender.Visible = false;
            }
        }

        private void CbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ManageFilterControlsUI();
            Person.DisableSorting();
            rdbFemale.Checked = false;
            rdbMale.Checked = false;
            tbSearch.Text = "";
            GetAllPeopleInDGV();
        }

        private void FilterPeople(string searchKeyWord)
        {
            DataTable filteredPeople = tbSearch.Text != "" ?
                Person.FilterPeople(GetFilterParameter(), searchKeyWord) :
                Person.FilterPeople("Gender", searchKeyWord);
            dgvPeople.DataSource = filteredPeople;
            Utils.DisableDGVColumnSorting(dgvPeople);
            dgvPeople.Refresh();
            CurrentMode = Mode.Filter;
            UpdateCountLabel(searchKeyWord);
        }

        private void TbSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                GetAllPeopleInDGV();
                return;
            }
            if (tbSearch.Text == "\u007f")
            {
                tbSearch.Clear();
                GetAllPeopleInDGV();
            }
            if (cbFilter.Text == "PersonId")
            {
                tbSearch.Text = System.Text.RegularExpressions.Regex.Replace(tbSearch.Text, "[^0-9]", "");
            }
            FilterPeople(tbSearch.Text.Trim());
        }

        private void FilterWithGender()
        {
            string searchKeyWord = rdbMale.Checked ? "Male" : "Female";
            FilterPeople(searchKeyWord);
        }

        private void RdbGender_CheckedChanged(object sender, System.EventArgs e)
        {
            FilterWithGender();
        }

        private void TbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "PersonId")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private int SelectedPersonId { get; set; }

        private void DgvPeople_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvPeople.Columns[e.ColumnIndex].HeaderText;
                Person.ApplySorting(GetSortingParameter(headerText));
                ReloadData();
            }
        }

        private void DgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedPersonId = Int32.Parse(dgvPeople.Rows[e.RowIndex].Cells[0].Value?.ToString());
                DataGridView.HitTestInfo hit = dgvPeople.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvPeople.ClearSelection();
                    dgvPeople.Rows[hit.RowIndex].Selected = true;
                    dgvPeople.CurrentCell = dgvPeople.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void ReloadData()
        {
            if (tbSearch.Visible && tbSearch.Text.Trim() != "")
            {
                FilterPeople(tbSearch.Text.Trim());
            }
            else if (rdbFemale.Visible && rdbMale.Visible && (rdbFemale.Checked || rdbMale.Checked))
            {
                FilterWithGender();
            }
            else
            {
                GetAllPeopleInDGV();
            }
        }

        private void EditPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = Person.Find(SelectedPersonId);
            FrmAddEditPerson frmAddEditPerson = new FrmAddEditPerson(person)
            {
                CurrentMode = FrmAddEditPerson.Mode.Edit
            };
            frmAddEditPerson.OnFormClosed += ReloadData;
            frmAddEditPerson.ShowDialog();
        }

        private void ViewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = Person.Find(SelectedPersonId);
            if (person != null)
            {
                FrmShowPersonDetails frmShowPersonDetails = new FrmShowPersonDetails(person);
                frmShowPersonDetails.OnFormClosed += ReloadData;
                frmShowPersonDetails.ShowDialog();
            }
            else
                MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DeletePerson()
        {
            if (Person.DeletePerson(SelectedPersonId))
                MessageBox.Show($"Person Deleted Successfully!", "Sucecess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"Couldn't delet person {SelectedPersonId} as they're connected with other part(s) in the system",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            ReloadData();
        }

        private void DeletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete person witn ID: {SelectedPersonId}?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                DeletePerson();
        }
    }
}
