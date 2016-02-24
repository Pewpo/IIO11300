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
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace _06a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlDataProvider xmldp = new XmlDataProvider();
        XmlDocument doc = new XmlDocument();
        public MainWindow()
        {
            InitializeComponent();
            //haetaan tiedoston sijainti app.configista
            string vineFileLocation;
            try
            {
                vineFileLocation = ConfigurationManager.AppSettings.Get("vineFile");
                xmldp.Source = new Uri(vineFileLocation);
                xmldp.XPath = "/viinikellari/wine";
                tbStatus.Text = vineFileLocation;
                doc.Load(vineFileLocation);
                XmlNodeList root = doc.SelectNodes("/viinikellari/wine/maa");
                //syötetään maat comboboxiin
                comboBox.Items.Add("Näytä Kaikki viinit");
                foreach (XmlNode nimi in root)
                {
                    if (!comboBox.Items.Contains(nimi.InnerText))
                    {
                        comboBox.Items.Add(nimi.InnerText);
                    }
                }
                comboBox.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("jokin meni pieleen tiedostonhaussa tai maiden lisäämisessä comboboksiin. Korjaa virheet ja käynnistä ohjelma uudestaan");
                Application.Current.Shutdown();
            }
        }

        private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgNayta.Items.Clear();
                XmlNodeList root = doc.SelectNodes("/viinikellari/wine");
                //jos on valittu kaikki niin ajellaan foreachilla kaikki taulukkoon
                if (comboBox.SelectedItem.ToString() == "Näytä Kaikki viinit")
                {
                    foreach (XmlNode nimi in root)
                    {
                        dgNayta.Items.Add(nimi).ToString();
                    }
                }
                else
                {//jos ei ole valittu kaikkia niin selataan mikä on valittu ajellaan foreachilla taulukkoon
                    int i = 0;
                    foreach (XmlNode nimi in root)
                    {
                        var node = nimi.SelectNodes("/viinikellari/wine/maa");
                        if (node.Item(i).InnerText == comboBox.SelectedItem.ToString())
                        {
                            dgNayta.Items.Add(nimi).ToString();
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
  }

