using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE Karta (
//    SerijskiBroj NUMBER PRIMARY KEY,
//    KARTATYPE NVARCHAR2(30) NOT NULL,
//    Datum DATE,
//    OdVreme TIMESTAMP,
//    DoVreme TIMESTAMP,
//    IDOsobe NUMBER,
//    RegistarskiBrojVozila  NVARCHAR2(7),
//    FOREIGN KEY (IDOsobe) REFERENCES Osoba(ID),
//    FOREIGN KEY (RegistarskiBrojVozila) REFERENCES Vozilo(RegistarskiBroj),
//    CONSTRAINT CheckVremeKarte CHECK(DoVreme > OdVreme),
//    CONSTRAINT CheckKartaType CHECK(KARTATYPE in ('Jednokratna', 'Pretplatna'))
//);

namespace ParkingServis.Mapiranja
{
    public class KartaMap : ClassMap<Karta>
    {
        public KartaMap()
        {
            Table("Karta");
            Id(x => x.SerijskiBroj, "SerijskiBroj").GeneratedBy.Assigned();

            DiscriminateSubClassesOnColumn("KARTATYPE");

            Map(x => x.Datum, "Datum");
            Map(x => x.OdVreme, "OdVreme");
            Map(x => x.DoVreme, "DoVreme");

            References(x => x.ProdajaOsobi).Column("IDOsobe").LazyLoad();
            References(x => x.OdnosiNaVozilo).Nullable().Column("REGISTARSKIBROJVOZILA").LazyLoad().Cascade.All(); ;
            

            HasMany(x => x.ListaZona).KeyColumn("SerijskiBrojKarta").Inverse().Cascade.All();

            
            HasOne(x => x.IskoriscenaKarta)
                .PropertyRef(nameof(IskoriscenaKarta.KupljenaNaKioskuKarta))
                //.Cascade.All();
                .Cascade.None();


            //CheckConstraint("DoVreme > OdVreme");
        }
    }
    public class JednokratnaMap : SubclassMap<Jednokratna>
    {
        public JednokratnaMap()
        {
            DiscriminatorValue("Jednokratna");
        }
    }

    public class PretplatnaMap : SubclassMap<Pretplatna>
    {
        public PretplatnaMap()
        {
            DiscriminatorValue("Pretplatna");
        }
    }
}
