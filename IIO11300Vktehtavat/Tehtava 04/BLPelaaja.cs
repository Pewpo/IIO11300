using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava_04
{
    class BLPelaaja
    {
        private  string etunimi;
        private string sukunimi;
        private readonly string kokonimi;
        private readonly string esitysnimi;
        private string seura;
        private double siirtohinta;
        //konstruktorit
      public  BLPelaaja(string enimi, string snimi, double shinta, string seura)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.kokonimi = enimi +" "+snimi;
            this.esitysnimi = enimi + " " + snimi + "," + seura;
            this.seura = seura;
            this.siirtohinta = shinta;
        }
        public BLPelaaja() {
            this.etunimi = "";
            this.sukunimi = "";
            this.kokonimi = "";
            this.esitysnimi = "";
            this.seura = "";
            this.siirtohinta = 0;
        }
        //desktuktori
         ~BLPelaaja()  
        {
            this.etunimi = null;
            this.sukunimi = null;
            this.seura = null;
            this.siirtohinta = 0;
        }
    public  string  GetPelaajatiedot()
        {
            return this.esitysnimi + "<br>";
        }


    }
}
