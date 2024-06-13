using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public enum EnumKartaType
    {
        Jednokratna,
        Pretplatna 
    }

    public class Karta
    {
        public virtual int SerijskiBroj { get; set; }
        public virtual string KartaType { get; set; }
        public virtual DateTime? Datum { get; set; }
        public virtual DateTime? OdVreme { get; set; }
        public virtual DateTime? DoVreme { get; set; }
        //public virtual int RegistarskiBrojVozila { get; set; }
        public virtual Osoba ProdajaOsobi { get; set; }
        public virtual Vozilo OdnosiNaVozilo { get; set; }
        public virtual IList<KartaZone> ListaZona { get; set; }
        public virtual IskoriscenaKarta IskoriscenaKarta { get; set; }

        public Karta()
        {
            ListaZona = new List<KartaZone>();
            //this.IskoriscenaKarta = new List<IskoriscenaKarta>();
        }

    }

    public class Jednokratna : Karta
    {
        
    }
    public class Pretplatna : Karta
    {

    }

}
