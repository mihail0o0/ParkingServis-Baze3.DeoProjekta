using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE KartaZone (
//    SerijskiBrojKarte NUMBER,
//    Zona NVARCHAR2(30),
//    CONSTRAINT PK_KartaZone PRIMARY KEY(SerijskiBrojKarte, Zona)
//);

namespace ParkingServis.Mapiranja
{
    public class KartaZoneMap : ClassMap<KartaZone>
    {
        public KartaZoneMap()
        {
            Table("KartaZone");
            
            Id(x => x.Id, "ID").GeneratedBy.Assigned();

            Map(x => x.Zona, "Zona");
            References(x => x.Karta).Column("SerijskiBrojKarte").Not.Nullable().LazyLoad();

        }
    }
}
