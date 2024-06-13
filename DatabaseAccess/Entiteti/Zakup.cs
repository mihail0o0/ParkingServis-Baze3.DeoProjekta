using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class Zakup
    {
        public virtual int Id { get; set; }
        public virtual DateTime OdVreme { get; set; }
        public virtual DateTime DoVreme { get; set; }
        public virtual DateTime DatumPotpisa { get; set; }

        // strani kljucevi
        public virtual Osoba Osoba { get; set; }
        public virtual Vozilo Vozilo { get; set; }
        public virtual ParkingMesto ParkingMesto { get; set; }

        public Zakup()
        {
        }
    }



}
