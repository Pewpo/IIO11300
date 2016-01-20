using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1
{
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
