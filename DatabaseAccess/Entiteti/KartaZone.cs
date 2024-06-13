using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class KartaZone
    {
        public virtual int Id{ get; set; }
        public virtual string Zona { get; set; }
        public virtual Karta Karta { get; set; }

        public KartaZone()
        {
        }
    }

}
