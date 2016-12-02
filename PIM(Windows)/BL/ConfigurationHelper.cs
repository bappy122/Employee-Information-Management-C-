using System.Windows.Forms;
using PIM_Windows_.DL;

namespace PIM_Windows_.BL
{
    class ConfigurationHelper
    {
        public static BindingSource ShowTerminationReasons()
        {
            string query = "SELECT Termination_Reasons as 'Termination Reasons' FROM Termination_Reason";
            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            return b;
        }

        public static BindingSource ShowReportingMethods()
        {
            string query = "SELECT Reporting_Method as 'Reporting Methods' FROM Reporting_Method";
            BindingSource b = new BindingSource();
            b.DataSource = DataAccess.GetDataTable(query);
            return b;
        }
    }
}
