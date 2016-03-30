using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10
{
    public class DBPelaaja
    {
        public static DataTable GetPlayers(string conn)
        {
            try
            {
                using (OleDbConnection vcon = new OleDbConnection(conn))
                {
                    string sql = "SELECT* FROM  Pelaajat";
                    vcon.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, vcon);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable("Pelaajat");
                    da.Fill(dt);
                    vcon.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int paivitaPelaajat(string conn, string enimi, string snimi, double siirtohinta, string seura, int id)
        {
            try
            {
                using (OleDbConnection vcon = new OleDbConnection(conn))
                {
                    string sql = string.Format("UPDATE Pelaajat SET etunimi='{1}', sukunimi='{2}', seura='{3}', arvo={4} WHERE id={0}", id, enimi, snimi, seura, siirtohinta);
                    vcon.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, vcon);
                    int lkm = cmd.ExecuteNonQuery();
                    vcon.Close();
                    return lkm;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    
}
