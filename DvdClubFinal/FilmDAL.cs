using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdClubFinal
{
    class FilmDAL
    {
        public List<Film> IzlistajFilmove(Film izabraniZanr)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                return db.Films.ToList();

            }
        }

        public bool DodajFilmove(Film film)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                try
                {
                    db.Films.Add(film);
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
