using System.Collections.Generic;
using System.Reflection;
using GThorRepositorioNHibernate.Criadores.Contratos;
using NHibernate;
using NHibernate.Cfg;

namespace GThorRepositorioNHibernate.Criadores
{
    public class CriaSessionFactoryPostgreSql : ICriaSessionFactory
    {
        public ISessionFactory CriaSessionFactoryNHibernate()
        { 
            var cfg = new Configuration();

            var assembly = Assembly.GetAssembly(GetType());

            cfg.AddProperties(ObterPropriedades());
            cfg.AddAssembly(assembly);
            var iSessionFactory = cfg.BuildSessionFactory();

            return iSessionFactory;
        }

        private IDictionary<string, string> ObterPropriedades()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var property = new Dictionary<string, string>();

            property.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            property.Add("connection.isolation", "ReadUncommitted");
            property.Add("dialect", "NHibernate.Dialect.PostgreSQL82Dialect");
            property.Add("connection.driver_class", "NHibernate.Driver.NpgsqlDriver");
            property.Add("connection.connection_string", "Server=localhost;Port=5432;User ID=postgres;Password=root;Database=gthor");
            property.Add("cache.use_second_level_cache", "false");

#if DEBUG
            property.Add("show_sql", "true");
            property.Add("format_sql", "true");
            property.Add("adonet.batch_size", "0");
#endif

            return property;
        }
    }
}