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
    /// Interaction logic for IzmenaClanova.xaml
    /// </summary>
    public partial class IzmenaClanova : Window
    {
        public IzmenaClanova()
        {
            InitializeComponent();
        }
        ClanDAL cDal = new ClanDAL();
        private void napuniListu()
        {
            ClanDAL cDAL = new ClanDAL();
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                List<Clan> listaClanova = cDAL.IzlistajClanove();
                listView1.ItemsSource = listaClanova;
                listView1.DisplayMemberPath = "Ime";
                listView1.SelectedValuePath = "ClanID";
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
        private void ButtonPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedIndex < 0)
            {
                return;
            }
            if (!Validacija())
            {
                return;
            }
            Clan cl = (Clan)listView1.SelectedItem;

            cl.Ime = TextBoxIme.Text;
            cl.Prezime = TextBoxPrezime.Text;
            cl.Adresa = TextBoxAdresa.Text;
            cl.Telefon = TextBoxTelefon.Text;
            bool rez = cDal.PromeniClana(cl);
            if (rez)
            {

                napuniListu();
                listView1.SelectedValue = cl.ClanID;
                MessageBox.Show("Uspešno ste izvršili promenu podataka kod clana.", "Poruka");
                this.DialogResult = true;
            }
        }

        private void ButtonOdbi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView1.SelectedIndex < 0)
            {
                return;
            }
            Clan selektovaniClan = (Clan)listView1.SelectedItem;
            TextBoxIme.Text = selektovaniClan.Ime;
            TextBoxPrezime.Text = selektovaniClan.Prezime;
            TextBoxAdresa.Text = selektovaniClan.Adresa;
            TextBoxTelefon.Text = selektovaniClan.Telefon;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            napuniListu();
        }
    }
}
