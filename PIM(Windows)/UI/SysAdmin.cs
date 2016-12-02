using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_Windows_.UI
{
    public partial class SysAdmin : Form
    {
        public SysAdmin()
        {
            InitializeComponent();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports ob = new Reports();
            ob.Show();
            this.Dispose();
        }

        private void addJobTitlesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysAdminOptions ob = new SysAdminOptions();
            ob.Show();
            this.Hide();
        }
    }
}
