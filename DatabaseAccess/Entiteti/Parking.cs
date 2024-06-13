using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public enum EnumParkingType
    {
        Nadzemna,
        Podzemna
    }

    public enum EnumMontazniObjekat
    {
        Montazni,
        NijeMontazni
    }

    public class Parking
    {
        public virtual int ID { get; set; }
        public virtual string MontazniObjekat { get; set; }
        public virtual string Zona { get; set; }
        public virtual string Adresa { get; set; }
        public virtual DateTime OdVreme { get; set; }
        public virtual DateTime DoVreme { get; set; }
        public virtual int BrojParkingMesta { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string ParkingType { get; set; }
        public virtual int? Spratovi { get; set; }
        public virtual int? Nivoi { get; set; }

        public virtual IList<ParkingMesto> SadrziParkingMesta { get; set; }


        public Parking()
        {
            SadrziParkingMesta = new List<ParkingMesto>();
        }
    }

    public class Nadzemna : Parking
    {

    }
    public class Podzemna : Parking
    {

    }
}
