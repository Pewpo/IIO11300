using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data; //sisältää ADO;n perusluokat
using System.Data.SqlClient; // SQL Server spesifiset luokat
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H08ADONETlasnaolot
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
                using (SqlConnection conn = new SqlConnection(H08ADONETlasnaolot.Properties.Settings.Default.Tietokanta))
                {
                    //yhteys
                    //DataAdapter
                    string sql = "SELECT asioid, lastname, firstname, date FROM presences WHERE asioid = 'H9577'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("lasnaolot");
                    da.Fill(dt);
                    //sidotaan datatable UI-Kontrolliin   
                    myGrid.DataContext = dt;
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
