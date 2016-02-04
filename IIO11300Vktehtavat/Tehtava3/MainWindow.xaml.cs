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
using System.Globalization;
using System.IO;

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public int numVal;

        public MainWindow()
        {

            InitializeComponent();

            cmbGame.Items.Add("Suomi");
            cmbGame.Items.Add("Viking Lotto");
            cmbGame.Items.Add("Eurojackpot");



        }
        
        public int GetWeek() {

            //haetaan mikä viikko suomessa on tällä hetkellä
            var culture = CultureInfo.GetCultureInfo("fi-FI");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            return weekNumber;
        }
        

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = String.Empty;
        }



        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                txtBox.Text = String.Empty;
                string Lines = txtboxNumber.Text;
                // From string to int
                 numVal = Int32.Parse(Lines);

                if (numVal >= 15)
                {
                    MessageBox.Show("Select 1-14 drawns.");
                }
                else
                {
                    BLWindow window = new BLWindow();
                    txtBox.AppendText(window.drawGame(cmbGame.Text, numVal).ToString());

                }



            }

            catch (Exception ex)
            {
                MessageBox.Show("Select number of drawns.");
            }
        }

        //kirjoitetaan rivit tiedostoon

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = "C:\\Users\\lottorivi" + GetWeek() + ".txt";
                if (filename.Length > 0)
                {
                    using (StreamWriter sw = File.CreateText(filename))
                    {

                            sw.WriteLine(txtBox.Text);
                 
                    }
                    tbMessages.Text = String.Format("Kirjoitettu {0} riviä tiedostoon {1}", numVal, filename);
                }
            }
            catch (Exception ex)
            {

                tbMessages.Text = ex.Message;
            }
        }

        private void btnWin_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = null;
            //luetaan teksitiedostoa rivi kerrallaan
            string filename = "C:\\Users\\lottorivi" + GetWeek() + ".txt";
            string line = null;
            if (filename.Length > 0)
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    line = null;
                    do
                    {
                        line = sr.ReadLine();
                        //yritin line.Split(':');  tiä käyttämällä saada jaettua ne eri osiin. valittaa jostain syystä että kenttä on null
                        //ja ei sen takia toimi. Koska en tätä saanut ratkottua tehtävän loppu puoli jäi tekemättä
                        if (txtRight.Text == line)
                        {
                            txtBox.Text += "Onneksi olkoon! Kaikki oikein!";
                        }
                        
                    } while (line != null);
                }
            }

        }
    }
}

