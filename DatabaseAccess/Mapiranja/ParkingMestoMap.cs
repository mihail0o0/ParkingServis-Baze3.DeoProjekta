using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE ParkingMesto (
//    ID NUMBER PRIMARY KEY,
//    TrenutniStatus NVARCHAR2(30) NOT NULL,
//    PARKINGMESTOTYPE NVARCHAR2(20) NOT NULL,
//    NazivUlice NVARCHAR2(30) NOT NULL,
//    Zona NVARCHAR2(30) NOT NULL,
//    RedniBroj NUMBER,
//    IDParkinga NUMBER,
//    Sprat NUMBER,
//    FOREIGN KEY (IDParkinga) REFERENCES Parking(ID),
//    CONSTRAINT CheckPMType CHECK(PARKINGMESTOTYPE in ('NaUlici', 'JavnoParkingMesto')),
//    CONSTRAINT CheckTS CHECK(TrenutniStatus in ('Zauzeto', 'Slobodno'))
//);

namespace ParkingServis.Mapiranja
{
    public class ParkingMestoMap : ClassMap<ParkingMesto>
    {
        public ParkingMestoMap()
        {
            Table("ParkingMesto");

            Id(x => x.ID).GeneratedBy.Assigned();

            DiscriminateSubClassesOnColumn("PARKINGMESTOTYPE");

            Map(x => x.TrenutniStatus, "TrenutniStatus").Not.Nullable();
            Map(x => x.NazivUlice, "NazivUlice").Not.Nullable();
            Map(x => x.Zona, "Zona").Not.Nullable();
            Map(x => x.RedniBroj, "RedniBroj");
            Map(x => x.Sprat, "Sprat");

            References(x => x.PripadaParkingu).Column("IDParkinga").Not.Nullable().LazyLoad();

            HasMany(x => x.ListaZakupa).Cascade.All().KeyColumn("IDParkingMesta");

            HasOne(x => x.IskoriscenaKarta)
                .PropertyRef(nameof(IskoriscenaKarta.ZaParkingMesto))
                //.Cascade.All();
                .Cascade.None();
            //HasMany(x => x.IskoriscenaKarta).Cascade.All().KeyColumn("IDParkingMesta");




            //CheckConstraint("PARKINGMESTOTYPE in ('NaUlici', 'JavnoParkingMesto')");
            //CheckConstraint("TrenutniStatus in ('Zauzeto', 'Slobodno')");
        }
    }

    public class NaUliciMap : SubclassMap<NaUlici>
    {
        public NaUliciMap()
        {
            DiscriminatorValue("NaUlici");
        }
    }

    public class JavnoParkingMestoMap : SubclassMap<JavnoParkingMesto>
    {
        public JavnoParkingMestoMap()
        {
            DiscriminatorValue("JavnoParkingMesto");
        }
    }
}
