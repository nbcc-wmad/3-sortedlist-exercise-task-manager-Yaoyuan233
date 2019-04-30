using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        SortedList<DateTime, string> tasks = new SortedList<DateTime, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string task = txtTask.Text.ToString();
            DateTime date =dtpTaskDate.Value.Date;

            try
            {
                if (tasks.ContainsKey(date))
                {
                    MessageBox.Show("No repeat date");
                }
                else if (txtTask.Text == string.Empty)
                {
                    MessageBox.Show("No empty");
                }
                else
                {
                    tasks.Add(date, task);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Data");
            }
            lstTasks.Items.Add(date);
            dtpTaskDate.Value = DateTime.Now;

        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                lblTaskDetails.Text = tasks[Convert.ToDateTime(lstTasks.SelectedItem)];
            }
            else
            {
                lblTaskDetails.Text = string.Empty;
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            foreach (var s in tasks)
            {
                message += ($"{s.Key}{s.Value}"+Environment.NewLine);

            };

            MessageBox.Show(message);

        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            tasks.Remove(Convert.ToDateTime(lstTasks.SelectedItem));
            lstTasks.Items.Remove(lstTasks.SelectedItem);
        }
    }
}
