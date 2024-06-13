using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE Parking (
//    ID NUMBER PRIMARY KEY,
//    MontazniObjekat NVARCHAR2(30) NOT NULL,
//    Zona NVARCHAR2(20) NOT NULL,
//    Adresa NVARCHAR2(30) NOT NULL,
//    OdVreme TIMESTAMP NOT NULL,
//    DoVreme TIMESTAMP NOT NULL,
//    BrojParkingMesta NUMBER NOT NULL,
//    Naziv NVARCHAR2(30) NOT NULL,
//    PARKINGTYPE NVARCHAR2(20) NOT NULL,
//    Spratovi NUMBER,
//    Nivoi NUMBER,
//    CONSTRAINT CheckBPM CHECK(BrojParkingMesta > 0),
//    CONSTRAINT CheckVreme CHECK(DoVreme > OdVreme),
//    CONSTRAINT CheckPType CHECK(PARKINGTYPE in ('Nadzemna', 'Podzemna')),
//    CONSTRAINT CheckMO CHECK(MontazniObjekat in ('Montazni', 'NijeMontazni'))
//);

namespace ParkingServis.Mapiranja
{
    public class ParkingMap : ClassMap<Parking>
    {
        public ParkingMap()
        {
            Table("Parking");

            Id(x => x.ID).GeneratedBy.Assigned();

            DiscriminateSubClassesOnColumn("PARKINGTYPE");

            Map(x => x.MontazniObjekat, "MontazniObjekat").Not.Nullable();
            Map(x => x.Zona, "Zona").Not.Nullable();
            Map(x => x.Adresa, "Adresa").Not.Nullable();
            Map(x => x.OdVreme, "OdVreme").Not.Nullable();
            Map(x => x.DoVreme, "DoVreme").Not.Nullable();
            Map(x => x.BrojParkingMesta, "BrojParkingMesta").Not.Nullable();
            Map(x => x.Naziv, "Naziv").Not.Nullable();
            Map(x => x.Spratovi, "Spratovi");
            Map(x => x.Nivoi, "Nivoi");

            HasMany(x => x.SadrziParkingMesta).KeyColumn("IDParkinga").Inverse().Cascade.All();

            //CheckConstraint("BrojParkingMesta > 0");
            //CheckConstraint("DoVreme > OdVreme");
            //CheckConstraint("PARKINGTYPE in ('Nadzemna', 'Podzemna')");
            //CheckConstraint("MontazniObjekat in ('Montazni', 'NijeMontazni')");
        }
    }

    public class NadzemnaMap : SubclassMap<Nadzemna>
    {
        public NadzemnaMap()
        {
            DiscriminatorValue("Nadzemna");
        }
    }

    public class PodzemnaMap : SubclassMap<Podzemna>
    {
        public PodzemnaMap()
        {
            DiscriminatorValue("Podzemna");
        }
    }
}
