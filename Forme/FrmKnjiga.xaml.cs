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
    /// Interaction logic for FrmKnjiga.xaml
    /// </summary>
    public partial class FrmKnjiga : Window
    {
        
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
         bool azuriraj;
        DataRowView pomocniRed;

        public FrmKnjiga()
        {
            InitializeComponent();
            txtISBN.Focus();
            PopuniPadajuceListe();
            konekcija = kon.KreirajKonekciju();




        }

        public FrmKnjiga(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtISBN.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
            konekcija = kon.KreirajKonekciju();
            


        }

       

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                string vratiPisca = @"select PisacID, PrezimePisca  from tblPisac";
                SqlDataAdapter daPisac = new SqlDataAdapter(vratiPisca, konekcija);
                DataTable dtPisac = new DataTable();
                daPisac.Fill(dtPisac);
                cbPisac.ItemsSource = dtPisac.DefaultView;
                daPisac.Dispose();
                dtPisac.Dispose();

                string vratiZanr = @"select ZanrID, NazivZanra from tblZanr";
                SqlDataAdapter daZanr = new SqlDataAdapter(vratiZanr, konekcija);
                DataTable dtZanr = new DataTable();
                daZanr.Fill(dtZanr);
                cbZanr.ItemsSource = dtZanr.DefaultView;
                daZanr.Dispose();
                dtZanr.Dispose();

                string vratiIzdanje = @"select IzdavanjeID, NazivIzdanja from tblIzdanje";
                SqlDataAdapter daIzdanje = new SqlDataAdapter(vratiIzdanje, konekcija);
                DataTable dtIzdanje = new DataTable();
                daIzdanje.Fill(dtIzdanje);
                cbIzdavanje.ItemsSource = dtIzdanje.DefaultView;
                daIzdanje.Dispose();
                dtIzdanje.Dispose();

                string vratiRacun = @"select RacunID,DatumIzdavanja, CijenaProdaje from tblRacun";
                SqlDataAdapter daRacun = new SqlDataAdapter(vratiRacun, konekcija);
                DataTable dtRacun = new DataTable();
                daRacun.Fill(dtRacun);
                cbRacun.ItemsSource = dtRacun.DefaultView;
                daRacun.Dispose();
                dtRacun.Dispose();

                string vratiNabavku = @"select NabavkaID,DatumNabavke, CijenaNabavke from tblNabavka";
                SqlDataAdapter daNabavka = new SqlDataAdapter(vratiNabavku, konekcija);
                DataTable dtNabavka = new DataTable();
                daNabavka.Fill(dtNabavka);
                cbNabavka.ItemsSource = dtNabavka.DefaultView;
                daNabavka.Dispose();
                dtNabavka.Dispose();


            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                if (konekcija != null)
                {

                    konekcija.Close();

                }

            }
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
                cmd.Parameters.Add("@ISBN",SqlDbType.NVarChar).Value=txtISBN.Text;
                cmd.Parameters.Add("@Naslov", SqlDbType.NVarChar).Value = txtNaslov.Text;
                cmd.Parameters.Add("@PisacID", SqlDbType.Int).Value = cbPisac.SelectedValue;
                cmd.Parameters.Add("@ZanrID", SqlDbType.Int).Value = cbZanr.SelectedValue;
                cmd.Parameters.Add("@IzdavanjeID", SqlDbType.Int).Value = cbIzdavanje.SelectedValue;
                cmd.Parameters.Add("@RacunID", SqlDbType.Int).Value = cbRacun.SelectedValue;
                cmd.Parameters.Add("@NabavkaID", SqlDbType.Int).Value = cbNabavka.SelectedValue;

                if(this.azuriraj)
                {
                    DataRowView red =this.pomocniRed;
                    
                    
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                        cmd.CommandText = @"update tblKnjiga
                                        set ISBN=@ISBN, Naslov=@Naslov,PisacID=@PisacID, ZanrID=@ZanrID, IzdavanjeID=@IzdavanjeID , RacunID=@RacunID,NabavkaID=@NabavkaID
                                          where KnjigaID=@id";
                   
                    this.pomocniRed = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblKnjiga(ISBN,Naslov,PisacID,ZanrID,IzdavanjeID,RacunID,NabavkaID)
                                       values(@ISBN,@Naslov,@PisacID,@ZanrID,@IzdavanjeID,@RacunID,@NabavkaID);";

                }
                cmd.ExecuteNonQuery();
                //puca
                cmd.Dispose();
                this.Close();
                


            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrijednosti nije validan", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);


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
