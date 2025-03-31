using DLMS.UserControls;
using DLMS_Business;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DLMS
{
    class Utils
    {
        public static void CheckPersonAvailabilityWithTimer(Timer timer, int id, Form form)
        {
            if (!Person.DoesPersonExist(id))
            {
                timer.Stop();
                if (MessageBox.Show($"Person with id {id} is not there any more!",
                     "Heads up!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    form.Close();
            }
        }

        public static void CheckUserAvailabilityWithTimer(Timer timer, int id, Form form)
        {
            if (!User.DoesUserExist(id))
            {
                timer.Stop();
                if (MessageBox.Show($"User with id {id} is not there any more!",
                     "Heads up!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    form.Close();
            }
        }

        public static void DisableDGVColumnSorting(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public static void HandleTbMoneyTextChanged(TextBox textBox)
        {
            string text = textBox.Text;

            text = System.Text.RegularExpressions.Regex.Replace(text, "[^0-9.]", "");

            int dotCount = text.Count(c => c == '.');
            if (dotCount > 1)
            {
                int firstDotIndex = text.IndexOf('.');
                text = text.Substring(0, firstDotIndex + 1) + text.Substring(firstDotIndex + 1).Replace(".", "");
            }

            if (text == ".")
            {
                text = "0.";
            }

            textBox.Text = text;
            textBox.SelectionStart = text.Length;
        }

        public static void HandleTbMoneyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' && (sender is TextBox textBox && !textBox.Text.Contains(".")))
            {
                return;
            }

            e.Handled = true;
        }

        public static void ChangeUcPersonInfoControllersUI(UcPersonInfo ucPersonInfo2, Person person)
        {
            ucPersonInfo2.SetPerson(person);
            ucPersonInfo2.SetPersonId(ucPersonInfo2.CurrentPerson.ID.ToString());
            ucPersonInfo2.SetPersonName(ucPersonInfo2.CurrentPerson.FirstName + " " +
                ucPersonInfo2.CurrentPerson.SecondName + " " +
                ucPersonInfo2.CurrentPerson.ThirdName + " " +
                ucPersonInfo2.CurrentPerson.LastName);
            ucPersonInfo2.SetNationalNo(ucPersonInfo2.CurrentPerson.NationalNo);
            ucPersonInfo2.SetGender(ucPersonInfo2.CurrentPerson.Gender == 0 ? "Female" : "Male");
            ucPersonInfo2.SetEmail(ucPersonInfo2.CurrentPerson.Email);
            ucPersonInfo2.SetAddress(ucPersonInfo2.CurrentPerson.Address);
            ucPersonInfo2.SetCountry(ucPersonInfo2.CurrentPerson.Country);
            ucPersonInfo2.SetDateOfBirth(ucPersonInfo2.CurrentPerson.DateOfBirth.Date.ToString());
            ucPersonInfo2.SetPhone(ucPersonInfo2.CurrentPerson.Phone);
            if (!string.IsNullOrEmpty(ucPersonInfo2.CurrentPerson.ImagePath) && File.Exists(person.ImagePath))
                ucPersonInfo2.SetImage(ucPersonInfo2.CurrentPerson.ImagePath);
        }
    }
}
