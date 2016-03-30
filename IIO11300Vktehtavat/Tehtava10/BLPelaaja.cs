using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10
{
 public   class BLPelaaja
    {
        private  string etunimi;
        private string sukunimi;
        private string seura;
        private double siirtohinta;
        private  readonly string kokonimi;
        private  string esitysnimi;
        private int id;
        //konstruktorit
        public  BLPelaaja(string enimi, string snimi, double shinta, string seura, int id)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.kokonimi = enimi +" "+snimi;
            this.seura = seura;
            this.esitysnimi = this.etunimi + " " + this.sukunimi + "," + this.seura;
            this.siirtohinta = shinta;
            this.id = id;
        }
        public BLPelaaja() {
            this.etunimi = "";
            this.sukunimi = "";
            this.kokonimi = "";
            this.esitysnimi = "";
            this.seura = "";
            this.siirtohinta = 0;
            this.id = 0;
        }
        //desktuktori
         ~BLPelaaja()  
        {
            this.etunimi = null;
            this.sukunimi = null;
            this.seura = null;
            this.siirtohinta = 0;
            this.id = 0;
        }
        public string getEnimi()
        {
            return this.etunimi;
        }
        public string getSnimi()
        {
            return this.sukunimi;
        }
        public string getSeura()
        {
            return this.seura;
        }
        public double getSiirtohinta()
        {
            return this.siirtohinta;
        }
        public int getId()
        {
            return this.id;
        }
        public void setTiedot(string enimi, string snimi, double siirtohinta, string seura, int id)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.siirtohinta = siirtohinta;
            this.seura = seura; 
            this.esitysnimi = this.etunimi + " " + this.sukunimi + "," + this.seura;
            this.id = id;
        }
        public override string ToString()
        {
            return this.esitysnimi;
        }



    }
    public class SMpelaajat
    {
        public static List<BLPelaaja> GetTiedot()
        {
            string conn = Tehtava10.Properties.Settings.Default.LiigaKanta;

            try
            {
                DataTable dt;
                List<BLPelaaja> player = new List<BLPelaaja>();
                dt = DBPelaaja.GetPlayers(conn);

                foreach (DataRow row in dt.Rows)
                {
                    BLPelaaja pelaaja = new BLPelaaja();
                  
                    pelaaja.setTiedot(row["etunimi"].ToString(), row["sukunimi"].ToString(), Convert.ToDouble(row["arvo"]), row["seura"].ToString(), (Int32.Parse(row["id"].ToString())));
                    player.Add(pelaaja);
                }
                return player;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int paivitaPelaajat(BLPelaaja pelaaja) {
            try
            { string conn = Tehtava10.Properties.Settings.Default.LiigaKanta;
             int lkm =    DBPelaaja.paivitaPelaajat(conn, pelaaja.getEnimi(), pelaaja.getSnimi(), pelaaja.getSiirtohinta(), pelaaja.getSeura(), pelaaja.getId());
                return lkm;
    }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
   


