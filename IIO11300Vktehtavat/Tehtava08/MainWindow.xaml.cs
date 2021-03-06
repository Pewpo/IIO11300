﻿using System;
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

namespace Tehtava08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }
        private void GetData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava08.Properties.Settings.Default.Tietokanta))
                {
                    //yhteys
                    //DataAdapter
                    string sql = "SELECT  firstname, lastname, address, city FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("ViiniAsiakkaat");
                    da.Fill(dt);
                    //sidotaan datatable UI-Kontrolliin 
                    //xamlissa tehdään myös DisplayMemberPath = "lastname" jolla saadaan pelkää sukunimi  
                    lboxAsiakkaat.DataContext = dt;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
