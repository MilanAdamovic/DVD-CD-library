using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdClubFinal
{
    class ClanDAL
    {
        public List<Clan> IzlistajClanove()
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                return db.Clans.ToList();
            }
        }

        public bool UbaciClana(Clan clanovi)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                try
                {
                    db.Clans.Add(clanovi);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public bool PromeniClana(Clan clanovi)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                try
                {
                    Clan c1 = db.Clans.Single(c => c.ClanID == clanovi.ClanID);
                    c1.Ime = clanovi.Ime;
                    c1.Prezime = clanovi.Prezime;
                    c1.Adresa = clanovi.Adresa;
                    c1.Telefon = clanovi.Telefon;
                    c1.JMBG = clanovi.JMBG;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        public bool ObrisiClana(Clan clanovi)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                try
                {
                    Clan c1 = db.Clans.Single(c => c.ClanID == clanovi.ClanID);

                    db.Clans.Remove(c1);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
