using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1
{

    public class Ikkuna
    {
        #region Muuttuja(variables)
        private double korkeus;
        private double pintalaala;
        #endregion
     

        #region Konstruktorit(constructors)

        #endregion

        #region Metodit (methods)
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
        private float LaskeHinta()
        {
            //hintalasketaan työn ja materiaalimenekin ja katteen avulla.
            float kate = 100;
            float tyo = 200;
            float materiaali;
            materiaali = 100 * ((float)leveys * (float)korkeus/10000000);
            return (kate + tyo + materiaali);
        }
        #endregion

        #region Ominaisuudet (properties)
        // olio suunnuittelun aikana on päätetty että pinta-ala ja hinta ovat read-only ominaisuuksia
        public double PintaAla {
            get
            {
                return korkeus * leveys;
            }
        }
        public float Hinta
        {
            get { return LaskeHinta(); }
        }
        public double Korkeus {
            get
            {
                return korkeus;
            }
            set
            {
                //tässä kohdassa voisi tarvittaessa tehdä tarkistuksia
                korkeus = value;
            }
        }private double leveys;
        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }
        #endregion
    }
    public class IkkunaV01
    {
        //joskus tehdään näin "oikaistaan"
        //en suosittele by esa
      public  double korkeus;
      public double leveys;
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }

    }
    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
        public static double CalculatePerimeter(double widht, double height)
        {
         double area =   widht* height;
            return area;
        }
        public static double CalculatePiiri(double widht, double height)
        {
            double piiri = widht + height * 2;
            return piiri;
        }
        public static double CalculateK_pa(double widht, double height, double Kleveys)
        {
            
            double piiri = (widht + Kleveys * 2) * (height + Kleveys * 2);
            piiri = piiri - (widht * height);
            return piiri;
        }
    }
}
