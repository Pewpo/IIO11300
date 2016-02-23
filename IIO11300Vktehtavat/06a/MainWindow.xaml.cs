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

namespace _06a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlDataProvider xmldp;
        public MainWindow()
        {
            InitializeComponent();
            //haetaan tiedoston sijainti app.configista
            string vineFileLocation;
            vineFileLocation = ConfigurationManager.AppSettings.Get("vineFile");
            xmldp.Source = new Uri("vineFileLocation");
        }

        private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
