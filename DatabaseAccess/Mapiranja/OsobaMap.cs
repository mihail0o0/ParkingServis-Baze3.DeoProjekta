using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE Osoba (
//    ID NUMBER PRIMARY KEY,
//    Adresa NVARCHAR2(30) NOT NULL,
//    LicnoIme NVARCHAR2(30) NOT NULL,
//    ImeRoditelja NVARCHAR2(30) NOT NULL,
//    Prezime NVARCHAR2(30) NOT NULL,
//    OSOBATYPE NVARCHAR2(20) NOT NULL,
//    JMBG NVARCHAR2(30) UNIQUE,
//    BrojLicneKarte NVARCHAR2(30) UNIQUE,
//    MestoIzdavanjaLicne NVARCHAR2(30),
//    BrojVozackeDozvole NVARCHAR2(30),
//    ZiviUZoni NVARCHAR2(30),
//    PIB NVARCHAR2(30),
//    Naziv NVARCHAR2(30),
//    CONSTRAINT CheckOType CHECK(OSOBATYPE in ('FizickoLice', 'PravnoLice'))
//);

namespace ParkingServis.Mapiranja
{
    public class OsobaMap : ClassMap<Osoba>
    {
        public OsobaMap()
        {
            Table("Osoba");
            Id(x => x.ID, "ID").GeneratedBy.Assigned();

            DiscriminateSubClassesOnColumn("OSOBATYPE");

            Map(x => x.Adresa, "Adresa").Not.Nullable();
            Map(x => x.LicnoIme, "LicnoIme").Not.Nullable();
            Map(x => x.ImeRoditelja, "ImeRoditelja").Not.Nullable();
            Map(x => x.Prezime, "Prezime").Not.Nullable();
            Map(x => x.JMBG, "JMBG").Unique();
            Map(x => x.BrojLicneKarte, "BrojLicneKarte").Unique();
            Map(x => x.MestoIzdavanjaLicne, "MestoIzdavanjaLicne");
            Map(x => x.BrojVozackeDozvole, "BrojVozackeDozvole");
            Map(x => x.ZiviUZoni, "ZiviUZoni");
            Map(x => x.PIB, "PIB");
            Map(x => x.Naziv, "Naziv");

            // TODO ovde bi vrv trebao delete orphan myb
            HasMany(x => x.ListTelefoni).KeyColumn("IDOsobe").Inverse().Cascade.DeleteOrphan();
            HasMany(x => x.KupovinaPretplatne).KeyColumn("IDOsobe").Inverse().Cascade.None();


            HasMany(x => x.ZakupljenaParkingMesta).Cascade.All().KeyColumn("IDOsobe");

            //CheckConstraint("OSOBATYPE in ('FizickoLice', 'PravnoLice')");
        }
    }

    public class FizickoLiceMap : SubclassMap<FizickoLice>
    {
        public FizickoLiceMap()
        {
            DiscriminatorValue("FizickoLice");
        }
    }

    public class PravnoLiceMap : SubclassMap<PravnoLice>
    {
        public PravnoLiceMap()
        {
            DiscriminatorValue("PravnoLice");
        }
    }
}
