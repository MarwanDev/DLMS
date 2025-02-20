using System;
using System.Windows.Forms;

namespace DLMS.User_Controls
{
    public partial class UcFormHeader : UserControl
    {
        public UcFormHeader()
        {
            InitializeComponent();
        }

        public void SetTitleText(string title)
        {
            lblTitle.Text = title;
        }

        public string GetTitleText()
        {
            return lblTitle.Text;
        }

        public void SetIdLabelText(string title)
        {
            lblIdlabel.Text = title;
        }

        public string GetIdlabelText()
        {
            return lblIdlabel.Text;
        }

        public void SetId(int id)
        {
            lblIdValue.Text = id != -1 ? id.ToString() : "N/A";
        }

        public int GetId()
        {
            return Int32.Parse(lblIdValue.Text);
        }

        private void UcPersonForm_Load(object sender, EventArgs e)
        {

        }
    }
}
