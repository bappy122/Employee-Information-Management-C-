using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  System.Data.SqlClient;
using PIM_Windows_.BL;
using PIM_Windows_.DL;
using PIM_Windows_.IL;

namespace PIM_Windows_
{
    public partial class AddEmployee : Form
    {
        private string tempId;
        private static byte[] img = null;

        public AddEmployee()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.panel3.Hide();
            this.id.Enabled = false;
            this.loginUserName.Enabled = false;
            this.button7.Visible = false;//login details add button
            


            this.dataGridViewEducationalInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExperience.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSkill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUpdate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
       
            
            this.id.Text = AddEmployeeHelper.idGenerator();
            this.loginUserName.Text = AddEmployeeHelper.idGenerator();
            
        }

       

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pIMDataSet20.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter5.Fill(this.pIMDataSet20.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet19.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter4.Fill(this.pIMDataSet19.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet11.JobTitles' table. You can move, or remove it, as needed.
            this.jobTitlesTableAdapter.Fill(this.pIMDataSet11.JobTitles);
            // TODO: This line of code loads data into the 'pIMDataSet10.JobTypes' table. You can move, or remove it, as needed.
            this.jobTypesTableAdapter1.Fill(this.pIMDataSet10.JobTypes);
            // TODO: This line of code loads data into the 'pIMDataSet5.JobTypes' table. You can move, or remove it, as needed.
            this.jobTypesTableAdapter.Fill(this.pIMDataSet5.JobTypes);
            // TODO: This line of code loads data into the 'pIMDataSet4.SubUnits' table. You can move, or remove it, as needed.
            this.subUnitsTableAdapter.Fill(this.pIMDataSet4.SubUnits);
            // TODO: This line of code loads data into the 'pIMDataSet3.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter3.Fill(this.pIMDataSet3.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet2.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter2.Fill(this.pIMDataSet2.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter1.Fill(this.pIMDataSet1.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.pIMDataSet.Employee);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration ob = new Configuration();
            ob.Show();
            this.Hide();
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeList ob = new EmployeeList();
            ob.Show();
            this.Hide();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports ob = new Reports();
            ob.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.panel3.Show();
            }
            else if (!this.checkBox1.Checked)
            {
                this.panel3.Hide();
            }
            else
            {

            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            //fields checker
            if (firstName.Text.Equals("")||lastName.Text.Equals("")||dateOfBirth.Text.Equals("")||joiningDate.Text.Equals("")||comboJobTitle.Text.Equals("")||comboJobType.Text.Equals("")||mailAddress.Text.Equals("")||comboGender.Text.Equals("")||comboBloodGroup.Text.Equals("")||Nationality.Text.Equals(""))
            {
                MessageBox.Show("You Must Enter all Mandatory Fields..!");
            }
            else
            {

                string fName = firstName.Text;
                string mName = middleName.Text;
                string lName = lastName.Text;
                string dob = dateOfBirth.Text;
                string joinDate = joiningDate.Text;
                string jobtitle = comboJobTitle.Text;
                string mail = mailAddress.Text;
                string gender = comboGender.Text;
                string bloodGrp = comboBloodGroup.Text;
                string natinality = Nationality.Text;
                string jType = comboJobType.Text;
                string phone = phoneTextBox.Text;

                string query = String.Format("insert into Employee values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')", this.id.Text, fName, mName, lName, dob, gender, joinDate, null, natinality, null, null, null, bloodGrp, mail, null, jobtitle, null, null, null, jType, phone,null);
                int result = DataAccess.ExecuteSQL(query);

                if (result == 2627)
                {
                    MessageBox.Show("Employee ID Already Exists...!");
                }
                else if(result > 0)
                {
                    MessageBox.Show("Employee Added");
                    AddEmployeeHelper.increaseIdCounter();
                    this.updateGrideViews();

                    {
                        //add ligin info
                        this.button7_Click(sender,e);
                    }
                    
                    {
                        //backup Data store
                        string query2 = String.Format("insert into Employee values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')", this.id.Text, fName, mName, lName, dob, gender, joinDate, null, natinality, null, null, null, bloodGrp, mail, null, jobtitle, null, null, null, jType, phone, null);
                        DataAccess.ExecuteSQL(query2);
                    }
                }
                else
                {
                    MessageBox.Show("Failed To Add Employee...!");
                }

            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string accountType = "user";
            string pass = loginPass.Text;
            string confirmPass = confirmLoginPass.Text;

            string query = String.Format("insert into LogInDetails values('{0}','{1}','{2}')",this.loginUserName.Text,confirmPass,accountType);
            if (String.Equals(pass, confirmPass))
            {
                int result = DataAccess.ExecuteSQL(query);
                if (result > 0)
                {
                    MessageBox.Show("Login Details Added");
                    this.loginPass.Text = "";
                    this.confirmLoginPass.Text = "";
                }
                else
                    MessageBox.Show("Login Details Could not be Added");

            }
            else
            {
                MessageBox.Show("Password & Confirm Password didn't match..!");
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {


        }

        private void comboJobType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void updateGrideViews()
        {
            string query = String.Format("Select * from Employee");

            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);

            
            
            dataGridViewEducationalInfo.DataSource = b;
            dataGridViewSkill.DataSource = b;
            dataGridViewExperience.DataSource = b;

            this.dataGridViewEducationalInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSkill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExperience.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void button12_Click(object sender, EventArgs e)
        {
            string query;
            if (!searchKey.Text.Equals(""))
            {
                query = String.Format("select * from Employee where [employee ID]='{0}' OR firstName='{1}' OR middleName='{2}' OR lastName='{3}' OR jobTitle='{4}' OR jobType='{5}' OR supervisorName='{6}' OR gender='{7}' OR subUnit='{8}'", this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey2.Text);
            }
            else
            {
                query = String.Format("select * from Employee");
            }

            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            dataGridViewSkill.DataSource = b;
            this.dataGridViewSkill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string query;
            if (!searchKey2.Text.Equals(""))
            {
                query = String.Format("select * from Employee where [employee ID]='{0}' OR firstName='{1}' OR middleName='{2}' OR lastName='{3}' OR jobTitle='{4}' OR jobType='{5}' OR supervisorName='{6}' OR gender='{7}'OR subUnit='{8}'", this.searchKey2.Text, this.searchKey2.Text, this.searchKey2.Text, this.searchKey2.Text, this.searchKey2.Text, this.searchKey2.Text, this.searchKey2.Text, this.searchKey2.Text,this.searchKey2.Text,this.searchKey2.Text);
            }
            else
            {
                query = String.Format("select * from Employee");
            }

            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            dataGridViewExperience.DataSource = b;
            this.dataGridViewExperience.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query;
            if (!searchKey3.Text.Equals(""))
            {
                query = String.Format("select * from Employee where [employee ID]='{0}' OR firstName='{1}' OR middleName='{2}' OR lastName='{3}' OR jobTitle='{4}' OR jobType='{5}' OR supervisorName='{6}' OR gender='{7}' OR subUnit='{8}'", this.searchKey3.Text, this.searchKey3.Text, this.searchKey3.Text, this.searchKey3.Text, this.searchKey3.Text, this.searchKey3.Text, this.searchKey3.Text,this.searchKey3.Text,this.searchKey3.Text);
            }
            else
            {
                query = String.Format("select * from Employee");
            }

            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            dataGridViewEducationalInfo.DataSource = b;
            this.dataGridViewEducationalInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query;

            if (!empID.Text.Equals(""))
            {
                query = String.Format(" select * from Employee where [employee ID]='{0}'", this.empID.Text);
            }
            else
            {
                if (empID.Text.Equals("") && empName.Text.Equals("") && comboBoxJobTitle.Text.Equals("") && comboBoxSubUnit.Text.Equals(""))
                {
                    query = String.Format("select * from Employee");
                }

                else if (!empName.Text.Equals("") && comboBoxJobTitle.Text.Equals("") && comboBoxSubUnit.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where firstName ='{0}' or middleName ='{1}' or lastName ='{2}'", this.empName.Text, this.empName.Text, this.empName.Text);
                }
                else if (empName.Text.Equals("") && !comboBoxJobTitle.Text.Equals("") && comboBoxSubUnit.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where jobTitle ='{0}'", this.comboBoxJobTitle.Text);
                }
                else if (empName.Text.Equals("") && comboBoxJobTitle.Text.Equals("") && !comboBoxSubUnit.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where subUnit ='{0}'", this.comboBoxSubUnit.Text);
                }
                else if (!empName.Text.Equals("") && !comboBoxJobTitle.Text.Equals("") && comboBoxSubUnit.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where (firstName ='{0}' OR middleName ='{1}' OR lastName ='{2}') AND jobTitle ='{3}'", this.empName.Text, this.empName.Text, this.empName.Text, this.comboBoxJobTitle.Text);
                }
                else if (!empName.Text.Equals("") && comboBoxJobTitle.Text.Equals("") && !comboBoxSubUnit.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where (firstName ='{0}' OR middleName ='{1}' OR lastName ='{2}') AND subUnit ='{3}'", this.empName.Text, this.empName.Text, this.empName.Text, this.comboBoxSubUnit.Text);
                }
                else if (empName.Text.Equals("") && !comboBoxJobTitle.Text.Equals("") && !comboBoxSubUnit.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where jobTitle ='{0}' AND subUnit = '{1}'", this.comboBoxJobTitle.Text, this.comboBoxSubUnit.Text);
                }
                else
                {
                    query = String.Format(" select * from Employee where (firstName ='{0}' OR middleName ='{1}' OR lastName ='{2}') AND jobTitle ='{3}' AND subUnit = '{4}'", this.empName.Text, this.empName.Text, this.empName.Text, this.comboBoxJobTitle.Text, this.comboBoxSubUnit.Text);
                }
            }

            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            dataGridViewUpdate.DataSource = b;
            this.dataGridViewUpdate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if(MessageBox.Show("Are sure want to Update Information ?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    employeeBindingSource5.EndEdit();
                    employeeTableAdapter5.Update(this.pIMDataSet20.Employee);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void dataGridViewUpdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (empIdSkill.Text.Equals("") || richTextBoxSkill.Text.Equals(""))
            {
                MessageBox.Show("You Must need to Fill all the fields...!");
            }
            else
            {
                string eid = empIdSkill.Text;
                string skill = richTextBoxSkill.Text;

                string query = String.Format("insert into Skill values('{0}','{1}')", eid, skill);
                int result = DataAccess.ExecuteSQL(query);

                if (result > 0)
                {
                    MessageBox.Show("Skill Added..!");
                    empIdSkill.Text="";
                    richTextBoxSkill.Text="";
                }
                else
                {
                    MessageBox.Show("Skill could not be Added..! Try Again..!");
                }

            }         

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (empIdExperience.Text.Equals("") || textBoxCompanyName.Text.Equals("") ||
                textBoxDesignation.Text.Equals("") || textBoxDuration.Text.Equals(""))
            {
                MessageBox.Show("You Must need to Fill all the fields...!");
            }
            else
            {
                string eid = empIdExperience.Text;
                string company = textBoxCompanyName.Text;
                string designation = textBoxDesignation.Text;
                string duration = textBoxDuration.Text;

                string query = String.Format("insert into Experience values('{0}','{1}','{2}','{3}')", eid, company, designation, duration);
                int result = DataAccess.ExecuteSQL(query);

                if (result > 0)
                {
                    MessageBox.Show("Experience Added..!");
                    empIdExperience.Text="";
                    textBoxCompanyName.Text="";
                    textBoxDesignation.Text="";
                    textBoxDuration.Text="";
                }
                else
                {
                    MessageBox.Show("Experience could not be Added..! Try Again..!");
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text.Equals("") || textBoxInstitute.Text.Equals("") ||
                textBoxDegree.Text.Equals("") || textBoxYear.Text.Equals("")||textBoxResult.Text.Equals(""))
            {
                MessageBox.Show("You Must need to Fill all the fields...!");
            }
            else
            {
                string eid = textBoxID.Text;
                string institute = textBoxInstitute.Text;
                string degree = textBoxDegree.Text;
                string year = textBoxYear.Text;
                string score = textBoxResult.Text;

                string query = String.Format("insert into Education values('{0}','{1}','{2}','{3}','{4}')", eid, degree, score, institute, year);
                int result = DataAccess.ExecuteSQL(query);

                if (result > 0)
                {
                    MessageBox.Show("Educational Information Added..!");
                    textBoxID.Text = "";
                    textBoxInstitute.Text = "";
                    textBoxDegree.Text = "";
                    textBoxYear.Text = "";
                    textBoxResult.Text = "";
                }
                else
                {
                    MessageBox.Show("Educational Information could not be Added..! Try Again..!");
                }
            }
            
        }
    }
}
