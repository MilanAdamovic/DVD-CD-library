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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DvdClubFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void napuniKombo()
        {
            ClanDAL cDAL = new ClanDAL();
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                List<Clan> listaClanova = cDAL.IzlistajClanove();
                ComboBox1.ItemsSource = listaClanova;
                ComboBox1.DisplayMemberPath = "PunoIme";
                ComboBox1.SelectedValuePath = "ClanID";
            }
        }
        private void pristup()
        {
            if (ComboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite ime", "Poruka");
                return;
            }
            try
            {
                Clan odabraniClan = (Clan)ComboBox1.SelectedItem;


                if (odabraniClan.ClanID == Int32.Parse(TextBoxBrojClanske.Text))
                {
                    if (string.IsNullOrEmpty(TextBoxBrojClanske.Text))
                    {
                        MessageBox.Show("Morate upisati broj clanske karte", "Poruka");
                        return;
                    }

                    Clan Clanzaprenos = new Clan();
                    Clanzaprenos.ClanID = Convert.ToInt32(TextBoxBrojClanske.Text);                    

                    RadSaClanovima rsCla = new RadSaClanovima();
                    rsCla.Clanzaprenos = Clanzaprenos.ClanID;

                    rsCla.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Uneli ste pogrešan broj clanske karte", "Poruka");
                    TextBoxBrojClanske.Clear();
                    TextBoxBrojClanske.Focus();
                    return;
                }
            }

            catch (Exception ecp)
            {
                MessageBox.Show(ecp.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            napuniKombo();
        }

        private void ButtonPronadjiClana_Click(object sender, RoutedEventArgs e)
        {
            pristup();
        }

        private void ButtonDodajClana_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeClanova dodClanova = new DodavanjeClanova();
            dodClanova.ShowDialog();
        }

        private void ButtonDodajFilmove_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeFilmova dodFilm = new DodavanjeFilmova();
            dodFilm.ShowDialog();
        }
    }
}
