using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PIM_Windows_.BL;
using PIM_Windows_.DL;

namespace PIM_Windows_.IL
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            //show termination reasons
            terminationReasonDataGridView.DataSource = ConfigurationHelper.ShowTerminationReasons();
            this.terminationReasonDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //show reporting methods
            reportsDataGridView.DataSource = ConfigurationHelper.ShowReportingMethods();
            this.reportsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog op = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        EmployeeFacade.LoadAndStoreEmployeeFromCsv(op.FileName);
                        MessageBox.Show("Data Successfully Saved into Temporary Database.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add Termination Reason
            string terminationReason = terminstionReason.Text;
            string query = String.Format("insert into Termination_Reason values('{0}')", terminationReason);
            int result = DataAccess.ExecuteSQL(query);
            if (result == 2627)
            {
                MessageBox.Show("Termination Reason Already Exists....!");
            }
            else
            {
                terminationReasonDataGridView.DataSource = ConfigurationHelper.ShowTerminationReasons();
                this.terminationReasonDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.terminstionReason.Text = "";
            }
            //show termination reasons

           
        }   

        private void Configuration_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports ob = new Reports();
            ob.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }

        private void terminationReasonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                string reportingMethodText = reportingMethodTextBox.Text;
                string query = String.Format("insert into Reporting_Method values('{0}')", reportingMethodText);
                int result = DataAccess.ExecuteSQL(query);
                if (result == 2627)
                {
                    MessageBox.Show("Reporting Method Already Exists....!");
                }
                else
                {
                    //show reporting methods
                    reportsDataGridView.DataSource = ConfigurationHelper.ShowReportingMethods();
                    this.reportsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.reportingMethodTextBox.Text = "";
                }


         
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           //CopyDataFromOneToOther(PIM, myDataTable, "tableName");
            string sql = String.Format("Insert into PIM.dbo.Employee Select * from PIM.dbo.EmployeeTemp");
            int rslt = DataAccess.ExecuteSQL(sql);
            
            if (rslt > 0)
            {
                String sql2 = String.Format("truncate table EmployeeTemp");
                int result = DataAccess.ExecuteSQL(sql2);
                if (result > 0)
                {
                    MessageBox.Show("Data Transferred to Main Database....!");
                }
                else
                {
                    MessageBox.Show("Failed to Transfer Data");
                }
            }
            else
            {
                MessageBox.Show("Failed to Transfer Data....!");
            }
            
            
           
        }
        private static void CopyDataFromOneToOther(String sConnStr, DataTable dt, String sTableName)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sConnStr, SqlBulkCopyOptions.TableLock))
            {
                bulkCopy.DestinationTableName = sTableName;
                bulkCopy.WriteToServer(dt);
            }
        }
    }
}
