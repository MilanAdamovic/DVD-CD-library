using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdClubFinal
{
    class IznajmljivanjeDAL
    {
        public List<Iznajmljivanje> IzlistajNajam(Iznajmljivanje izabraniNajam)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                
                return db.Iznajmljivanjes.ToList();
               
            }
        }
        public bool dodajIznajmljivanje(Iznajmljivanje iznajmljivanje)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                try
                {
                    db.Iznajmljivanjes.Add(iznajmljivanje);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public bool Vracanje(Iznajmljivanje iznajmljivanje)
        {
            using (DvdKlubEntities db = new DvdKlubEntities())
            {
                try
                {
                    Iznajmljivanje c1 = db.Iznajmljivanjes.Single(c => c.IznajmljivanjeID == iznajmljivanje.IznajmljivanjeID);

                    db.Iznajmljivanjes.Remove(c1);
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
