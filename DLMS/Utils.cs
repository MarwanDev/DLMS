using DLMS_Business;
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
                timer.Enabled = false;
                if (MessageBox.Show($"Person with id {id} is not there any more!",
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
    }
}
