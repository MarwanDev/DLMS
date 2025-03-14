using DLMS_Business;
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
    }
}
