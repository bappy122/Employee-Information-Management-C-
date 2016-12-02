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
using PIM_Windows_.DL;
using PIM_Windows_.IL;

namespace PIM_Windows_
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dataGridEmployeeInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;         
            this.dataGridViewDelete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.comboBoxJobTitle.Text = "";
            this.comboBoxJobTitle2.Text = "";
            this.comboBoxSubUnit.Text = "";
            this.comboBoxSubUnit2.Text = "";
  
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pIMDataSet18.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter4.Fill(this.pIMDataSet18.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet17.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter3.Fill(this.pIMDataSet17.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet16.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter2.Fill(this.pIMDataSet16.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet15.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter1.Fill(this.pIMDataSet15.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet14.JobTitles' table. You can move, or remove it, as needed.
            this.jobTitlesTableAdapter.Fill(this.pIMDataSet14.JobTitles);
            // TODO: This line of code loads data into the 'pIMDataSet13.SubUnits' table. You can move, or remove it, as needed.
            this.subUnitsTableAdapter.Fill(this.pIMDataSet13.SubUnits);
            // TODO: This line of code loads data into the 'pIMDataSet12.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.pIMDataSet12.Employee);

        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration ob = new Configuration();
            ob.Show();
            this.Hide();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee ob = new AddEmployee();
            ob.Show();
            this.Hide();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports ob = new Reports();
            ob.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!this.employeeIdTextBox.Text.Equals(""))
            {
                if (MessageBox.Show("Are sure want to Delete Employe Information...?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = String.Format("delete from Employee where [employee ID] = '{0}'", this.employeeIdTextBox.Text);
                    int result = DataAccess.ExecuteSQL(query);

                    if (result > 0)
                    {
                        MessageBox.Show("Employee Deleted...!");
                        this.employeeIdTextBox.Text = "";

                        //deleting login info
                        string deleteQuery = String.Format("delete from LoginDetails where employeeID='{0}'", this.employeeIdTextBox.Text);
                        DataAccess.ExecuteSQL(deleteQuery);

                        //load employees 
                        string query2 = String.Format("Select * from Employee");
                        BindingSource b = new BindingSource();
                        b.DataSource = DataAccess.GetDataTable(query2);
                        dataGridViewDelete.DataSource = b;
                        dataGridEmployeeInfo.DataSource = b;
                    }
                    else
                    {
                        MessageBox.Show("Employee ID Doesnt Match...!");
                        this.employeeIdTextBox.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("You must enter Employee ID to Delete!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            dataGridViewDelete.DataSource = b;
            this.dataGridViewDelete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query;

            if (!empID2.Text.Equals(""))
            {
                query = String.Format(" select * from Employee where [employee ID]='{0}'", this.empID2.Text);       
            }
            else
            {
                if (empID2.Text.Equals("") && empName2.Text.Equals("") && comboBoxJobTitle2.Text.Equals("") && comboBoxSubUnit2.Text.Equals(""))
                {
                    query = String.Format("select * from Employee");
                }

                else if (!empName2.Text.Equals("") && comboBoxJobTitle2.Text.Equals("") && comboBoxSubUnit2.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where firstName ='{0}' or middleName ='{1}' or lastName ='{2}'", this.empName2.Text, this.empName2.Text, this.empName2.Text);
                }
                else if (empName2.Text.Equals("") && !comboBoxJobTitle2.Text.Equals("") && comboBoxSubUnit2.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where jobTitle ='{0}'", this.comboBoxJobTitle2.Text);
                }
                else if (empName2.Text.Equals("") && comboBoxJobTitle2.Text.Equals("") && !comboBoxSubUnit2.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where subUnit ='{0}'", this.comboBoxSubUnit2.Text);
                }
                else if (!empName2.Text.Equals("") && !comboBoxJobTitle2.Text.Equals("") && comboBoxSubUnit2.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where (firstName ='{0}' OR middleName ='{1}' OR lastName ='{2}') AND jobTitle ='{3}'", this.empName2.Text, this.empName2.Text, this.empName2.Text, this.comboBoxJobTitle2.Text);
                }
                else if (!empName2.Text.Equals("") && comboBoxJobTitle2.Text.Equals("") && !comboBoxSubUnit2.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where (firstName ='{0}' OR middleName ='{1}' OR lastName ='{2}') AND subUnit ='{3}'", this.empName2.Text, this.empName2.Text, this.empName2.Text, this.comboBoxSubUnit2.Text);
                }
                else if (empName2.Text.Equals("") && !comboBoxJobTitle2.Text.Equals("") && !comboBoxSubUnit2.Text.Equals(""))
                {
                    query = String.Format(" select * from Employee where jobTitle ='{0}' AND subUnit = '{1}'", this.comboBoxJobTitle2.Text, this.comboBoxSubUnit2.Text);
                }
                else
                {
                    query = String.Format(" select * from Employee where (firstName ='{0}' OR middleName ='{1}' OR lastName ='{2}') AND jobTitle ='{3}' AND subUnit = '{4}'", this.empName2.Text, this.empName2.Text, this.empName2.Text, this.comboBoxJobTitle2.Text, this.comboBoxSubUnit2.Text);
                }
            }

            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            dataGridEmployeeInfo.DataSource = b;
            this.dataGridEmployeeInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
        }

        private void gridviedRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string value = dataGridViewDelete.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            this.employeeIdTextBox.Text = value;
        }
    }
}
