using System;
using ParkingServis.Entiteti;
using System.Text.Json.Serialization;

namespace ParkingServis
{
    #region Vozilo

    public class VoziloPregled
    {
        public string BrojSaobracajneDozvole { get; set; }
        public int Id { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string RegistarskiBroj { get; set; }

        public VoziloPregled(Vozilo vozilo)
        {
            Id = vozilo.Id;
            RegistarskiBroj = vozilo.RegistarskiBroj;
            BrojSaobracajneDozvole = vozilo.BrojSaobracajneDozvole;
            Proizvodjac = vozilo.Proizvodjac;
            Model = vozilo.Model;
        }

        public string[] GetListViewItem()
        {
            return new[]
            {
                Id.ToString(),
                RegistarskiBroj,
                BrojSaobracajneDozvole,
                Proizvodjac,
                Model
            };
        }
    }


    public class VoziloBasic
    {
        public string BrojSaobracajneDozvole { get; set; }
        public int Id { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string RegistarskiBroj { get; set; }

        public VoziloBasic(Vozilo vozilo)
        {
            Id = vozilo.Id;
            RegistarskiBroj = vozilo.RegistarskiBroj;
            BrojSaobracajneDozvole = vozilo.BrojSaobracajneDozvole;
            Proizvodjac = vozilo.Proizvodjac;
            Model = vozilo.Model;
        }


        [JsonConstructor]
        public VoziloBasic(int Id, string RegistarskiBroj, string BrojSaobracajneDozvole, string Model,
                    string Proizvodjac)
        {
            this.Id = Id;
            this.RegistarskiBroj = RegistarskiBroj;
            this.BrojSaobracajneDozvole = BrojSaobracajneDozvole;
            this.Model = Model;
            this.Proizvodjac = Proizvodjac;
        }

        public string[] GetListViewItem()
        {
            return new[]
            {
                Id.ToString(),
                RegistarskiBroj,
                BrojSaobracajneDozvole,
                Proizvodjac,
                Model
            };
        }
    }

    #endregion

    #region Parking

    public class ParkingPregled
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int BrojParkingMesta { get; set; }
        public DateTime OdVreme { get; set; }
        public DateTime DoVreme { get; set; }
        public string Zona { get; set; }
        public int? Spratovi { get; set; }
        public int? Nivoi { get; set; }

        public ParkingPregled(int id, string naziv, string Adresa, int BrojParkingMesta, DateTime OdVreme, DateTime DoVreme, string Zona, int? Spratovi, int? Nivoi)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Zona = Zona;
            this.Adresa = Adresa;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;
            this.BrojParkingMesta = BrojParkingMesta;
            this.Spratovi = Spratovi;
            this.Nivoi = Nivoi;
        }

        public ParkingPregled(Parking parking)
        {
            Id = parking.ID;
            Naziv = parking.Naziv;
            Zona = parking.Zona;
            Adresa = parking.Adresa;
            OdVreme = parking.OdVreme;
            DoVreme = parking.DoVreme;
            BrojParkingMesta = parking.BrojParkingMesta;
            Spratovi = parking.Spratovi;
            Nivoi = parking.Nivoi;
        }

        public string[] GetListViewItem()
        {
            int? broj;
            if (Spratovi != null)
            {
                broj = Spratovi;
            }
            else
            {
                broj = Nivoi;
            }

            return
            [
                Id.ToString(),
                Naziv,
                Zona,
                Adresa,
                OdVreme.ToString(),
                DoVreme.ToString(),
                BrojParkingMesta.ToString(),
                broj.ToString()
            ];
        }
    }

    public class ParkingBasic
    {
        public string Adresa { get; set; }
        public int BrojParkingMesta { get; set; }
        public DateTime DoVreme { get; set; }
        public int ID { get; set; }
        public string MontazniObjekat { get; set; }
        public string Naziv { get; set; }
        public int? Nivoi { get; set; }
        public DateTime OdVreme { get; set; }
        public string ParkingType { get; set; }
        public int? Spratovi { get; set; }
        public string Zona { get; set; }

        public ParkingBasic(Parking parking)
        {
            ID = parking.ID;
            MontazniObjekat = parking.MontazniObjekat;
            Zona = parking.Zona;
            Adresa = parking.Adresa;
            OdVreme = parking.OdVreme;
            DoVreme = parking.DoVreme;
            BrojParkingMesta = parking.BrojParkingMesta;
            Naziv = parking.Naziv;
            ParkingType = parking.ParkingType;
            Spratovi = parking.Spratovi;
            Nivoi = parking.Nivoi;
        }

        [JsonConstructor]
        public ParkingBasic(int ID, string MontazniObjekat, string Zona, string Adresa, DateTime OdVreme,
            DateTime DoVreme,
            int BrojParkingMesta, string Naziv, string ParkingType, int? Nivoi, int? Spratovi)
        {
            this.ID = ID;
            this.MontazniObjekat = MontazniObjekat;
            this.Zona = Zona;
            this.Adresa = Adresa;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;
            this.BrojParkingMesta = BrojParkingMesta;
            this.Naziv = Naziv;
            this.ParkingType = ParkingType;
            this.Nivoi = ParkingType == "Podzemna" ? Nivoi : null;
            this.Spratovi = ParkingType == "Nadzemna" ? Spratovi : null;
        }
    }

    #endregion

    #region ParkingMesto

    //       public virtual int ID { get; set; }
    //       public virtual EnumTrenutniStatus TrenutniStatus { get; set; }
    //       public virtual EnumParkingMestoType ParkingMestoType { get; set; }
    //       public virtual string NazivUlice { get; set; }
    //       public virtual string Zona { get; set; }
    //       public virtual int? RedniBroj { get; set; }
    //       public virtual int? Sprat { get; set; }

    public class ParkingMestoPregled
    {
        public int ID { get; set; }
        public string NazivUlice { get; set; }
        public string ParkingMestoType { get; set; }
        public int? RedniBroj { get; set; }
        public int? Sprat { get; set; }
        public string TrenutniStatus { get; set; }
        public string Zona { get; set; }

        [JsonConstructor]
        public ParkingMestoPregled(int id, string trenutniStatus, string parkingMestoType, string nazivUlice, string zona, int? redniBroj, int? sprat)
        {
            ID = id;
            TrenutniStatus = trenutniStatus;
            ParkingMestoType = parkingMestoType;
            NazivUlice = nazivUlice;
            Zona = zona;
            RedniBroj = redniBroj;
            Sprat = sprat;
        }

        public ParkingMestoPregled(ParkingMesto parkingMesto)
        {
            ID = parkingMesto.ID;
            TrenutniStatus = parkingMesto.TrenutniStatus;
            ParkingMestoType = parkingMesto.ParkingMestoType;
            NazivUlice = parkingMesto.NazivUlice;
            Zona = parkingMesto.Zona;
            RedniBroj = parkingMesto.RedniBroj;
            Sprat = parkingMesto.Sprat;
        }

        public string[] GetListViewItem()
        {
            return
            [
                ID.ToString(),
                TrenutniStatus,
                ParkingMestoType,
                NazivUlice,
                Zona,
                RedniBroj.ToString(),
                Sprat.ToString()
            ];
        }
    }


    public class ParkingMestoBasic
    {
        public int ID { get; set; }
        public string NazivUlice { get; set; }
        public string ParkingMestoType { get; set; }
        public Parking PripadaParkingu { get; set; }
        public int? RedniBroj { get; set; }
        public int? Sprat { get; set; }
        public string TrenutniStatus { get; set; }
        public string Zona { get; set; }

        public ParkingMestoBasic(ParkingMesto parking)
        {
            ID = parking.ID;
            TrenutniStatus = parking.TrenutniStatus;
            ParkingMestoType = parking.ParkingMestoType;
            NazivUlice = parking.NazivUlice;
            Zona = parking.Zona;
            RedniBroj = parking.RedniBroj;
            Sprat = parking.Sprat;
            PripadaParkingu = parking.PripadaParkingu;
        }

        [JsonConstructor]
        public ParkingMestoBasic(int ID, string trenutniStatus, string ParkingType, string NazivUlice, string Zona,
                    int? redniBroj, int? sprat, Parking parking)
        {
            this.ID = ID;
            TrenutniStatus = trenutniStatus;
            ParkingMestoType = ParkingType;
            this.NazivUlice = NazivUlice;
            this.Zona = Zona;
            RedniBroj = redniBroj;
            Sprat = sprat;
            PripadaParkingu = parking;
        }
    }

    #endregion

    #region Osoba

    public class OsobaPregled
    {
        public int ID { get; set; }
        public string Adresa { get; set; }
        public string BrojLicneKarte { get; set; }
        public string BrojVozackeDozvole { get; set; }
        public string JMBG { get; set; }
        public string LicnoIme { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime { get; set; }
        public string MestoIzdavanjaLicne { get; set; }
        public string Naziv { get; set; }
        public string PIB { get; set; }
        public string ZiviUZoni { get; set; }

        public OsobaPregled(Osoba osoba)
        {
            ID = osoba.ID;
            Adresa = osoba.Adresa;
            LicnoIme = osoba.LicnoIme;
            ImeRoditelja = osoba.ImeRoditelja;
            Prezime = osoba.Prezime;
            JMBG = osoba.JMBG;
            BrojLicneKarte = osoba.BrojLicneKarte;
            MestoIzdavanjaLicne = osoba.MestoIzdavanjaLicne;
            BrojVozackeDozvole = osoba.BrojVozackeDozvole;
            ZiviUZoni = osoba.ZiviUZoni;
            PIB = osoba.PIB;
            Naziv = osoba.Naziv;
        }

        public string[] GetListViewItem()
        {
            return new[]
            {
                ID.ToString(),
                Adresa,
                LicnoIme,
                ImeRoditelja,
                Prezime,
                JMBG,
                BrojLicneKarte,
                MestoIzdavanjaLicne,
                BrojVozackeDozvole,
                ZiviUZoni,
                PIB,
                Naziv
            };
        }
    }

    public class OsobaBasic
    {
        public int ID { get; set; }
        public string Adresa { get; set; }
        public string BrojLicneKarte { get; set; }
        public string BrojVozackeDozvole { get; set; }
        public string JMBG { get; set; }
        public string LicnoIme { get; set; }
        public string ImeRoditelja { get; set; }
        public string MestoIzdavanjaLicne { get; set; }
        public string Naziv { get; set; }
        public string PIB { get; set; }
        public string Prezime { get; set; }
        public string ZiviUZoni { get; set; }
        public string OsobaType { get; set; }

        public OsobaBasic(Osoba osoba)
        {
            ID = osoba.ID;
            Adresa = osoba.Adresa;
            LicnoIme = osoba.LicnoIme;
            ImeRoditelja = osoba.ImeRoditelja;
            Prezime = osoba.Prezime;
            JMBG = osoba.JMBG;
            BrojLicneKarte = osoba.BrojLicneKarte;
            MestoIzdavanjaLicne = osoba.MestoIzdavanjaLicne;
            BrojVozackeDozvole = osoba.BrojVozackeDozvole;
            ZiviUZoni = osoba.ZiviUZoni;
            PIB = osoba.PIB;
            Naziv = osoba.Naziv;
            OsobaType = osoba.OsobaType;
        }

        [JsonConstructor]
        public OsobaBasic(int ID, string Adresa, string LicnoIme, string imeRoditelja, string Prezime, string JMBG, string brojLicneKarte, string mestoIzdavanjaLicne, string brojVozackeDozvole, string ziviUZoni, string PIB, string Naziv, string osobaType)
        {
            this.ID = ID;
            this.Adresa = Adresa;
            this.LicnoIme = LicnoIme;
            this.ImeRoditelja = imeRoditelja;
            this.Prezime = Prezime;
            this.JMBG = JMBG;
            this.BrojLicneKarte = brojLicneKarte;
            this.MestoIzdavanjaLicne = mestoIzdavanjaLicne;
            this.BrojVozackeDozvole = brojVozackeDozvole;
            this.ZiviUZoni = ziviUZoni;
            this.PIB = PIB;
            this.Naziv = Naziv;
            this.OsobaType = osobaType;
        }
    }

    #endregion

    #region BrojeviTelefona


    public class BrojTelefonaPregled
    {
        public int Id { get; set; }
        public string Telefon { get; set; }

        [JsonConstructor]
        public BrojTelefonaPregled(int Id, string Telefon)
        {
            this.Id = Id;
            this.Telefon = Telefon;
        }

        public BrojTelefonaPregled(OsobaTelefon osobaFon)
        {
            Id = osobaFon.Id;
            Telefon = osobaFon.Telefon;
        }

        public string[] GetListViewItem()
        {
            return new[]
            {
                Id.ToString(),
                Telefon
            };
        }
    }

    public class BrojTelefonaBasic
    {
        public int Id { get; set; }
        public string Telefon { get; set; }
        public Osoba Osoba { get; set; }

        public BrojTelefonaBasic(OsobaTelefon osobaFon)
        {
            this.Id = osobaFon.Id;
            this.Telefon = osobaFon.Telefon;
            this.Osoba = osobaFon.Osoba;
        }

        [JsonConstructor]
        public BrojTelefonaBasic(int Id, string Telefon, Osoba osoba)
        {
            this.Id = Id;
            this.Telefon = Telefon;
            this.Osoba = osoba;
        }
    }

    #endregion

    #region Karta
    public class KartaPregled
    {
        public int SerijskiBroj { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? OdVreme { get; set; }
        public DateTime? DoVreme { get; set; }

        [JsonConstructor]
        public KartaPregled(int SerijskiBroj, DateTime? Datum, DateTime? OdVreme, DateTime? DoVreme)
        {
            this.SerijskiBroj = SerijskiBroj;
            this.Datum = Datum;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;
        }

        public KartaPregled(Karta karta)
        {
            this.SerijskiBroj = karta.SerijskiBroj;
            this.Datum = karta.Datum;
            this.OdVreme = karta.OdVreme;
            this.DoVreme = karta.DoVreme;
        }

        public string[] GetListViewItem()
        {
            return
            [
                SerijskiBroj.ToString(),
                Datum.ToString(),
                OdVreme.ToString(),
                DoVreme.ToString(),
            ];
        }
    }
    public class KartaBasic
    {
        public int SerijskiBroj { get; set; }
        public string KartaType { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? OdVreme { get; set; }
        public DateTime? DoVreme { get; set; }
        public Osoba ProdajaOsobi { get; set; }
        public Vozilo OdnosiSeNaVozilo { get; set; }

        public KartaBasic(Karta karta)
        {
            this.SerijskiBroj = karta.SerijskiBroj;
            this.KartaType = karta.KartaType;
            this.Datum = karta.Datum;
            this.OdVreme = karta.OdVreme;
            this.DoVreme = karta.DoVreme;
            this.ProdajaOsobi = karta.ProdajaOsobi;
            this.OdnosiSeNaVozilo = karta.OdnosiNaVozilo;
        }

        [JsonConstructor]
        public KartaBasic(int SerijskiBroj, string kartaType, DateTime? Datum, DateTime? OdVreme, DateTime? DoVreme, Osoba ProdajaOsobi, Vozilo OdnosiSeNaVozilo)
        {
            this.SerijskiBroj = SerijskiBroj;
            this.KartaType = kartaType;
            this.Datum = Datum;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;
            this.ProdajaOsobi = ProdajaOsobi;
            this.OdnosiSeNaVozilo = OdnosiSeNaVozilo;
        }
    }
    #endregion

    #region Iskoriscena Karta
    public class IskoriscenaKartaPregled
    {
        public int Id { get; set; }
        public DateTime? VremeIzvrseneKontrole { get; set; }
        public DateTime OdVreme { get; set; }
        public DateTime DoVreme { get; set; }

        [JsonConstructor]
        public IskoriscenaKartaPregled(int Id, DateTime? VremeIzvrseneKontrole, DateTime OdVreme, DateTime DoVreme)
        {
            this.Id = Id;
            this.VremeIzvrseneKontrole = VremeIzvrseneKontrole;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;
        }

        public IskoriscenaKartaPregled(IskoriscenaKarta iskoriscenakarta)
        {
            this.Id = iskoriscenakarta.Id;
            this.VremeIzvrseneKontrole = iskoriscenakarta.VremeIzvrseneKontrole;
            this.OdVreme = iskoriscenakarta.OdVreme;
            this.DoVreme = iskoriscenakarta.DoVreme;
        }

        public string[] GetListViewItem()
        {
            return
            [
                Id.ToString(),
                VremeIzvrseneKontrole.ToString(),
                OdVreme.ToString(),
                DoVreme.ToString(),
            ];
        }
    }

    public class IskoriscenaKartaBasic
    {
        public int Id { get; set; }
        public DateTime VremeIzvrseneKontrole { get; set; }
        public DateTime OdVreme { get; set; }
        public DateTime DoVreme { get; set; }

        public Vozilo ZaVozilo { get; set; }
        public ParkingMesto ZaParkingMesto { get; set; }
        public Karta KupljenaNaKioskuKarta { get; set; }

        public IskoriscenaKartaBasic(IskoriscenaKarta iskoriscenakarta)
        {
            this.Id = iskoriscenakarta.Id;
            this.VremeIzvrseneKontrole = iskoriscenakarta.VremeIzvrseneKontrole;
            this.OdVreme = iskoriscenakarta.OdVreme;
            this.DoVreme = iskoriscenakarta.DoVreme;

            this.ZaVozilo = iskoriscenakarta.ZaVozilo;
            this.ZaParkingMesto = iskoriscenakarta.ZaParkingMesto;
            this.KupljenaNaKioskuKarta = iskoriscenakarta.KupljenaNaKioskuKarta;
        }

        [JsonConstructor]
        public IskoriscenaKartaBasic(int Id, DateTime VremeIzvrseneKontrole, DateTime OdVreme, DateTime DoVreme, Vozilo ZaVozilo, ParkingMesto ZaParkingMesto, Karta KupljenaNaKioskuKarta)
        {
            this.Id = Id;
            this.VremeIzvrseneKontrole = VremeIzvrseneKontrole;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;

            this.ZaVozilo = ZaVozilo;
            this.ZaParkingMesto = ZaParkingMesto;
            this.KupljenaNaKioskuKarta = KupljenaNaKioskuKarta;
        }
    }

    #endregion

    #region Zakup

    public class ZakupPregled
    {
        public int Id { get; set; }
        public DateTime? OdVreme { get; set; }
        public DateTime? DoVreme { get; set; }
        public DateTime? DatumPotpisa { get; set; }
        public int OsobaId { get; set; }
        public int VoziloId { get; set; }
        public int ParkinMestoId { get; set; }


        [JsonConstructor]
        public ZakupPregled(int Id, DateTime? OdVreme, DateTime? DoVreme, DateTime? DatumPotpisa, int OsobaId, int VoziloId, int ParkinMestoId)
        {
            this.Id = Id;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;
            this.DatumPotpisa = DatumPotpisa;

            this.OsobaId = OsobaId;
            this.VoziloId = VoziloId;
            this.ParkinMestoId = ParkinMestoId;
        }

        public ZakupPregled(Zakup zakup)
        {
            this.Id = zakup.Id;
            this.OdVreme = zakup.OdVreme;
            this.DoVreme = zakup.DoVreme;
            this.DatumPotpisa = zakup.DatumPotpisa;

            this.OsobaId = zakup.Osoba.ID;
            this.VoziloId = zakup.Vozilo.Id;
            this.ParkinMestoId = zakup.ParkingMesto.ID;
        }

        public string[] GetListViewItem()
        {
            return
            [
                this.Id.ToString(),
                OdVreme.ToString(),
                DoVreme.ToString(),
                DatumPotpisa.ToString(),
                OsobaId.ToString(),
                VoziloId.ToString(),
                ParkinMestoId.ToString(),
            ];
        }
    }
    public class ZakupBasic
    {
        public int Id { get; set; }
        public DateTime OdVreme { get; set; }
        public DateTime DoVreme { get; set; }
        public DateTime DatumPotpisa { get; set; }
        public Osoba Osoba { get; set; }
        public Vozilo Vozilo { get; set; }
        public ParkingMesto ParkingMesto { get; set; }

        public ZakupBasic(Zakup zakup)
        {
            this.Id = zakup.Id;
            this.OdVreme = zakup.OdVreme;
            this.DoVreme = zakup.DoVreme;
            this.DatumPotpisa = zakup.DatumPotpisa;

            this.Osoba = zakup.Osoba;
            this.Vozilo = zakup.Vozilo;
            this.ParkingMesto = zakup.ParkingMesto;
        }

        [JsonConstructor]
        public ZakupBasic(int Id, DateTime OdVreme, DateTime DoVreme, DateTime DatumPotpisa, Osoba Osoba, Vozilo Vozilo, ParkingMesto ParkingMesto)
        {
            this.Id = Id;
            this.OdVreme = OdVreme;
            this.DoVreme = DoVreme;
            this.DatumPotpisa = DatumPotpisa;

            this.Osoba = Osoba;
            this.Vozilo = Vozilo;
            this.ParkingMesto = ParkingMesto;
        }
    }


    #endregion

    #region Zone
    public class ZonePregled
    {
        public int Id { get; set; }
        public string Zona { get; set; }

        public ZonePregled(KartaZone kartaZone)
        {
            Id = kartaZone.Id;
            Zona = kartaZone.Zona;
        }

        public string[] GetListViewItem()
        {
            return new[]
            {
                Id.ToString(),
                Zona
            };
        }
    }

    public class ZoneBasic
    {
        public int Id { get; set; }
        public string Zona { get; set; }
        public Karta Karta { get; set; }

        public ZoneBasic(KartaZone kartaZone)
        {
            this.Id = kartaZone.Id;
            this.Zona = kartaZone.Zona;
            this.Karta = kartaZone.Karta;
        }

        [JsonConstructor]
        public ZoneBasic(int Id, string Zona, Karta Karta)
        {
            this.Id = Id;
            this.Zona = Zona;
            this.Karta = Karta;
        }
    }
    #endregion
}