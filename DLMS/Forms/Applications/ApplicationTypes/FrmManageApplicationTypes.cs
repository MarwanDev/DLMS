using DLMS.Properties;
using DLMS_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Applications.ApplicationTypes
{
    public partial class FrmManageApplicationTypes : Form
    {
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
            ucHeader1.SetText("Application Types");
            ucHeader1.SetImage(Resources.Application_Types_512);
            ucHeader1.SetColor(System.Drawing.Color.Red);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void GetAllApplicationTypesInGDV()
        {
            DataTable applicationTypes = ApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = applicationTypes;
            Utils.DisableDGVColumnSorting(dgvApplicationTypes);
            dgvApplicationTypes.Refresh();
            UpdateCountLabel();
        }

        private void UpdateCountLabel()
        {
            lblCount.Text = ApplicationType.GetAllApplicationTypesCount().ToString();
            lblCount.Refresh();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            GetAllApplicationTypesInGDV();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dgvApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void EditApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationType applicationType = ApplicationType.Find(SelectedApplicationTypeId);
            if (applicationType != null)
            {
                FrmUpdateApplicationType frmUpdateApplicationType = new FrmUpdateApplicationType(applicationType);
                frmUpdateApplicationType.OnFormClosed += GetAllApplicationTypesInGDV;
                frmUpdateApplicationType.ShowDialog();
            }
        }

        private int SelectedApplicationTypeId { get; set; }

        private void DgvApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                dgvApplicationTypes.ContextMenuStrip = null;
            else
            {
                dgvApplicationTypes.ContextMenuStrip = cmsApplicationTypes;
                SelectedApplicationTypeId = Int32.Parse(dgvApplicationTypes.Rows[e.RowIndex].Cells[0].Value?.ToString());
                DataGridView.HitTestInfo hit = dgvApplicationTypes.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvApplicationTypes.ClearSelection();
                    dgvApplicationTypes.Rows[hit.RowIndex].Selected = true;
                    dgvApplicationTypes.CurrentCell = dgvApplicationTypes.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private string GetSortingParameter(string sortingParameter)
        {
            switch (sortingParameter)
            {
                case "ID":
                    return "ApplicationTypeID";
                case "Title":
                    return "ApplicationTypeTitle";
                case "Fees":
                    return "ApplicationFees";
                default:
                    return sortingParameter;
            }
        }

        private void DgvApplicationTypes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string headerText = dgvApplicationTypes.Columns[e.ColumnIndex].HeaderText;
                ApplicationType.ApplySorting(GetSortingParameter(headerText));
                GetAllApplicationTypesInGDV();
            }
        }
    }
}
