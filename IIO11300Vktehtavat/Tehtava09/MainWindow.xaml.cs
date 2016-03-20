using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Tehtava09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ConnStr;
        private string TableName;
        private DataTable dt;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            try
            {
                ConnStr = Tehtava09.Properties.Settings.Default.Tietokanta;
                TableName = Tehtava09.Properties.Settings.Default.Taulu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bthHaeAsiakkaat_Click(object sender, RoutedEventArgs e)
        {         
            dt = Yhteys.GetAllCustomersFromSQLServer(ConnStr, TableName, "");
            dgAsiakkaat.ItemsSource = dt.DefaultView;
        }

        private void btnTeeUusi_Click(object sender, RoutedEventArgs e)
        {   //Luonti kentän näkyvyys
            spCombo.Visibility = Visibility.Visible;
        }

        private void btnLuo_Click(object sender, RoutedEventArgs e)
        {
            if (ConnStr != "" && tbEnimi.Text != "" && tbSnimi.Text != "" && tbOsoite.Text != "" && tbPnumero.Text != "" && tbKaupunki.Text != "" )
            {
                Yhteys.CreateNew(ConnStr, tbEnimi.Text, tbSnimi.Text, tbOsoite.Text, tbPnumero.Text, tbKaupunki.Text);
            }
            else
            {
                MessageBox.Show("Täytä ensin kaikki kentät kunnolla");
            }
        }

        private void bthPoistaValittu_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataRowView drv = (DataRowView)dgAsiakkaat.SelectedItem;
                string lastname = drv["lastname"].ToString();
                MessageBoxResult msgbox = MessageBox.Show("Haluatko poistaa henkilön " + lastname, "Poista henkilö", MessageBoxButton.YesNo);
                if (msgbox == MessageBoxResult.Yes)
                {
                    Yhteys.DeleteHenkilo(ConnStr, lastname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("valitse ensin poistettava henkilö");
            }

        }


    }
}