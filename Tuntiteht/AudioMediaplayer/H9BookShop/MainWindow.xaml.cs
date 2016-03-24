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

namespace H9BookShop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnGetTestBooks_Click(object sender, RoutedEventArgs e) {
            dgBooks.DataContext = Bookshop.GetTestBooks();
        }

        private void getBooksSQL_Click(object sender, RoutedEventArgs e) {
            try
            {//haetaan kirjat SQL
                dgBooks.DataContext = Bookshop.GetBooks(true);
            }
            catch (Exception ex)
            {
             MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            //Mistä tiedetään mitä muokata? ----> Book-olio ID:stä!
            try
            {
                Book current = (Book)spBooks.DataContext;
               if (Bookshop.UpadeBook(current) > 0)
                {
                    MessageBox.Show(string.Format("kirjat päivitetty onnistuneesti"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnNew_Click(object sender, RoutedEventArgs e) {
            if (btnNew.Content.ToString() == "Uusi")
            {
                //luodaan uusi kirja - olio
                Book newBook = new Book(0);
                newBook.Name = "Anna Kirjan Nimi";
                spBooks.DataContext = newBook;
                btnNew.Content = "Tallenna uusi kantaan";
            }
            else
            {
                //tallennetaa
                Book current = (Book)spBooks.DataContext;
                Bookshop.InsertBook(current);
                dgBooks.DataContext = Bookshop.GetBooks(true);
                MessageBox.Show(string.Format("kirjat {0} tallennettu onnistuneesti", current.ToString()));
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            try
            {
                //Poistetaan valittu kirja
                Book current = (Book)spBooks.DataContext;
                var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan" + current.ToString(), "Wanhat kirjat kysyy", MessageBoxButton.YesNo);
                if( retval == MessageBoxResult.Yes)
                {
                    Bookshop.DeleteBook(current);
                    dgBooks.DataContext = Bookshop.GetBooks(true);
                    MessageBox.Show(string.Format("kirjat {0} poistettu tietokannasta",current.ToString()));
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            spBooks.DataContext = dgBooks.SelectedItem;
        }
    }
}
