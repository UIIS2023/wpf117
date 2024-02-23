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
using System.Windows.Shapes;

namespace WPFKnjižara.Forme
{
    /// <summary>
    /// Interaction logic for FrmLogIn.xaml
    /// </summary>
    public partial class FrmLogIn : Window
    {



        public FrmLogIn()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {

            Konekcija kon = new Konekcija();
            SqlConnection konekcija = new SqlConnection();
            konekcija = kon.KreirajKonekciju();
            konekcija.Open();
            SqlCommand cmd = new SqlCommand
            {
                Connection = konekcija
            };
            cmd.Parameters.Add("@KorisnickoIme", SqlDbType.NVarChar).Value = txtUsername.Text;
            cmd.Parameters.Add("@Lozinka", SqlDbType.NVarChar).Value = txtPassword.Password;
            cmd.CommandText = @"select * from tblKredencijali where KorisnickoIme=@KorisnickoIme and Lozinka=@Lozinka";
            SqlDataReader citac = cmd.ExecuteReader();
            cmd.Dispose();

            if (citac.Read())
            {
                MessageBox.Show("Uspesno Ulogovan!", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Neuspesna lozinka i korisnicko ime!", "Informacija", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            konekcija.Close();

           
        }

    }
}
