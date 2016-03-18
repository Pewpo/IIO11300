using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tehtava09
{
    class Yhteys
    {
        public static DataTable GetAllCustomersFromSQLServer(string connectionStr, string taulu, string cityfilter)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                string sql = "";
                sql = "SELECT * FROM " + taulu;
                SqlDataAdapter da = new SqlDataAdapter(sql, myConn);
                DataTable dt = new DataTable("ViiniAsiakkaat");
                da.Fill(dt);
                myConn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void CreateNew (string constr, string firstname, string lastname, string address,string postnumber, string city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    string sql = string.Format("INSERT INTO customer (firstname, lastname, address, zip, city) VALUES ('{0}','{1}','{2}','{3}','{4}')", firstname, lastname, address,postnumber, city);
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.ExecuteReader();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void  DeleteHenkilo()
        {
            
        }
    }
}
