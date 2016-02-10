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

namespace Tehtava_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        List<BLPelaaja> pelaajat;
        
        public MainWindow()
        {
            InitializeComponent();
            pelaajat = new List<BLPelaaja>();

        }

        private void btnUusi_Click(object sender, RoutedEventArgs e)
        {           
            try
            {   
                if (txtboxEnimi.Text != null && txtboxSnimi.Text != null && txtboxHinta.Text != null || txtboxHinta.Text != null && cboxSeura.Text != null)
                {
                    bool apu = true;
                    BLPelaaja i = new BLPelaaja(txtboxEnimi.Text, txtboxSnimi.Text, double.Parse(txtboxHinta.Text), cboxSeura.Text);
                    foreach (BLPelaaja prime in pelaajat) // Loop through List with foreach.
                    {
                        if(i == prime) { apu = false; }
                    }
                    if (apu == true) {
                        pelaajat.Add(i);
                        applyChanges();
                    }
                }               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Täytä kaikki kentät");
            }
        }
        private void applyChanges()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = pelaajat;     
        }
    }
}
