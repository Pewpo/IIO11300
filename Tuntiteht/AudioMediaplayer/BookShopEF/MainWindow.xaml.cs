using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // for observableCollection
using System.Data.Entity; //Tääki lisättiin
using System.ComponentModel;
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

namespace BookShopEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShopEntities ctx;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            //Tänne kaikki tarvittavat alustukset
            ctx = new BookShopEntities();
        }
        private void btnHaeAsiakkaat_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            var customers = ctx.Customers.ToList();
            dgBooks.DataContext = customers;
        }

        private void getHaeKirjat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Valittu item (tässä tapauksessa customer-olio) asetetaam staclåameöom datac
            spCustomer.DataContext = dgBooks.SelectedItem;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Tallennetaan kirjaan tehdyt muutokset kantaan
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi kirja-olio ensin kontekstiin ja sitten tietokantaan
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Poistetaan valittu kirja-olio konetkstiksi ja sitten kannasta
        }

        private void txtCountry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnHaeTilaukset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
