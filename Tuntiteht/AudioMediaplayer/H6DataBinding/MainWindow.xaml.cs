﻿using System;
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

namespace H6DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HockeyLeague smliiga;
        List<HockeyTeam> liigajoukkueet;
        int osoitin;
        public MainWindow()
        {
            InitializeComponent();
            AlustaKontrollit();
        }
        private void AlustaKontrollit()
        { //täytetään combobox listan alkioilla
            List<string> joukkueet = new List<string>();
            joukkueet.Add("Ilves");
            joukkueet.Add("JYP");
            joukkueet.Add("Kärpät");
            cbTeams.ItemsSource = joukkueet;
            //perustetaan SMliiga
            smliiga = new HockeyLeague();
            liigajoukkueet = smliiga.GetTeams();
        }
        private void btnGetSetting_Click(object sender, RoutedEventArgs e)
        {
            //Koodi lukee App.Configin asetuksen UserName
            btnGetSetting.Content = H6DataBinding.Properties.Settings.Default.UserName;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            //sidotaan kokoelma stackpanelin datacontekstiksi
            spLiiga.DataContext = liigajoukkueet;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            //siirretään osoitinta kokoelmassa yhdellä eteenpäin
            if (osoitin < liigajoukkueet.Count-1)
            {
                osoitin++;
                spLiiga.DataContext = liigajoukkueet[osoitin];
            }
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {   //siirretään osoitinta kokoelmassa yhdellä taaksepäin
            if (osoitin >= 1)
            {
                osoitin--;
                spLiiga.DataContext = liigajoukkueet[osoitin];
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //lisätään kokoelmaan uusi joukkue
            HockeyTeam uusi = new HockeyTeam();
            liigajoukkueet.Add(uusi);
            osoitin = liigajoukkueet.Count - 1;
            spLiiga.DataContext = liigajoukkueet[osoitin];
        }
    }
}
