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
    /// Interaction logic for BrisanjeClanova.xaml
    /// </summary>
    public partial class BrisanjeClanova : Window
    {
        public BrisanjeClanova()
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
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            napuniListu();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            Clan clanZaBrisanje = (Clan)listView1.SelectedItem;

            if (MessageBox.Show("Da li ste siguran da zelite da obrisete clana ?", "Upozorenje",
              MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                bool realizacijaBrisanja = cDal.ObrisiClana(clanZaBrisanje);
                if (realizacijaBrisanja)
                {
                    napuniListu();
                    listView1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Clan se ne može obrisati", "Obaveštenje");
                }
            }

        }

        private void buttonOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        
    }
}
