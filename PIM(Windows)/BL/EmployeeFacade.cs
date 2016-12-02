using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIM_Windows_.DL;

namespace PIM_Windows_.BL
{
    class EmployeeFacade
    {
        private static string[,] LoadCsv(string filename)
        {
            // Get the file's text.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;

            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }

            // Return the values.
            return values;
        }

        public static List<Employee> LoadAndStoreEmployeeFromCsv(string filename)
        {
            string[,] values = LoadCsv(filename);
            int num_rows = values.GetUpperBound(0) + 1;
            int num_cols = values.GetUpperBound(1) + 1;

            if (num_cols != 11)
            {
                //Wrong Csv Formate
                return new List<Employee>();
            }

            List<Employee> employees = new List<Employee>();
            for (int r = 1; r < num_rows; r++)
            {
                var employee = new Employee()
                {
                    employeeID = values[r, 0],
                    firstName = values[r, 1],
                    lastName = values[r, 2],
                    employeeDOB = values[r, 3],
                    gender = values[r, 4],
                    joiningDate = values[r, 5],
                    martialStatus = values[r, 6],
                    nationality = values[r, 7],
                    bloodGroup = values[r, 8],
                    emailAddress = values[r, 9],
                    jobTitle = values[r, 10]
                };


                if (Save(employee))
                    employees.Add(employee);
            }

            return employees;
        }

        public static bool Save(Employee employee)
        {
            try
            {
                string sql = "select * from EmployeeTemp where employeeID='" + employee.employeeID + "'";
                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count == 0)
                {
                    sql = "insert into EmployeeTemp(employeeID,firstName,lastName,employeeDOB,gender,joiningDate,martialStatus,nationality,bloodGroup,emailAddress,jobTitle) " +
                                   "values('" + employee.employeeID + "','" + employee.firstName + "','" + employee.lastName + "','" + employee.employeeDOB + "','" + employee.gender + "','" + employee.joiningDate + "','" + employee.martialStatus + "','" + employee.nationality + "','" + employee.bloodGroup + "','" + employee.emailAddress + "','" + employee.jobTitle + "')";
                }
                else
                {
                    //update query
                }

                DataAccess.ExecuteSQL(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
