using System;
using System.Windows.Forms;
using PIM_Windows_.UI;

namespace PIM_Windows_.IL
{
    public partial class MyProfile : Form
    {
        public MyProfile()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void pIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyProfileOptions ob = new MyProfileOptions();
            ob.Show();
            this.Hide();
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }
    }
}
