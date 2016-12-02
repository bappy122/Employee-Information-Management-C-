using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using PIM_Windows_.BL;
using PIM_Windows_.DL;

namespace PIM_Windows_.UI
{
    public partial class SysAdminOptions : Form
    {
        public SysAdminOptions()
        {
            InitializeComponent();
            this.dataGridViewDesignations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSubUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewJobTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmpDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //show user and account type
            dataGridViewEmpDetails.DataSource = SysAdminHelper.ShowEmployeesLoginDetails();
            this.dataGridViewEmpDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void SysAdminOptions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pIMDataSet9.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.pIMDataSet9.Employee);
            // TODO: This line of code loads data into the 'pIMDataSet8.JobTypes' table. You can move, or remove it, as needed.
            this.jobTypesTableAdapter.Fill(this.pIMDataSet8.JobTypes);
            // TODO: This line of code loads data into the 'pIMDataSet7.SubUnits' table. You can move, or remove it, as needed.
            this.subUnitsTableAdapter.Fill(this.pIMDataSet7.SubUnits);
            // TODO: This line of code loads data into the 'pIMDataSet6.JobTitles' table. You can move, or remove it, as needed.
            this.jobTitlesTableAdapter.Fill(this.pIMDataSet6.JobTitles);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBoxJobTypes.Text.Equals(""))
            {
                //insertion 
                string query = String.Format("insert into JobTypes values ('{0}')",textBoxJobTypes.Text);
                int result = DataAccess.ExecuteSQL(query);

                //primary key exception
                if (result == 2627)
                {
                    MessageBox.Show("Job Type Already Exists...!");
                    
                }
                this.textBoxJobTypes.Text = "";

                //showing the output in dataGridView
                string query2 = String.Format("Select * from JobTypes");
                BindingSource b = new BindingSource();
                b.DataSource = DataAccess.GetDataTable(query2);
                dataGridViewJobTypes.DataSource = b;

            }
            else
            {
                MessageBox.Show("You must need to Enter Job Type..!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

             if (!textBoxSubUnit.Text.Equals(""))
            {
                //insertion 
                string query = String.Format("insert into SubUnits values ('{0}')", textBoxSubUnit.Text);
                int result = DataAccess.ExecuteSQL(query);

                //primary key exception
                if (result == 2627)
                {
                    MessageBox.Show("Sub-Unit Already Exists...!");

                }
                this.textBoxSubUnit.Text = "";

                //showing the output in dataGridView
                string query2 = String.Format("Select * from SubUnits");
                BindingSource b = new BindingSource();
                b.DataSource = DataAccess.GetDataTable(query2);
                dataGridViewSubUnits.DataSource = b;

            }
            else
            {
                MessageBox.Show("You must need to Enter Sub-Unit..!");
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            if (!textBoxDesignations.Text.Equals(""))
            {
                //insertion 
                string query = String.Format("insert into JobTitles values ('{0}')", textBoxDesignations.Text);
                int result = DataAccess.ExecuteSQL(query);

                //primary key exception
                if (result == 2627)
                {
                    MessageBox.Show("Designation Already Exists...!");

                }
                this.textBoxDesignations.Text = "";

                //showing the output in dataGridView
                string query2 = String.Format("Select * from JobTitles");
                BindingSource b = new BindingSource();
                b.DataSource = DataAccess.GetDataTable(query2);
                dataGridViewDesignations.DataSource = b;

            }
            else
            {
                MessageBox.Show("You must need to Enter Designation..!");
            }
           
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query;
            if (!searchKey.Text.Equals(""))
            {
                query = String.Format("  select Employee.[employee ID] as 'ID',Employee.firstName as 'First Name',Employee.middleName as 'Middle Name',Employee.lastName as 'Last Name',Employee.joiningDate as 'Joining Date', Employee.subUnit as 'Sub-Unit', Employee.jobTitle as 'Job Title',LoginDetails.accountType as 'Account Type' FROM Employee INNER JOIN LoginDetails ON Employee.[employee ID]=LoginDetails.employeeID and (Employee.[employee ID]='{0}' OR Employee.firstName='{1}' OR Employee.middleName='{2}' OR Employee.lastName='{3}' OR Employee.jobTitle='{4}' OR Employee.jobType='{5}' OR Employee.supervisorName='{6}' OR Employee.gender='{7}'OR Employee.subUnit='{8}')", this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text, this.searchKey.Text);
            }
            else
            {
                query = String.Format("select Employee.[employee ID] as 'ID',Employee.firstName as 'First Name',Employee.middleName as 'Middle Name',Employee.lastName as 'Last Name',Employee.joiningDate as 'Joining Date', Employee.subUnit as 'Sub-Unit', Employee.jobTitle as 'Job Title',LoginDetails.accountType as 'Account Type' FROM Employee INNER JOIN LoginDetails ON Employee.[employee ID]=LoginDetails.employeeID");

            }

            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            dataGridViewEmpDetails.DataSource = b;
            this.dataGridViewEmpDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void searchKeyDown(object sender, KeyEventArgs e)
        {
            EventArgs ee = new EventArgs();
            if (e.KeyCode == Keys.Enter)
            {
                this.button8_Click(sender, ee);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!ID.Text.Equals(""))
            {
                string query = String.Format("update LogInDetails set accountType='admin' where employeeID='{0}'",this.ID.Text);
                DataAccess.ExecuteSQL(query);

                //load logindetails of employees 
                dataGridViewEmpDetails.DataSource = SysAdminHelper.ShowEmployeesLoginDetails(); ;
                this.dataGridViewEmpDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
            }
            else
            {
                MessageBox.Show("You must need to enter Employee ID!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ID.Text.Equals(""))
            {
                string query = String.Format("update LogInDetails set accountType='user' where employeeID='{0}'", this.ID.Text);
                DataAccess.ExecuteSQL(query);

                 
                //load logindetails of employees 
                dataGridViewEmpDetails.DataSource = SysAdminHelper.ShowEmployeesLoginDetails(); ;
                this.dataGridViewEmpDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("You must need to enter Employee ID!");
            }
        }

        private void dataGridviewOnClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridViewEmpDetails.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            this.ID.Text = value;
        }
    }
}
