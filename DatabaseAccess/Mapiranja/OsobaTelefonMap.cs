using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE OsobaTelefon (
//    IDOsobe NUMBER,
//    Telefon NVARCHAR2(30) UNIQUE,
//    CONSTRAINT PK_OsobaTelefon PRIMARY KEY(IDOsobe, Telefon),
//    FOREIGN KEY (IDOsobe) REFERENCES Osoba(ID)
//);

namespace ParkingServis.Mapiranja
{
    public class OsobaTelefonMap : ClassMap<OsobaTelefon>
    {
        public OsobaTelefonMap()
        {
            Table("OsobaTelefon");
            Id(x => x.Id, "ID").GeneratedBy.Assigned();

            Map(x => x.Telefon, "Telefon");

            References(x => x.Osoba).Column("IDOsobe").Not.Nullable().LazyLoad();
        }
    }
}
