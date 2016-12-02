using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIM_Windows_.DL;

namespace PIM_Windows_.BL
{
    class SysAdminHelper
    {
        public static BindingSource ShowEmployeesLoginDetails()
        {
            string query = "select Employee.[employee ID] as 'ID',Employee.firstName as 'First Name',Employee.middleName as 'Middle Name',Employee.lastName as 'Last Name',Employee.joiningDate as 'Joining Date', Employee.subUnit as 'Sub-Unit', Employee.jobTitle as 'Job Title',LoginDetails.accountType as 'Account Type' FROM Employee INNER JOIN LoginDetails ON Employee.[employee ID]=LoginDetails.employeeID";
            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            return b;
        }
    }
}
