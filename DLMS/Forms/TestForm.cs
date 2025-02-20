using System;
using System.Data;
using System.Windows.Forms;
using DLMS_Business;

namespace DLMS
{
    public partial class TestForm: Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            DataTable allPeople = Person.GetAllPeople();
            label1.Text = allPeople.Rows[0]["FirstName"].ToString();
            Person person = Person.Find(1025);
            label2.Text = Person.Find(1025) != null ? $"Yes {Person.Find(1025).LastName}" : "No";
        }
    }
}
