
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Tehtava11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SMLiigaEntities ctx;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            try
            {
                ctx = new SMLiigaEntities();
                ctx.Pelaajats.Load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnHaekannasta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pelaajat = ctx.Pelaajats.ToList();
                listBox.DataContext = pelaajat;
                listBox.DisplayMemberPath = "DisplayName";

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {


                spPelaajat.DataContext = listBox.SelectedItem;

            }
            catch (Exception  ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }
        Pelaajat UusiPelaaja;
        private void btnUusi_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                UusiPelaaja = new Pelaajat();
                UusiPelaaja.etunimi = "Aseta pelaajan tiedot";
                spPelaajat.DataContext = UusiPelaaja;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTallennaKantaan_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                UusiPelaaja = (Pelaajat)spPelaajat.DataContext;
                ctx.Pelaajats.Add(UusiPelaaja);
                ctx.SaveChanges();
                MessageBox.Show("Uusipelaaja tallennettiin kantaan");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pelaajat current = (Pelaajat)spPelaajat.DataContext;
                var retval = MessageBox.Show("Haluatko varmasti poistaa pelaajan" + current.DisplayName, "Pelaaja exe kysyy", MessageBoxButton.YesNo);
                if (retval == MessageBoxResult.Yes)
                {
                    ctx.Pelaajats.Remove(current);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
