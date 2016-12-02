using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIM_Windows_.BL;
using PIM_Windows_.IL;

namespace PIM_Windows_
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports ob = new Reports();
            ob.Show();
            this.Hide();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration ob = new Configuration();
            ob.Show();
            this.Hide();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee ob = new AddEmployee();
            ob.Show();
            this.Hide();
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeList ob = new EmployeeList();
            ob.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }
    }
}
