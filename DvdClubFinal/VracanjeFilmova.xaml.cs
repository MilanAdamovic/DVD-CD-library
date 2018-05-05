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
    /// Interaction logic for VracanjeFilmova.xaml
    /// </summary>
    public partial class VracanjeFilmova : Window
    {
        private int clanzaprenos;

        public int Clanzaprenos
        {
            get { return clanzaprenos; }
            set { clanzaprenos = value; }
        }
        public VracanjeFilmova()
        {
            InitializeComponent();
        }

        

        private Iznajmljivanje izabraniNajam;
        private void prikazClana(int clanxy)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                Clan c1 = db.Clans.Single(c => c.ClanID == clanzaprenos);

                labelIme.Content = c1.PunoIme;
            }
        }

        private void napuniListu()
        {
            IznajmljivanjeDAL iDal = new IznajmljivanjeDAL();
            listView1.ItemsSource = iDal.IzlistajNajam(izabraniNajam);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            napuniListu();
            prikazClana(clanzaprenos);
        }
        private void ButtonOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ButtonVraceno_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati film za vracanje","Poruka");
            }

            IznajmljivanjeDAL iDal = new IznajmljivanjeDAL();
            Iznajmljivanje najam = new Iznajmljivanje();

            listView1.SelectedItem = najam;

            bool rez = iDal.Vracanje(najam);
            if (rez)
            {
                MessageBox.Show("Usesno ste vratili film", "Poruka");
            }
            else
            {
                MessageBox.Show("Ne mozete vratiti film", "Obavestenje");
            }
            napuniListu();
        }

        
    }
}
