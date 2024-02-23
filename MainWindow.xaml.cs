using WPFKnjižara.Forme;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace WPFKnjižara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Select upiti
        string zanrSelect = @"select ZanrID as ID, NazivZanra as Žanr from tblZanr";
        string pisacSelect = @"select PisacID as ID,ImePisca as 'Ime pisca', PrezimePisca as 'Prezime pisca' from tblPisac";
        string izdavacSelect = @"select IzdavanjeID as ID, NazivIzdanja as Izdanje from tblIzdanje";
        string korisnikSelect = @"select KorisnikID as ID, ImeKorisnika as 'Ime korisnika',PrezimeKorisnika as 'Prezime korisnika',AdresaKorisnika as 'Adresa korisnika',
                                           GradKorisnika as 'Grad korisnika',KontaktKorisnika as 'Kontakt korisnika' from tblKorisnik";
        string kupacSelect = @"select KupacID as ID, ImeKupca as 'Ime kupca', PrezimeKupca as 'Prezime kupca',AdresaKupca as 'Adresa kupca',
                                           GradKupca as 'Grad kupca',KontaktKupca as 'Kontakt kupca', ClanskaKarta as 'Clanska karta' from tblKupac";
        string racunSelect = @"select RacunID as ID ,tblKorisnik.PrezimeKorisnika as 'Prezime korisnika', tblKupac.PrezimeKupca as 'Prezime kupca',
                                     tblRacun.DatumIzdavanja as 'Datum izdavanja',tblRacun.CijenaProdaje as 'Cijena prodaje'
                                 from tblRacun
                                         join
                                           tblKorisnik on tblRacun.KorisnikID=tblKorisnik.KorisnikID
                                         join
                                           tblKupac on tblRacun.KupacID=tblKupac.KupacID;";
        string nabavkaSelect = @"select NabavkaID as ID, tblKorisnik.PrezimeKorisnika as 'Prezime korisnika', tblNabavka.DatumNabavke as 'Datum nabavke',
                                   tblNabavka.CijenaNabavke as 'Cijena nabavke'
                               from tblNabavka
                                    join
                                    tblKorisnik on tblNabavka.KorisnikID=tblKorisnik.KorisnikID;";
        string knjigaSelect = @"select KnjigaID as ID, tblKnjiga.ISBN as 'ISBN',tblKnjiga.Naslov as 'Naslov knjige',tblPisac.PrezimePisca as 'Prezime pisca',
                                 tblZanr.NazivZanra as 'Naziv zanra', tblIzdanje.NazivIzdanja as 'Naziv izdanja',
                                 tblRacun.CijenaProdaje as 'Cijena prodaje', tblNabavka.CijenaNabavke as 'Cijena nabavke'
                                   from tblKnjiga
                                    join 
                                       tblPisac on tblKnjiga.PisacID=tblPisac.PisacID
                                    join 
                                       tblZanr on tblKnjiga.ZanrID=tblZanr.ZanrID
                                    join
                                      tblIzdanje on tblKnjiga.IzdavanjeID=tblIzdanje.IzdavanjeID
                                    join 
                                      tblRacun on tblKnjiga.RacunID=tblRacun.RacunID
                                    join
                                      tblNabavka on tblKnjiga.NabavkaID=tblNabavka.NabavkaID;";



        #endregion
        #region Select upiti sa uslovom
        string selectUslovKnjige = @"select * from tblKnjiga where KnjigaID=";
        string selectUslovPisca = @"select * from tblPisac where PisacID=";
        string selectUslovZanra = @"select * from tblZanr where ZanrID=";
        string selectUslovIzdavac = @"select * from tblIzdanje where IzdavanjeID= ";
        string selectUslovRacun = @"select * from tblRacun where RacunID=";
        string selectUslovNabavka = @"select * from tblNabavka where NabavkaID=";
        string selectUslovKorisnik = @"select * from tblKorisnik where KorisnikID=";
        string selectUslovKupac = @"select * from tblKupac where KupacID=";
        #endregion

        #region Delete upiti
        string knjigaDelete = @"delete from tblKnjiga where KnjigaID=";
        string pisacDelete = @"delete from tblPisac where PisacID=";
        string zanrDelete = @"delete from tblZanr where ZanrID=";
        string izdavacDelete = @"delete from tblIzdanje where IzdavanjeID=";
        string racunDelete = @"delete from tblRacun where RacunID=";
        string nabavkaDelete = @"delete from tblNabavka where NabavkaID=";
        string korisnikDelete = @"delete from tblKorisnik where KorisnikID=";
        string kupacDelete = @"delete from tblKupac where KupacID=";

        #endregion


        
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        string ucitanaTabela;
        public bool azuriraj;
        
        
 
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(dataGridCentar, knjigaSelect);
        }

        private void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                SqlDataAdapter dateAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();
                /*  {
                      Locale = CultureInfo.InvariantCulture
                  };*/
                dateAdapter.Fill(dt);

                if (grid!=null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }

                ucitanaTabela = selectUpit;
                dt.Dispose();
                dateAdapter.Dispose();


            }
            catch(SqlException)
            {
                
                MessageBox.Show("Neuspjšeno ucitani podaci!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if(konekcija!=null)
                {
                    konekcija.Close();
                }
            }
        }

        void PopuniForme(DataGrid grid,string selectUslovi)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];    //puca
                cmd.CommandText = selectUslovi + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                cmd.Dispose();

                if(citac.Read())
                {
                    if(ucitanaTabela.Equals(knjigaSelect))
                    {
                        FrmKnjiga prozorKnjiga = new FrmKnjiga(azuriraj, red);
                        prozorKnjiga.txtISBN.Text = citac["ISBN"].ToString();
                        prozorKnjiga.txtNaslov.Text = citac["Naslov"].ToString();
                        prozorKnjiga.cbPisac.SelectedValue = citac["PisacID"].ToString();
                        prozorKnjiga.cbZanr.SelectedValue = citac["ZanrID"].ToString();
                        prozorKnjiga.cbIzdavanje.SelectedValue = citac["IzdavanjeID"].ToString();
                        prozorKnjiga.cbRacun.SelectedValue = citac["RacunID"].ToString();
                        prozorKnjiga.cbNabavka.SelectedValue = citac["NabavkaID"].ToString();
                        prozorKnjiga.ShowDialog();

                    }
                    else if(ucitanaTabela.Equals(pisacSelect))
                    {
                        FrmPisac prozorPisac = new FrmPisac(azuriraj, red);
                        prozorPisac.txtPisacIme.Text = citac["ImePisca"].ToString();
                        prozorPisac.txtPisacPrezime.Text = citac["PrezimePisca"].ToString();
                        prozorPisac.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(zanrSelect))
                    {
                        FrmŽanr prozorZanr = new FrmŽanr(azuriraj, red);
                        prozorZanr.txtNazivZanra.Text = citac["NazivZanra"].ToString();
                        prozorZanr.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(izdavacSelect, StringComparison.Ordinal))
                    {
                        FrmIzdanje prozorIzdanje = new FrmIzdanje(azuriraj, red);
                        prozorIzdanje.txtNazivIzdanja.Text = citac["NazivIzdanja"].ToString();
                        prozorIzdanje.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(racunSelect))
                    {
                        FrmRačun prozorRacun = new FrmRačun(azuriraj, red);
                        prozorRacun.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorRacun.cbKupac.SelectedValue = citac["KupacID"].ToString();
                        prozorRacun.dpDatumIzdavanja.SelectedDate = ((DateTime)citac["DatumIzdavanja"]).Date;
                        prozorRacun.txtCijenaProdaje.Text = citac["CijenaProdaje"].ToString();
                        prozorRacun.ShowDialog();

                    }
                    else if(ucitanaTabela.Equals(nabavkaSelect))
                    {
                        FrmNabavka prozorNabavka=new FrmNabavka(azuriraj, red);
                        prozorNabavka.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorNabavka.dpDatumNabavke.SelectedDate = ((DateTime)citac["DatumNabavke"]).Date;
                        prozorNabavka.txtCijenaNabavke.Text = citac["CijenaNabavke"].ToString();    //puca
                        prozorNabavka.ShowDialog();

                    }
                    else if(ucitanaTabela.Equals(korisnikSelect))
                    {
                        FrmKorisnik prozorKorisnik = new FrmKorisnik(azuriraj, red);
                        prozorKorisnik.txtImeKorisnika.Text = citac["ImeKorisnika"].ToString();
                        prozorKorisnik.txtPrezimeKorisnika.Text = citac["PrezimeKorisnika"].ToString();
                        prozorKorisnik.txtAdresaKorisnika.Text = citac["AdresaKorisnika"].ToString();
                        prozorKorisnik.txtGradKorisnika.Text = citac["GradKorisnika"].ToString();
                        prozorKorisnik.txtKontaktKorisnika.Text = citac["KontaktKorisnika"].ToString();
                        prozorKorisnik.ShowDialog();

                    }
                    else if(ucitanaTabela.Equals(kupacSelect))
                    {
                        FrmKupac prozorKupac = new FrmKupac(azuriraj, red);
                        prozorKupac.txtImeKupca.Text = citac["ImeKupca"].ToString();
                        prozorKupac.txtPrezimeKupca.Text = citac["PrezimeKupca"].ToString();
                        prozorKupac.txtAdresaKupca.Text = citac["AdresaKupca"].ToString();
                        prozorKupac.txtGradKupca.Text = citac["GradKupca"].ToString();
                        prozorKupac.txtKontaktKupca.Text = citac["KontaktKupca"].ToString();
                        prozorKupac.cbxClanskaKarta.IsChecked = (Boolean)citac["ClanskaKarta"];
                        prozorKupac.ShowDialog();
                    }
                }

            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            
            finally
            {
                if(konekcija!=null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }

        private void btnKnjiga_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar,knjigaSelect);
        }

        private void btnPisac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar, pisacSelect);
        }

        private void btnZanr_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar, zanrSelect);
        }

        private void btnIzdanje_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar, izdavacSelect);
        }

        private void btnNabavka_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar, nabavkaSelect);
        }

        private void btnRacun_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar, racunSelect);
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar, korisnikSelect);
        }

        private void btnKupac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentar, kupacSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if(ucitanaTabela.Equals(knjigaSelect))
            {
                prozor = new FrmKnjiga();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, knjigaSelect);
            }
            else if(ucitanaTabela.Equals(pisacSelect))
            {
                prozor = new FrmPisac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, pisacSelect);
            }
            else if(ucitanaTabela.Equals(zanrSelect))
            {
                prozor = new FrmŽanr();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, zanrSelect);
            }
            else if(ucitanaTabela.Equals(izdavacSelect))
            {
                prozor = new FrmIzdanje();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, izdavacSelect);
            }
            else if(ucitanaTabela.Equals(nabavkaSelect))
            {
                prozor = new FrmNabavka();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, nabavkaSelect);

            }
            else if(ucitanaTabela.Equals(racunSelect))
            {
                prozor = new FrmRačun();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, racunSelect);
            }
            else if(ucitanaTabela.Equals(kupacSelect))
            {
                prozor = new FrmKupac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, kupacSelect);
            }
            else if(ucitanaTabela.Equals(korisnikSelect))
            {
                prozor = new FrmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentar, korisnikSelect);
            }

        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            if(ucitanaTabela.Equals(knjigaSelect))
            {
                PopuniForme(dataGridCentar, selectUslovKnjige);
                UcitajPodatke(dataGridCentar, knjigaSelect);
            }
            else if(ucitanaTabela.Equals(pisacSelect))
            {
                PopuniForme(dataGridCentar, selectUslovPisca);
                UcitajPodatke(dataGridCentar, pisacSelect);
            }
            else if(ucitanaTabela.Equals(zanrSelect))
            {
                PopuniForme(dataGridCentar, selectUslovZanra);
                UcitajPodatke(dataGridCentar, zanrSelect);
            }
            else if(ucitanaTabela.Equals(izdavacSelect))
            {
                PopuniForme(dataGridCentar, selectUslovIzdavac);
                UcitajPodatke(dataGridCentar, izdavacSelect);
            }
            else if(ucitanaTabela.Equals(racunSelect))
            {
                PopuniForme(dataGridCentar,selectUslovRacun);
                UcitajPodatke(dataGridCentar,racunSelect);
            }
            else if(ucitanaTabela.Equals(nabavkaSelect))
            {
                PopuniForme(dataGridCentar, selectUslovNabavka);
                UcitajPodatke(dataGridCentar, nabavkaSelect);
            }
            else if(ucitanaTabela.Equals(korisnikSelect))
            {
                PopuniForme(dataGridCentar, selectUslovKorisnik);
                UcitajPodatke(dataGridCentar, korisnikSelect);
            }
            else if(ucitanaTabela.Equals(kupacSelect))
            {
                PopuniForme(dataGridCentar, selectUslovKupac);
                UcitajPodatke(dataGridCentar, kupacSelect);
            }

        }

         void ObrisiZapis(DataGrid grid, string deleteUpiti)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentar.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(rezultat==MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    //puca
                    cmd.CommandText = deleteUpiti + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obavjestenje!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama!","Obavjestenje!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija!=null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            if(ucitanaTabela.Equals(knjigaSelect))
            {
                ObrisiZapis(dataGridCentar, knjigaDelete);
                UcitajPodatke(dataGridCentar, knjigaSelect);
            }
            else if(ucitanaTabela.Equals(pisacSelect))
            {
                ObrisiZapis(dataGridCentar, pisacDelete);
                UcitajPodatke(dataGridCentar, pisacSelect);
            }
            else if(ucitanaTabela.Equals(zanrSelect))
            {
                ObrisiZapis(dataGridCentar, zanrDelete);
                UcitajPodatke(dataGridCentar, zanrSelect);
            }
            else if(ucitanaTabela.Equals(izdavacSelect))
            {
                ObrisiZapis(dataGridCentar, izdavacDelete);
                UcitajPodatke(dataGridCentar, izdavacSelect);
            }
            else if(ucitanaTabela.Equals(racunSelect))
            {
                ObrisiZapis(dataGridCentar, racunDelete);
                UcitajPodatke(dataGridCentar, racunSelect);
            }
            else if(ucitanaTabela.Equals(nabavkaSelect))
            {
                ObrisiZapis(dataGridCentar, nabavkaDelete);
                UcitajPodatke(dataGridCentar,nabavkaSelect);
            }
            else if(ucitanaTabela.Equals(korisnikSelect))
            {
                ObrisiZapis(dataGridCentar, korisnikDelete);
                UcitajPodatke(dataGridCentar, korisnikSelect);
            }
            else if(ucitanaTabela.Equals(kupacSelect))
            {
                ObrisiZapis(dataGridCentar, kupacDelete);
                UcitajPodatke(dataGridCentar, kupacSelect);
            }
        }
    }
}
