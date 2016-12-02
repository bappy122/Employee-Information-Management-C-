using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PIM_Windows_.DL
{
    class DataAccess
    {
        static string _ConnectionString = @"server=ASUS\SQLEXPRESS; database=PIM; integrated security=true";
        static SqlConnection _Connection = null;
        public static SqlConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SqlConnection(_ConnectionString);
                    _Connection.Open();

                    return _Connection;
                }
                else if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection.Open();

                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

        public static DataSet GetDataSet(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            Connection.Close();

            return ds;
        }

        public static DataTable GetDataTable(string sql)
        {
            DataSet ds = GetDataSet(sql);

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static int ExecuteSQL(string sql)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Connection);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    return 2627;
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
    }
    
}
