using DLMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLMS.Forms.Applications.ApplicationTypes
{
    public partial class FrmManageApplicationTypes: Form
    {
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
            ucHeader1.SetText("Manage Application Types");
            ucHeader1.SetImage(Resources.Application_Types_512);
            ucHeader1.SetColor(System.Drawing.Color.Red);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
