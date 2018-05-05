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
    /// Interaction logic for DodavanjeFilmova.xaml
    /// </summary>
    public partial class DodavanjeFilmova : Window
    {
        public DodavanjeFilmova()
        {
            InitializeComponent();
        }

        FilmDAL fDAL = new FilmDAL();

        private void ButtonDodajFilm_Click(object sender, RoutedEventArgs e)
        {
            Film film = new Film();

            try
            {
                film.NazivFilma = TextBoxNFilma.Text;
                film.Zanr = TextBoxZanr.Text;
                film.Trajanje = TextBoxTrajanje.Text;
            }
            catch (Exception)
            {

                MessageBox.Show("Greska pri unosu filma", "Greska");
                return;
            }
            bool rez = fDAL.DodajFilmove(film);
            if (rez)
            {
                MessageBox.Show("Uspesno ste ubacili film", "Poruka");
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Greska pri radu sa bazom", "Poruka");
            }
        }

        private void ButtonOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
