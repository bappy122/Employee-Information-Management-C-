using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_Windows_.DL;

namespace PIM_Windows_.BL
{
    class AddEmployeeHelper
    {
        static int currentId;
        public static string idGenerator()
        {
            string id = " ";
            string year = DateTime.Now.Year.ToString();
            id = year + " - " + currentID();
            return id;
        }

        public static int currentID()
        {
            
            string query = String.Format("select * from EmpIdTracker");

            DataSet ds = DataAccess.GetDataSet(query);
            Int32 currentIdNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["currentId"].ToString());
            currentId = currentIdNumber;
            return currentId;
        }

        public static void increaseIdCounter()
        {
            string query = String.Format("select * from EmpIdTracker");
            DataSet ds = DataAccess.GetDataSet(query);
            Int32 currentIdNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["currentId"].ToString());

            int temp = currentIdNumber;

            int updatedId = ++currentIdNumber;

            string query2 = String.Format("update EmpIdTracker set currentId = "+updatedId+ " where currentId = "+temp);
            DataAccess.ExecuteSQL(query2);

        }

        
    }
}
