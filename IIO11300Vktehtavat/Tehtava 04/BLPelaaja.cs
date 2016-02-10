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
        private string seura;
        private double siirtohinta;
        private  readonly string kokonimi;
        private  string esitysnimi;
        //konstruktorit
        public  BLPelaaja(string enimi, string snimi, double shinta, string seura)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.kokonimi = enimi +" "+snimi;
            this.seura = seura;
            this.esitysnimi = this.etunimi + " " + this.sukunimi + "," + this.seura;
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
        public void setTiedot(string enimi, string snimi, double siirtohinta, string seura)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.siirtohinta = siirtohinta;
            this.seura = seura; 
            this.esitysnimi = this.etunimi + " " + this.sukunimi + "," + this.seura;
        }
        public override string ToString()
        {
            return this.esitysnimi;
        }

    }
}
