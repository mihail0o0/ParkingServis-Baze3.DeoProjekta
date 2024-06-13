using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE IskoriscenaKarta (
//    VremeIzvrseneKontrole TIMESTAMP,
//    SerijskiBroj NUMBER,
//    OdVreme TIMESTAMP NOT NULL,
//    DoVreme TIMESTAMP NOT NULL,
//    RegistarskiBrojVozila NVARCHAR2(7) NOT NULL,
//    IDParkingMesta NUMBER NOT NULL,
//    FOREIGN KEY (RegistarskiBrojVozila) REFERENCES Vozilo(RegistarskiBroj),
//    FOREIGN KEY (IDParkingMesta) REFERENCES ParkingMesto(ID),
//    FOREIGN KEY (SerijskiBroj) REFERENCES Karta(SerijskiBroj),
//    CONSTRAINT CheckVremeIskoriscene CHECK(DoVreme > OdVreme),
//    CONSTRAINT PK_IskoriscenaKarta PRIMARY KEY(VremeIzvrseneKontrole, SerijskiBroj)
//);

namespace ParkingServis.Mapiranja
{
    public class IskoriscenaKartaMap : ClassMap<IskoriscenaKarta>
    {
        public IskoriscenaKartaMap()
        {
            Table("IskoriscenaKarta");
            Id(x => x.Id, "ID").GeneratedBy.Assigned();

            Map(x => x.OdVreme, "OdVreme").Not.Nullable();
            Map(x => x.DoVreme, "DoVreme").Not.Nullable();

            References(x => x.KupljenaNaKioskuKarta, "SerijskiBroj").LazyLoad();
            References(x => x.ZaVozilo, "RegistarskiBrojVozila").LazyLoad();
            References(x => x.ZaParkingMesto, "IDParkingMesta").LazyLoad();

            //References(x => x.OdnosiNaVozilo).Nullable().Column("OdnosiNaVozilo").LazyLoad();

            //CheckConstraint("DoVreme > OdVreme");
        }
    }
}
