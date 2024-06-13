using ParkingServis.Entiteti;
using Prodavnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

using ISession = NHibernate.ISession;

namespace ParkingServis
{
    public class DataProvider
    {
        #region Vozilo

        public static Vozilo VratiVozilo(int idVozila)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Vozilo vozilo = session.Get<Vozilo>(idVozila);

                if (vozilo == null)
                {
                    session.Close();
                    throw new Exception("Ne postoji vozilo sa takvim id-jem");
                }

                session.Close();

                return vozilo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<VoziloPregled> VratiSvaVozila()
        {
            List<VoziloPregled> vozila = new List<VoziloPregled>();

            try
            {
                NHibernate.ISession session = DataLayer.GetSession();
                IEnumerable<Vozilo> svaVozila = from o in session.Query<Vozilo>()
                                                select o;

                foreach (Vozilo vozilo in svaVozila)
                {
                    vozila.Add(new VoziloPregled(vozilo));
                }

                session.Close();
                return vozila;
            }
            catch (Exception ec)
            {
                throw ec;
            }

            return vozila;

        }
        public static void DodajVozilo(VoziloBasic novoVozilo)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                // proveri dal postoji vozilo sa taj ID
                Vozilo postojiVozilo = session.Get<Vozilo>(novoVozilo.Id);
                if (postojiVozilo != null)
                {
                    session.Close();
                    throw new Exception("Vec postoji vozilo sa tim id-jem");
                }

                Vozilo vozilo = new Vozilo();
                ObjectCreator.Instance.ToVozilo(vozilo, novoVozilo);
                session.Save(vozilo);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void obrisiVozilo(int index)
        {
            try
            {
                NHibernate.ISession s = DataLayer.GetSession();
                Vozilo vozilo = s.Get<Vozilo>(index);

                if (vozilo == null)
                {

                    s.Close();
                    throw new Exception("Ne postoji vozilo sa tim id-jem");
                }

                s.Delete(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw ec;
            }
        }
        public static void AzurirajVozilo(VoziloBasic novoVozilo)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Vozilo vozilo = session.Load<Vozilo>(novoVozilo.Id);
                if (vozilo == null)
                {
                    session.Close();
                    throw new Exception("Ne postoji vozilo sa tim id-jem");
                }

                vozilo = ObjectCreator.Instance.ToVozilo(vozilo, novoVozilo);
                session.Update(vozilo);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region Parking
        public static Parking VratiParking(int idVozila)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Parking parking = session.Get<Parking>(idVozila);

                if (parking == null)
                {
                    session.Close();
                    throw new Exception("Parking sa tim id-jem ne postoji");
                }

                session.Close();
                return parking;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<ParkingPregled> VratiSveParkinge()
        {
            List<ParkingPregled> parkinzi = new List<ParkingPregled>();

            try
            {
                NHibernate.ISession session = DataLayer.GetSession();
                IEnumerable<Parking> sviParkinzi = from o in session.Query<Parking>()
                                                   select o;

                foreach (Parking parking in sviParkinzi)
                {
                    parkinzi.Add(new ParkingPregled(parking));
                }

                session.Close();
                return parkinzi;
            }
            catch (Exception ec)
            {
                throw ec;
            }

            return parkinzi;

        }

        public static void ObrisiParking(int index)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();
                Parking parking = session.Get<Parking>(index);

                if (parking == null)
                {
                    session.Close();
                    throw new Exception("Ne postoji parking sa tim id-jem");
                }

                session.Delete(parking);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DodajParking(ParkingBasic noviParking)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                // proveri dal postoji parking sa taj ID
                Parking postojiParking = session.Get<Parking>(noviParking.ID);
                if (postojiParking != null)
                {
                    throw new Exception("Ne postoji takav parking");
                    session.Close();
                    return;
                }

                Parking parking;
                if (noviParking.ParkingType == "Podzemna")
                {
                    parking = new Podzemna();
                }
                else if (noviParking.ParkingType == "Nadzemna")
                {
                    parking = new Nadzemna();
                }
                else
                {
                    session.Close();
                    throw new Exception("Dozvoljeni tipovi parking mesta su su Podzemna ili Nadzemna");
                }

                ObjectCreator.Instance.ToParking(parking, noviParking);
                session.Save(parking);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void AzurirajParking(ParkingBasic noviParking)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Parking parking = session.Load<Parking>(noviParking.ID);
                if (parking == null)
                {
                    session.Close();
                    throw new Exception("Parking sa tim id-jem ne postoji");
                }

                parking = ObjectCreator.Instance.ToParking(parking, noviParking);
                session.Update(parking);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region ParkingMesto


        public static ParkingMesto VratiParkingMesto(int idParkingMesta)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                ParkingMesto parkingMesto = session.Get<ParkingMesto>(idParkingMesta);

                if (parkingMesto == null)
                {
                    session.Close();
                    throw new Exception("Parking mesto sa tim id-jem ne postoji");
                }

                session.Close();
                return parkingMesto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<ParkingMestoPregled> VratiSvaParkingMesta()
        {
            List<ParkingMestoPregled> parkingMesta = new List<ParkingMestoPregled>();

            try
            {
                ISession session = DataLayer.GetSession();
                IEnumerable<ParkingMesto> sviParkingzi = from o in session.Query<ParkingMesto>()
                                                         select o;

                foreach (ParkingMesto p in sviParkingzi)
                {
                    parkingMesta.Add(new ParkingMestoPregled(p));
                }

                return parkingMesta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<ParkingMestoPregled> VratiParkingMesta(int idParkinga)
        {
            List<ParkingMestoPregled> parkingMesta = new List<ParkingMestoPregled>();

            try
            {
                ISession session = DataLayer.GetSession();
                List<ParkingMesto> sviParkingzi =
                    (from o in session.Query<ParkingMesto>()
                     where o.PripadaParkingu.ID == idParkinga
                     select o).ToList();

                foreach (ParkingMesto p in sviParkingzi)
                {
                    parkingMesta.Add(new ParkingMestoPregled(p));
                }

                return parkingMesta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ObrisiParkingMesto(int index)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();
                ParkingMesto parkingMesto = session.Get<ParkingMesto>(index);

                if (parkingMesto == null)
                {
                    session.Close();
                    throw new Exception("Parking mesto sa tim id-jem ne postoji");
                }

                session.Delete(parkingMesto);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DodajParkingMesto(ParkingMestoBasic novoParkingMesto)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                // proveri dal postoji parking sa taj ID
                ParkingMesto postojiParkingMesto = session.Get<ParkingMesto>(novoParkingMesto.ID);
                if (postojiParkingMesto != null)
                {
                    session.Close();
                    throw new Exception("Parking mesto sa tim id-jem vec postoji");
                }

                ParkingMesto parkingMesto;
                if (novoParkingMesto.ParkingMestoType == "NaUlici")
                {
                    parkingMesto = new NaUlici();
                }
                else if (novoParkingMesto.ParkingMestoType == "JavnoParkingMesto")
                {
                    parkingMesto = new JavnoParkingMesto();
                }
                else
                {
                    throw new Exception("Tip parking mesta moze biti NaUlici ili JavnoParkingMesto");
                }

                ObjectCreator.Instance.ToParkingMesto(parkingMesto, novoParkingMesto);
                session.Save(parkingMesto);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void AzurirajParkingMesto(ParkingMestoBasic novoParkingMesto)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                ParkingMesto parkingMesto = session.Load<ParkingMesto>(novoParkingMesto.ID);
                if (parkingMesto == null)
                {
                    session.Close();
                    throw new Exception("Parking mesto sa tim id-jem ne postoji");
                }

                parkingMesto = ObjectCreator.Instance.ToParkingMesto(parkingMesto, novoParkingMesto);
                session.Update(parkingMesto);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region Osobe

        public static Osoba VratiOsobu(int index)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba osoba = session.Get<Osoba>(index);
                if (osoba == null)
                {
                    session.Close();
                    throw new Exception("Osoba sa tim id-jem ne postoji");
                }


                session.Close();
                return osoba;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static List<OsobaPregled> VratiOsobe()
        {
            List<OsobaPregled> osobeList = new List<OsobaPregled>();

            try
            {
                ISession session = DataLayer.GetSession();
                IEnumerable<Osoba> sveOsobe = from o in session.Query<Osoba>()
                                              select o;

                foreach (Osoba osoba in sveOsobe)
                {
                    osobeList.Add(new OsobaPregled(osoba));
                }

                return osobeList;
            }
            catch (Exception e)
            {
                throw e;
                return osobeList;
            }
        }

        public static void ObrisiOsobu(int index)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();
                Osoba osoba = session.Get<Osoba>(index);

                if (osoba == null)
                {
                    session.Close();
                    throw new Exception("Osoba sa tim id-jem ne postoji");
                }

                session.Delete(osoba);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DodajOsobu(OsobaBasic novaOsoba)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Osoba postojiOsoba = session.Get<Osoba>(novaOsoba.ID);
                if (postojiOsoba != null)
                {
                    session.Close();
                    throw new Exception("Osoba sa tim id-jem ne postoji");
                }

                Osoba osoba;
                if (novaOsoba.OsobaType == "FizickoLice")
                {
                    osoba = new FizickoLice();
                }
                else if (novaOsoba.OsobaType == "PravnoLice")
                {
                    osoba = new PravnoLice();
                }
                else
                {
                    session.Close();
                    throw new Exception("Osoba moze biti FizickoLice ili PravnoLice");
                }

                ObjectCreator.Instance.ToOsoba(osoba, novaOsoba);
                session.Save(osoba);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void AzurirajOsobu(OsobaBasic novaOsoba)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Osoba osoba = session.Get<Osoba>(novaOsoba.ID);

                if (osoba == null)
                {
                    session.Close();
                    throw new Exception("Osoba sa tim id-jem ne postoji");
                }

                osoba = ObjectCreator.Instance.ToOsoba(osoba, novaOsoba);
                session.Update(osoba);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region BrojeviTelefona

        public static OsobaTelefon VratiTelefon(int index)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                OsobaTelefon telefon = session.Get<OsobaTelefon>(index);
                if (telefon == null)
                {
                    session.Close();
                    throw new Exception("Telefon sa tim id-jem ne postoji");
                }

                session.Close();
                return telefon;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static List<BrojTelefonaPregled> VratiBrojeve(int idOsobe)
        {
            List<BrojTelefonaPregled> brojeviTelefona = new List<BrojTelefonaPregled>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<OsobaTelefon> sveOsobeTelefoni = from ot in session.Query<OsobaTelefon>()
                                                             where ot.Osoba.ID == idOsobe
                                                             select ot;

                foreach (OsobaTelefon telefon in sveOsobeTelefoni)
                {
                    brojeviTelefona.Add(new BrojTelefonaPregled(telefon));
                }

                return brojeviTelefona;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DodajBrojTelefona(BrojTelefonaBasic noviBrTelefonBasic)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                OsobaTelefon postojiTelefon = session.Get<OsobaTelefon>(noviBrTelefonBasic.Id);

                if (postojiTelefon != null)
                {
                    session.Close();
                    throw new Exception("Telefon sa tim id-jem ne postoji");
                }

                OsobaTelefon telefon = new OsobaTelefon();

                ObjectCreator.Instance.ToTelefon(telefon, noviBrTelefonBasic);
                session.Save(telefon);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ObrisiBrojTelefona(int index)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                OsobaTelefon telefon = session.Get<OsobaTelefon>(index);

                if (telefon == null)
                {
                    session.Close();
                    throw new Exception("Broj telefona sa tim id-jem ne postoji");
                }

                session.Delete(telefon);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion

        #region Karte

        public static Karta VratiKartu(int index)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Karta karta = session.Get<Karta>(index);

                if (karta == null)
                {
                    session.Close();
                    throw new Exception("Karta sa tim id-jem ne postoji");
                }

                session.Close();
                return karta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<KartaPregled> VratiSveKarte()
        {
            List<KartaPregled> karteList = new List<KartaPregled>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<Karta> sveKarte = from ot in session.Query<Karta>()
                                              select ot;

                foreach (Karta karta in sveKarte)
                {
                    karteList.Add(new KartaPregled(karta));
                }

                return karteList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<KartaPregled> VratiKarte()
        {
            List<KartaPregled> karteList = new List<KartaPregled>();

            try
            {
                ISession session = DataLayer.GetSession();

                List<Pretplatna> sveKarte = session.Query<Karta>()
                    .OfType<Pretplatna>()
                    .ToList();

                foreach (Pretplatna karta in sveKarte)
                {
                    karteList.Add(new KartaPregled(karta));
                }

                return karteList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void AzurirajKartu(KartaBasic novaKarta)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Karta karta = session.Get<Karta>(novaKarta.SerijskiBroj);

                if (karta == null)
                {
                    session.Close();
                    throw new Exception("Karta sa tim id-jem ne postoji");
                }

                karta = ObjectCreator.Instance.ToKarta(karta, novaKarta);
                session.Update(karta);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static void DodajKartu(KartaBasic novaKarta)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Karta postojiKarta = session.Get<Karta>(novaKarta.SerijskiBroj);
                if (postojiKarta != null)
                {
                    session.Close();
                    throw new Exception("Karta sa tim id-jem vec postoji");
                }

                Karta karta = new Pretplatna();

                ObjectCreator.Instance.ToKarta(karta, novaKarta);
                session.Save(karta);

                session.Flush();
                session.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ObrisiKartu(int index)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();
                Karta karta = session.Get<Karta>(index);

                if (karta == null)
                {
                    session.Close();
                    throw new Exception("Karta sa tim id-jem ne postoji");
                }

                session.Delete(karta);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region IskorisceneKarte


        public static IskoriscenaKarta VratiIskoriscenuKartu(int index)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                IskoriscenaKarta karta = session.Get<IskoriscenaKarta>(index);
                if (karta == null)
                {
                    session.Close();
                    throw new Exception("Karta sa tim id-jem ne postoji");
                }

                session.Close();
                return karta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static List<IskoriscenaKartaPregled> VratiIskorisceneKarte()
        {
            List<IskoriscenaKartaPregled> ikarte = new List<IskoriscenaKartaPregled>();

            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                IEnumerable<IskoriscenaKarta> iskoriscenekarte = from o in session.Query<IskoriscenaKarta>()
                                                                 select o;

                foreach (IskoriscenaKarta iskoriscenakarta in iskoriscenekarte)
                {
                    ikarte.Add(new IskoriscenaKartaPregled(iskoriscenakarta));
                }

                return ikarte;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DodajIskoriscenuKartu(IskoriscenaKartaBasic novaIskoriscenaKarta)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                IskoriscenaKarta iskoriscenaKarta = session.Get<IskoriscenaKarta>(novaIskoriscenaKarta.Id);

                if (iskoriscenaKarta != null)
                {
                    session.Close();
                    throw new Exception("Karta sa tim id-jem vec postoji");
                }

                IskoriscenaKarta dodjIskoriscenaKarta = new IskoriscenaKarta();

                ObjectCreator.Instance.ToIskoriscenaKarta(dodjIskoriscenaKarta, novaIskoriscenaKarta);

                session.Save(dodjIskoriscenaKarta);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ObrisiIskoriscenuKartu(int index)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                IskoriscenaKarta iskoriscenaKarta = session.Get<IskoriscenaKarta>(index);

                if (iskoriscenaKarta == null)
                {
                    session.Close();
                    throw new Exception("Karta sa tim id-jem ne postojji");
                }

                session.Delete(iskoriscenaKarta);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Zakup

        public static Zakup VratiZakup(int index)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Zakup zakup = session.Get<Zakup>(index);
                if (zakup == null)
                {
                    session.Close();
                    throw new Exception("Zakup sa tim id-jem ne postoji");
                }

                session.Close();
                return zakup;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<ZakupPregled> VratiZakupe()
        {
            List<ZakupPregled> karteList = new List<ZakupPregled>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<Zakup> sviZakupi = from o in session.Query<Zakup>()
                                               select o;


                foreach (Zakup zakup in sviZakupi)
                {
                    karteList.Add(new ZakupPregled(zakup));
                }

                return karteList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static void DodajZakup(ZakupBasic noviZakup)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Zakup postojiZakup = session.Get<Zakup>(noviZakup.Id);

                if (postojiZakup != null)
                {
                    session.Close();
                    throw new Exception("Zakup sa tim id-jem vec postoji");
                }

                Zakup zakup = new Zakup();

                ObjectCreator.Instance.ToZakup(zakup, noviZakup);

                session.Save(zakup);
                session.Flush();

                //using (var transaction = session.BeginTransaction())
                //{
                //    session.Save(zakup);
                //    session.Flush();
                //    transaction.Commit();
                //}

                //using (var transaction = session.BeginTransaction())
                //{
                //    zakup.ParkingMesto.TrenutniStatus = "Zauzeto";
                //    session.SaveOrUpdate(zakup.ParkingMesto);
                //    session.Flush();
                //    transaction.Commit();
                //}

                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ObrisiZakup(int index)
        {
            try
            {
                NHibernate.ISession session = DataLayer.GetSession();

                Zakup zakup = session.Get<Zakup>(index);

                if (zakup == null)
                {
                    session.Close();
                    throw new Exception("Zakup sa tim id-jem ne postoji");
                }

                session.Delete(zakup);
                session.Flush();
                session.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Zone
        public static KartaZone VratiZonu(int index)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                KartaZone zone = session.Get<KartaZone>(index);

                if (zone == null)
                {
                    session.Close();
                    throw new Exception("Zona sa tim id-jem ne postoji");
                }

                session.Close();
                return zone;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static List<ZonePregled> VratiZone(int idZone)
        {
            List<ZonePregled> zone = new List<ZonePregled>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<KartaZone> svezone = from ot in session.Query<KartaZone>()
                                                 where ot.Karta.SerijskiBroj == idZone
                                                 select ot;

                foreach (KartaZone z in svezone)
                {
                    zone.Add(new ZonePregled(z));
                }

                return zone;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

    }
}
