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
    /// Interaction logic for DodavanjeClanova.xaml
    /// </summary>
    public partial class DodavanjeClanova : Window
    {
        public DodavanjeClanova()
        {
            InitializeComponent();
        }

        private ClanDAL cDAL = new ClanDAL();
        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            Clan cl = new Clan();
            try
            {
                cl.Ime = TextBoxIme.Text;
                cl.Prezime = TextBoxPrezime.Text;
                cl.JMBG = TextBoxJMBG.Text;
                cl.Adresa = TextBoxAdresa.Text;
                cl.Telefon = TextBoxTelefon.Text;
            }
            catch
            {
                MessageBox.Show("Greska pri unosu podataka", "Greska");
                return;
            }
            bool rez = cDAL.UbaciClana(cl);
            if (rez)
            {
                MessageBox.Show("Uspesno ste ubacili clana ", "Poruka");
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
