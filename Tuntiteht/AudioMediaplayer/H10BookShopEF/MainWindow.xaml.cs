using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; //for ObservableCollection
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

namespace H10BookShopEF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    BookShopEntities ctx;
    ObservableCollection<Book> localBooks;
    ICollectionView view; // filtteröintiä varten
    bool isBooks;
    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }
    
    private void IniMyStuff()
    {
         //tänne kaikki tarvittavat alustukset
         ctx = new BookShopEntities();
         ctx.Books.Load();
            localBooks = ctx.Books.Local;
            //comboboxin täyttäminen kirjojen eri mailla tehdään tällä tavalla
            cbCountries.DataContext = localBooks.Select(n => n.country).Distinct();
            cbCountries.Visibility = Visibility.Visible;
            //View kirjojen filtterointia varten
            view = CollectionViewSource.GetDefaultView(localBooks);

    }
    private void btnHaeAsiakkaat_Click(object sender, RoutedEventArgs e)
    {
      //TODO
      var customers = ctx.Customers.ToList();
      dgBooks.DataContext = customers;
      isBooks = false;
    }

    private void btnHaeKirjat_Click(object sender, RoutedEventArgs e)
    {
            dgBooks.DataContext = localBooks;
            isBooks = true;
            cbCountries.SelectedIndex = -1;
    }

    private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
            if (isBooks)
            {
                spBook.DataContext = dgBooks.SelectedItem;
            }
            else
            {
                //valittu item (tässä tapauksessa Customer-olio) asetetaan stackpanelin dataconteksiksi
                spCustomer.DataContext = dgBooks.SelectedItem;
            }

    }

    private void btnTallenna_Click(object sender, RoutedEventArgs e)
    {
            //tallennetaan kirjaan tehdyt muutokset kantaan
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                tbMessage.Text = ex.Message;
            }
    }

    private void btnUusi_Click(object sender, RoutedEventArgs e)
    {
            //luodaan uusi kirja-olio ensin kontekstiin ja sitten tietokantaan
            Book newBook;
            if (btnUusi.Content.ToString() == "Uusi")
            {
                newBook = new Book();
                newBook.name = "Anna kirjan nimi";
                spBook.DataContext = newBook;
                btnUusi.Content = "Tallenna kantaan";
            }
            else
            {
                //lisätään uusi kirja ensin kontekstiin ja sieltä kantaan
                newBook = (Book)spBook.DataContext;
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                btnUusi.Content = "Uusi";
                tbMessage.Text = "lisättiin uusi kantaan";
            }
    }

    private void btnPoista_Click(object sender, RoutedEventArgs e)
    {
            //poistetaan valittu kirja-olio kontekstiksi ja sitten kannasta
            Book current = (Book)spBook.DataContext; // saadaan selville mitä kirjaa käyttäjä hipelöi
            var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan" + current.DisplayName, "Wanhat kirjat kysyy", MessageBoxButton.YesNo);
            if (retval == MessageBoxResult.Yes)
            {
                ctx.Books.Remove(current);
                ctx.SaveChanges();
            } 
    }

    private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
            //suodatetaan kirjat käyttäjän valinnan mukaan
            //suodatus tehdään ns predikaatti-funktiolla
            view.Filter = MyCountryFilter;
    }
    private bool MyCountryFilter(object item)
        {
            if(cbCountries.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return (item as Book).country.Contains(cbCountries.SelectedItem.ToString());
            }
        }
    private void btnHaeTilaukset_Click(object sender, RoutedEventArgs e)
    {       
        //Haetaan valitun asiakkaan tilaukset navigation properties avulla
        string msg = "";
        Customer current = (Customer)spCustomer.DataContext;
        msg += string.Format("Asiakkaalla {0} on {1} tilausta: \n", current.Displayname, current.OrderCount);
        foreach(var item in current.Orders)
        {
            msg += string.Format("Tilaus {0} sisältää {1} tilausriviä: \n", item.odate, item.Orderitems.Count);
            //kunkin tilauksen rivit ja sitä vastaava kirja
            Decimal summa = 0;
            foreach (var oitem in item.Orderitems)
            {
                    msg += string.Format("- kirja {0} kappaletta {1} \n", oitem.Book.name, oitem.count);
                    summa += oitem.count * oitem.Book.price.Value;
                    
            }
                msg += string.Format("-- Tilaus yhteensä {0} \n", summa);
            }
        MessageBox.Show(msg);
    }
    }
}
