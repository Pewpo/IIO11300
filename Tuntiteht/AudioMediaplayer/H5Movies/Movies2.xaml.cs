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
using System.Windows.Shapes;
using System.Xml;

namespace H5Movies
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //haetaan xmlDataProviderin XML-tiedoston nimi

            //localpath palauttaa käyttöjärjestelmä muodossa hakemiston nimen
            string filu = xdpMovies.Source.LocalPath;
            //tallennnetaan raakasti XmlDocument olemassaolevan XML-tiedoston päälle!!!
            xdpMovies.Document.Save(filu);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //Asetetaan textboxit viittaamaan pois datasta eli listasta ei ole valittuna mitään
            if (lbMovies.SelectedIndex >= 0)
            {
                lbMovies.SelectedIndex = -1; // -1 tarkoittaa että listasta ei ole valittu mitään
                btnCreate.Content = "Tallenna";
            }
            else
            {
                try
                {
                    //Lisätään uusi noodi XMLDocumenttiin
                    string filu = xdpMovies.Source.LocalPath;
                    // viittaus xmlDocumenttiin ja sen juurielementtiin
                    XmlDocument doc = xdpMovies.Document;
                    XmlNode root = doc.SelectSingleNode("/Movies");
                    //luodaan uusi node
                    XmlNode newMovie = doc.CreateElement("Movie");
                    //Lisätään nodella tarvittavat neljä attribuuttia
                    XmlAttribute xa1 = doc.CreateAttribute("Name");
                    xa1.Value = txtName.Text;
                    newMovie.Attributes.Append(xa1);
                    XmlAttribute xa2 = doc.CreateAttribute("Director");
                    xa2.Value = txtDirector.Text;
                    newMovie.Attributes.Append(xa2);
                    XmlAttribute xa3 = doc.CreateAttribute("Country");
                    xa3.Value = txtCountry.Text;
                    newMovie.Attributes.Append(xa3);
                    XmlAttribute xa4 = doc.CreateAttribute("Checked");
                    xa4.Value = chkChecked.IsChecked.ToString();
                    newMovie.Attributes.Append(xa4);
                    //lisätään noodi juureen
                    root.AppendChild(newMovie);
                    //tallennnetaan raakasti XmlDocument olemassaolevan XML-tiedoston päälle!!!
                    xdpMovies.Document.Save(filu);
                    //Kaikki ok
                    MessageBox.Show("Uusi elokuva : " + txtName.Text + " lisätty onnistuneesti!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    btnCreate.Content = "Lisää elokuva";
                }

            }
       }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Poistetaan käyttäjän valitsema elokuva --> poistettava node haetaan Name-attribuutin avulla
            try
            {
                string filu = xdpMovies.Source.LocalPath;
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                XmlNode poistettava = null;
                //haetaan XPathilla poistettava node
                var item = doc.SelectSingleNode(string.Format("/Movies/Movie[@Name = '{0}']", txtName.Text));
                if ((item != null) && (MessageBox.Show(
                    "Poistetaanko elokuva " + txtName.Text, "Samulin ElokuvaGalleria",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    poistettava = item;
                }
                if(poistettava != null)
                {
                    //poistetaan noodi juuresta
                    root.RemoveChild(poistettava);
                    xdpMovies.Document.Save(filu);
                    //listboxin osoitin
                    lbMovies.SelectedIndex = -1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
