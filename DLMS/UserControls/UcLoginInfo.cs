using System;
using System.Windows.Forms;

namespace DLMS.UserControls
{
    public partial class UcLoginInfo: UserControl
    {
        public UcLoginInfo()
        {
            InitializeComponent();
        }

        public void SetUserId(int value) => lblUserId.Text = value.ToString();

        public int GetUserId()
        {
            return Int32.Parse(lblUserId.Text);
        }

        public void SetUserName(string value) => lblUserName.Text = value;

        public string GetUserName()
        {
            return lblUserName.Text;
        }

        public void SetIsActive(bool value)
        {
            lblIsActive.Text = value ? "Yes" : "No";
        }

        public bool GetIsActive()
        {
            return lblIsActive.Text == "Yes";
        }
    }
}
