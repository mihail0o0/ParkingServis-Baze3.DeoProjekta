using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE Vozilo (
//    RegistarskiBroj NVARCHAR2(7) PRIMARY KEY,
//    BrojSaobracajneDozvole NVARCHAR2(14) NOT NULL UNIQUE,
//    Proizvodjac NVARCHAR2(30) NOT NULL,
//    Model NVARCHAR2(30) NOT NULL
//);

namespace ParkingServis.Mapiranja
{
    public class VoziloMap : ClassMap<Vozilo>
    {
        public VoziloMap()
        {
            Table("Vozilo");

            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();

            Map(x => x.RegistarskiBroj, "RegistarskiBroj").Not.Nullable();
            Map(x => x.BrojSaobracajneDozvole, "BrojSaobracajneDozvole").Not.Nullable();
            Map(x => x.Proizvodjac, "Proizvodjac").Not.Nullable();
            Map(x => x.Model, "Model").Not.Nullable();


            //1:1
            HasOne(x => x.VoziloZaPretplatnu)
                    .PropertyRef(nameof(Karta.OdnosiNaVozilo))
                    //.Cascade.All();
                    .Cascade.None();

            HasOne(x => x.IskoriscenaKarta)
                    .PropertyRef(nameof(IskoriscenaKarta.ZaVozilo))
                    //.Cascade.All();
                    .Cascade.None();

            //HasMany(x => x.VoziloZaPretplatnu).Cascade.All().KeyColumn("RegistarskiBrojVozila");
            //HasMany(x => x.IskoriscenaKarta).Cascade.All().KeyColumn("RegistarskiBrojVozila");

            HasMany(x => x.ListaZakupa).Cascade.All().KeyColumn("RegistarskiBrojVozila");
        }
    }
}
