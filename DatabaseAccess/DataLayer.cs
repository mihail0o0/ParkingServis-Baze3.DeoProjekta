using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ParkingServis.Mapiranja;
using ParkingServis.Entiteti;

namespace Prodavnica
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();


        //funkcija na zahtev otvara sesiju
        public static NHibernate.ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory? CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True;User Id=S18837;Password=S18837"));

                return Fluently.Configure()
                    .Database(cfg.ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<KartaMap>())
                    .BuildSessionFactory();
            }
            catch (Exception ec)
            {
                // System.Windows.Forms.MessageBox.Show(ec.InnerException.ToString());
                // System.Windows.Forms.MessageBox.Show(ec.Message);
                System.Console.WriteLine(ec.Message);
                return null;
            }

        }
    }
}
