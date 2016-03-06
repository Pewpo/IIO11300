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

namespace Tehtava07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int smallLetter;
        int bigLetter;
        int number;
        int special;
        int marks;
        int classes;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {   //otetaan tiedot ylös
            classes = 0;
             smallLetter =  txtPassword.Text.ToString().Count(char.IsLower);
             bigLetter = txtPassword.Text.ToString().Count(char.IsUpper);
             number = txtPassword.Text.ToString().Count(char.IsNumber);
             int  whitespace = txtPassword.Text.ToString().Count(char.IsWhiteSpace);
             int  special1 = txtPassword.Text.ToString().Count(char.IsSymbol);
             int  special2 = txtPassword.Text.ToString().Count(char.IsPunctuation);
             special = special1 + special2 + whitespace;
             marks = smallLetter + bigLetter + number + special;
            //tarkistetaan monenko eri luokan merkkejä salasanassa on
            if(smallLetter > 0)
            {
                classes++;
            }
            if (bigLetter > 0)
            {
                classes++;
            }
            if (number > 0)
            {
                classes++;
            }
            if(special > 0)
            {
                classes++;
            }
            ChangeLetters();
        }
        private void ChangeLetters()
        {   //textblockien teksti muutetaan
            txtMarks.Text = "Merkkejä : " + marks.ToString();
            txtBig.Text = "Isoja Kirjaimia : " + bigLetter.ToString();
            txtSmall.Text = "Pieniä Kirjaimia : " + smallLetter.ToString();
            txtNumber.Text = "Numeroita : " + number.ToString();
            txtSpecial.Text = "Erikoismerkkejä : " + special.ToString();
            ChangeState();
        }
        private void ChangeState()
        { // Vaihetaan tilaa sen mukaan kuinka vahva saalsana on
            Brush color;
            if (marks < 8 || classes < 2) 
            {
                color = Brushes.Orange;
                txtColor.Background = color;
                txtColor.Text = "Bad";
            }
            else if(marks < 12 || classes < 3) 
            {
                color = Brushes.Yellow;
                txtColor.Background = color;
                txtColor.Text = "Fair";
            }
            else if (marks < 16 || classes < 4)
            {
                color = Brushes.LightGreen;
                txtColor.Background = color;
                txtColor.Text = "Moderate";
            }
            else if (marks < 16 || classes == 4)
            {
                color = Brushes.Green;
                txtColor.Background = color;
                txtColor.Text = "Good";
            }
        }
    }
}
