using System;
using System.Windows.Forms;
using PIM_Windows_.DL;
using PIM_Windows_.IL;

namespace PIM_Windows_.UI
{
    public partial class MyProfileOptions : Form
    {
        public static string userID;
        public MyProfileOptions()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.fillEducation();
            //MessageBox.Show(userID);
        }

        private void MyProfileOptions_Load(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void fillProfile()
        {
            
        }

        private void fillEducation()
        {
            string query = String.Format("select presentAddress as ' Present Address',permanentAddress as 'Permenant Address' from Address where empID = '{0}'", userID);
            dataGridViewEducation.DataSource = DataAccess.GetDataTable(query);
            this.dataGridViewEducation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void fillQualification()
        {
            
        }

        private void fillDependents()
        {
            
        }

        private void fillMedicalIssues()
        {
            
        }

        private void fillEmmergencyContacts()
        {
            
        }

        private void sameAddressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sameAddressCheckBox.Checked)
            {
                this.textBoxPresentAddress.Text = this.textBoxPermenantAddress.Text;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!textBoxPresentAddress.Text.Equals("") && !textBoxPermenantAddress.Text.Equals(""))
            {
                string query = String.Format("insert into Address values ('{0}','{1}','{2}')",userID,this.textBoxPresentAddress.Text,this.textBoxPermenantAddress.Text);
                DataAccess.ExecuteSQL(query);
                this.fillEducation();
            }
        }
    }
}
