using DLMS.Properties;
using DLMS_Business;
using System.Data;
using System.Windows.Forms;

namespace DLMS.Forms.Users
{
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();
            ucHeader1.SetText("Manage Users");
            ucHeader1.SetImage(Resources.Users_2_400);
            ucHeader1.SetColor(System.Drawing.Color.Red);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void GetAllUsersInDGV()
        {
            DataTable users = User.GetAllUsers();
            dgvUsers.DataSource = users;
            dgvUsers.Refresh();
            //CurrentMode = Mode.All;
            //UpdateCountLabel();
        }

        private void FrmManageUsers_Load(object sender, System.EventArgs e)
        {
            GetAllUsersInDGV();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Utils.DisableDGVColumnSorting(dgvUsers);

        }
    }
}
