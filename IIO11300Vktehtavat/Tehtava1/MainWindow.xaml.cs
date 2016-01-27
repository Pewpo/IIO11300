/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 13.1.2016
* Authors: Tero ,Esa Salmikangas
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {     
       

    public MainWindow()
    {
      InitializeComponent();
    }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double ikkunaleveys = double.Parse(txtikkunaleveys.Text);
            double ikkunakorkeus = double.Parse(txtWindowHeight.Text);
            double karminpaksuus = double.Parse(txtkarminleveys.Text);
            //TODO
            try
            {
                double result;
                result = BusinessLogicWindow.CalculatePerimeter(ikkunaleveys, ikkunakorkeus);
                ikkunaP.Text = result.ToString("0.##") + " m^2";

                double Karminpiiri;
                Karminpiiri = BusinessLogicWindow.CalculatePiiri(ikkunaleveys, ikkunakorkeus);
                karmiPiiri.Text = Karminpiiri.ToString("0.##") + "m";

                double KarminPA;
                KarminPA = BusinessLogicWindow.CalculateK_pa(ikkunaleveys, ikkunakorkeus, karminpaksuus);
                karmiPa.Text = KarminPA.ToString("0.##") + "m^2";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
            //Käynnissä oleva sovellus suljetaan tällä tavalla
      Application.Current.Shutdown();
    }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btnCalculate00(object sender, RoutedEventArgs e) {

            Ikkuna ikk = new Ikkuna();
            ikk.Leveys = double.Parse(txtikkunaleveys.Text);
            ikk.Korkeus = double.Parse(txtWindowHeight.Text);
            //V.01 Pinta-alan lakseminen kutsumalla metodia
      //      txtWindowArea.Text =  ikk.LaskePintaAla().ToString();
            //v.02 pinta-ala on olion ominaisuus
            txtWindowArea.Text = ikk.PintaAla.ToString();


        }
    }


}
