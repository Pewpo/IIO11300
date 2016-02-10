using System;
using System.Collections.Generic;
using System.IO;
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
            AsetaSeurat();
            pelaajat = new List<BLPelaaja>();

        }
        //uuden pelaajan luonti
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
                            if (i == prime) { apu = false; }
                        }
                        if (apu == true)
                        {
                            pelaajat.Add(i);
                            applyChanges();
                        }
                        tbStatus.Text = "Pelaaja luotu!";
                }                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Täytä kaikki kentät oikein!");
                tbStatus.Text = "Tapahtui virhe pelaaa luotaessa";
            }
        }
        private void applyChanges()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = pelaajat;     
        }

        //seurojen alustus
        private void AsetaSeurat()
        {
            cboxSeura.Items.Add("BLUES"); cboxSeura.Items.Add("HIFK"); cboxSeura.Items.Add("HPK");
            cboxSeura.Items.Add("ILVES"); cboxSeura.Items.Add("JYP"); cboxSeura.Items.Add("KALPA");
            cboxSeura.Items.Add("KOOKOO"); cboxSeura.Items.Add("KÄRPÄT"); cboxSeura.Items.Add("LUKKO");
            cboxSeura.Items.Add("PELICANS"); cboxSeura.Items.Add("SAIPA"); cboxSeura.Items.Add("SPORT");
            cboxSeura.Items.Add("TAPPARA"); cboxSeura.Items.Add("TPS"); cboxSeura.Items.Add("ÄSSÄT");
        }
        //pelaajan valinta
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listBox.SelectedItem != null)
                {
                    int sijainti = listBox.Items.IndexOf(listBox.SelectedItem);
                    txtboxEnimi.Text = null;
                    txtboxSnimi.Text = null;
                    txtboxHinta.Text = null;
                    cboxSeura.Text = null;
                    txtboxEnimi.Text = pelaajat[sijainti].getEnimi();
                    txtboxSnimi.Text = pelaajat[sijainti].getSnimi();
                    txtboxHinta.Text = pelaajat[sijainti].getSiirtohinta().ToString();
                    cboxSeura.Text = pelaajat[sijainti].getSeura();
                }
                tbStatus.Text = "Voit vaihtaa/tarkastella nyt pelaajan tietoja";
            }
            catch (Exception ex)
            {
                tbStatus.Text = "ongelmia pelaajan tietojen tarkastelusa";
            }
           
        }
        //valinnan tallennus
        private void btnTalleta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBox.SelectedItem != null)
                {
                    int sijainti = listBox.Items.IndexOf(listBox.SelectedItem);
                    pelaajat[sijainti].setTiedot(txtboxEnimi.Text, txtboxSnimi.Text, double.Parse(txtboxHinta.Text), cboxSeura.Text);
                    applyChanges();
                    listBox.SelectedItem = pelaajat[sijainti];
                    tbStatus.Text = "Pelaajan tallentaminen onnistui";
                }
            }
            catch (Exception)
            {
                tbStatus.Text = "Pelaajan tallentaminen epäonnistui";
            }

        }
        //poistetaan pelaaja
        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sijainti = listBox.Items.IndexOf(listBox.SelectedItem);
                pelaajat.RemoveAt(sijainti);
                applyChanges();
                tbStatus.Text = "Poistaminen onnistui";
            }
            catch (Exception)
            {
                tbStatus.Text = "Poistaminen epäonnistui";
            }
        }
        //kirjoitetaan pelaajat tiedostoon
        private void btnKirjoita_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = "D:\\Pelaajat.txt";
                using (StreamWriter sw = File.CreateText(filename))
                {
                    int apu = listBox.Items.Count;
                    for (int i = 0; i < apu; i++)
                    {
                        sw.WriteLine("pelaaja " + i + ": " + pelaajat[i].ToString());
                    }
                }
                tbStatus.Text = "Tiedostoon tallentaminen onnistui";
            }
            catch (Exception)
            {
                tbStatus.Text = "Tapahtui virhe tiedostoon tallennettaessa";
            }
             
        }
        //suljetaan ikkuna
        private void btnLopeta_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
