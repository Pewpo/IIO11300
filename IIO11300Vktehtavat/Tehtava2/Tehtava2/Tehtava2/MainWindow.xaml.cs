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

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();

            cmbGame.Items.Add("Suomi");
            cmbGame.Items.Add("Viking Lotto");
            cmbGame.Items.Add("Eurojackpot");

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
                string Lines  = txtboxNumber.Text;
                // From string to int
                int numVal = Int32.Parse(Lines);

                if(numVal >= 15)
                {
                    MessageBox.Show("Select 1-14 drawns.");
                }
                else
                {
                    BLWindow window = new BLWindow();
                    txtBox.AppendText(window.drawGame(cmbGame.Text, numVal).ToString() );

                }
               


            }

            catch (Exception ex) {
                MessageBox.Show("Select number of drawns.");
            }
        }


    }
}
