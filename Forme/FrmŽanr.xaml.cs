using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for FrmŽanr.xaml
    /// </summary>
    public partial class FrmŽanr : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmŽanr(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtNazivZanra.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();


        }

        public FrmŽanr()
        {
            InitializeComponent();
            txtNazivZanra.Focus();
            konekcija = kon.KreirajKonekciju();



        }

        private void txtbtnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@NazivZanra", System.Data.SqlDbType.NVarChar).Value = txtNazivZanra.Text;

                if(this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblZanr set NazivZanra=@NazivZanra where ZanrID=@id";
                    pomocniRed = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblZanr(NazivZanra) values (@NazivZanra);";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            
            
            }
            catch(SqlException)
            {
                MessageBox.Show("Unos odredjenih vrijednosti nije validan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {

                    konekcija.Close();

                }

            }

        }

        private void txtbtnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
