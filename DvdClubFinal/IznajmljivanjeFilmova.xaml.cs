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
    /// Interaction logic for IznajmljivanjeFilmova.xaml
    /// </summary>
    public partial class IznajmljivanjeFilmova : Window
    {
        public IznajmljivanjeFilmova()
        {
            InitializeComponent();
        }

        private int clanzaprenos;

        public int Clanzaprenos
        {
            get { return clanzaprenos; }
            set { clanzaprenos = value; }
        }
        
        private void napuniKombo()
        {
            FilmDAL fDAL = new FilmDAL();
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                List<Film> listaFilmova = fDAL.IzlistajFilmove(izabraniZanr);
                comboBox1.ItemsSource = listaFilmova;
                comboBox1.DisplayMemberPath = "Zanr";
                comboBox1.SelectedValuePath = "Zanr";
            }
            
        }

        private Film izabraniZanr;
        private Film izabraniFilm;
        private Iznajmljivanje izabraniNajam;
        private void prikazClana(int clanzaprenos)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                Clan c1 = db.Clans.Single(c => c.ClanID == clanzaprenos);

                labelIme.Content = c1.PunoIme;
            }
        }

        

        private void puniListu(Film izabraniZanr)
        {
            
            FilmDAL fDal = new FilmDAL();
            listViewFilmovi.DataContext = fDal.IzlistajFilmove(izabraniZanr);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            napuniKombo();
            izabraniZanr = (Film)comboBox1.SelectedItem;
            datePicker1.SelectedDate = DateTime.Today.Date;
            datePicker2.SelectedDate = DateTime.Today.Date;
            
            
            prikazClana(clanzaprenos);
            
        }

        private void ButtonIznajmi_Click(object sender, RoutedEventArgs e)
        {
            if (listViewFilmovi.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati film");
            }

            if (datePicker2.SelectedDate == DateTime.Today.Date)
            {
                MessageBox.Show("Morate odabrati datum vracanja");
            }

            IznajmljivanjeDAL iDAL = new IznajmljivanjeDAL();
            
            Iznajmljivanje najam = new Iznajmljivanje();
            try
            {
                najam.ClanID = clanzaprenos;
                najam.FilmID = izabraniFilm.FilmID;
                najam.DatumIznajmljivanja = datePicker1.SelectedDate.Value;
                najam.DatumVracanja = datePicker2.SelectedDate.Value;
                

            }
            catch (Exception)
            {
                
                throw;
            }
            bool rez = iDAL.dodajIznajmljivanje(najam);
            if (rez)
            {
                MessageBox.Show("Uspesno ste iznajmili film ", "Poruka");

                
            }
            else
            {
                MessageBox.Show("Greska pri radu sa bazom", "Poruka");
            }
            
            listViewZaduzenje.DataContext = iDAL.IzlistajNajam(izabraniNajam);
            
        }

        private void ButtonOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void listViewFilmovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            izabraniFilm = (Film)listViewFilmovi.SelectedItem;
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            izabraniZanr = (Film)comboBox1.SelectedItem;
            puniListu(izabraniZanr);

        }
    
    }
}
