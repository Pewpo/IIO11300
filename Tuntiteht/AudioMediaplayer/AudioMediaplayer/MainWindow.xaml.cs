﻿using System;
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
using Microsoft.Win32;
namespace AudioMediaplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsPlaying = false;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            //Kootaan tänne kaikki alustukset mitä tarvitaan ohjelman
            //suorittamiseksi
            txtFileName.Text = "D:\\H9577\\REPOS\\IIO11300\\Tuntiteht\\AudioMediaplayer\\AudioMediaplayer\\Coffeemaker.mp4";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((txtFileName.Text.Length > 0) && System.IO.File.Exists(txtFileName.Text))
                {
                    mediaElement.Source = new Uri(txtFileName.Text);
                    mediaElement.Play();
                    IsPlaying = true;
                    //nappulat käyttöön
                    SetMyButtons();

                }
                else
                {
                    MessageBox.Show("Tiedostoa" + txtFileName.Text + " ei löydy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnpause_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlaying)
            {
                mediaElement.Pause();
                IsPlaying = false;
                btnpause.Content = "Continue";
            }
            else
            {
                mediaElement.Play();
                IsPlaying = true;
                btnpause.Content = "Pause";
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            IsPlaying = false;
            //nappulat käyttöön
            SetMyButtons();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void SetMyButtons()
        {
            btnpause.IsEnabled = IsPlaying;
            btnStop.IsEnabled = IsPlaying;
            btnPlay.IsEnabled = !IsPlaying;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            //haetaan käyttäjän vakiodialogilla valitsema tiedosto textboxiin
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\H9577\\";
            ofd.Filter = "Musiikkitiedostot|*.mp3|Video-tiedosto|*.mp4|All files|*.*";
            //muuttuajan Nullable<bool> arvo voi olla null, true tai false
            Nullable<bool> result  = ofd.ShowDialog();
            if (result == true)
            {
                txtFileName.Text = ofd.FileName;
            }
        }
    }
}
