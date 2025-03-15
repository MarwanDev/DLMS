using DLMS.Properties;
using DLMS_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Tests.TestTypes
{
    public partial class FrmManageTestType : Form
    {
        public FrmManageTestType()
        {
            InitializeComponent();
            ucHeader1.SetText("Manage Test Types");
            ucHeader1.SetImage(Resources.TestType_512);
            ucHeader1.SetColor(System.Drawing.Color.Red);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void GetAllTestTypesInGDV()
        {
            DataTable testTypes = TestType.GetAllTestTypes();
            dgvTestTypes.DataSource = testTypes;
            Utils.DisableDGVColumnSorting(dgvTestTypes);
            dgvTestTypes.Refresh();
            UpdateCountLabel();
        }

        private void UpdateCountLabel()
        {
            lblCount.Text = TestType.GetAllTestTypesCount().ToString();
            lblCount.Refresh();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageTestType_Load(object sender, EventArgs e)
        {
            GetAllTestTypesInGDV();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dgvTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private string GetSortingParameter(string sortingParameter)
        {
            switch (sortingParameter)
            {
                case "ID":
                    return "TestTypeID";
                case "Title":
                    return "TestTypeTitle";
                case "Fees":
                    return "TestTypeFees";
                case "Description":
                    return "TestTypeDescription";
                default:
                    return sortingParameter;
            }
        }

        private int SelectedTestTypeId { get; set; }

        private void EditTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestType testType = TestType.Find(SelectedTestTypeId);
            if (testType != null)
            {
                FrmUpdateTestType frmUpdateTestType = new FrmUpdateTestType(testType);
                frmUpdateTestType.OnFormClosed += GetAllTestTypesInGDV;
                frmUpdateTestType.ShowDialog();
            }
        }

        private void DgvTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                dgvTestTypes.ContextMenuStrip = null;
            else
            {
                dgvTestTypes.ContextMenuStrip = cmsTestType;
                SelectedTestTypeId = Int32.Parse(dgvTestTypes.Rows[e.RowIndex].Cells[0].Value?.ToString());
                DataGridView.HitTestInfo hit = dgvTestTypes.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvTestTypes.ClearSelection();
                    dgvTestTypes.Rows[hit.RowIndex].Selected = true;
                    dgvTestTypes.CurrentCell = dgvTestTypes.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void DgvTestTypes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvTestTypes.Columns[e.ColumnIndex].HeaderText;
                TestType.ApplySorting(GetSortingParameter(headerText));
                GetAllTestTypesInGDV();
            }
        }
    }
}
