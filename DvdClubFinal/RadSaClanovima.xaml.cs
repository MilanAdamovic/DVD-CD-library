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
using System.Windows.Shapes;

namespace DvdClubFinal
{
    /// <summary>
    /// Interaction logic for RadSaClanovima.xaml
    /// </summary>
    public partial class RadSaClanovima : Window
    {
        private int clanzaprenos;

        public int Clanzaprenos
        {
            get { return clanzaprenos; }
            set { clanzaprenos = value; }
        }
        ClanDAL clanDal = new ClanDAL();
        public RadSaClanovima()
        {
            InitializeComponent();
        }

        private void prikazClana(int clanzaprenos)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                Clan c1 = db.Clans.Single(c => c.ClanID == clanzaprenos);

                TextBoxIme.Text = c1.Ime;
                TextBoxPrezime.Text = c1.Prezime;
                TextBoxTelefon.Text = c1.Telefon;
                TextBoxAdresa.Text = c1.Adresa;

            }

        }
        private bool Validacija()
        {     // VALIDACIJA UNOSA CLANOVA       
            if (string.IsNullOrEmpty(TextBoxIme.Text))
            {
                MessageBox.Show("Morate uneti ime.", "Poruka");
                TextBoxIme.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TextBoxPrezime.Text))
            {
                MessageBox.Show("Morate uneti prezime.", "Poruka");
                TextBoxPrezime.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TextBoxAdresa.Text))
            {
                MessageBox.Show("Morate uneti broj telefona.", "Poruka");
                TextBoxAdresa.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TextBoxTelefon.Text))
            {
                MessageBox.Show("Morate uneti adresu.", "Poruka");
                TextBoxTelefon.Focus();
                return false;
            }
            return true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            prikazClana(clanzaprenos);
        }

        private void ButtonIznajmljavanje_Click(object sender, RoutedEventArgs e)
        {
            IznajmljivanjeFilmova najamFilm = new IznajmljivanjeFilmova();
            najamFilm.Clanzaprenos = Clanzaprenos;
            najamFilm.ShowDialog();
        }

        private void ButtonVracanje_Click(object sender, RoutedEventArgs e)
        {
            VracanjeFilmova vracanje = new VracanjeFilmova();
            vracanje.ShowDialog();
        }

        private void ButtonIzmeniClana_Click(object sender, RoutedEventArgs e)
        {
            IzmenaClanova izClan = new IzmenaClanova();
            izClan.ShowDialog();
        }

        private void ButtonDodajClana_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeClanova dodClana = new DodavanjeClanova();
            dodClana.ShowDialog();
        }

        private void ButtonObrisiClana_Click(object sender, RoutedEventArgs e)
        {
            BrisanjeClanova bClan = new BrisanjeClanova();
            bClan.ShowDialog();
            

        }
    }
}
