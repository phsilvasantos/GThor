using System;
using System.Collections.Generic;
using System.Reflection;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorMigracaoBancoDados.Flags;
using GThorRepositorioNHibernate.Criadores.Contratos;
using GThorRepositorioNHibernate.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace GThorRepositorioNHibernate.Criadores
{
    public class CriaSessionFactory : ICriaSessionFactory
    {
        private BancoDeDados _bancoDeDados;

        public ISessionFactory CriaSessionFactoryNHibernate()
        {
            _bancoDeDados = BancoDeDados.MySql;

            var cfg = new Configuration();


            if (_bancoDeDados == BancoDeDados.Postgresql)
                cfg.SetNamingStrategy(new PostgreSqlNamingStrategy());


            var assembly = Assembly.GetAssembly(GetType());

            var mappingClass = ObterMapemanetoDeClasses();

            cfg.AddProperties(ObterPropriedades());
            cfg.AddAssembly(assembly);
            cfg.AddAssembly(Assembly.GetAssembly(typeof(Usuario)));
            cfg.AddDeserializedMapping(mappingClass, assembly.GetName().Name);

            var iSessionFactory = cfg.BuildSessionFactory();

            return iSessionFactory;
        }

        private HbmMapping ObterMapemanetoDeClasses()
        {
            var mapper = new ModelMapper();

            mapper.AddMappings(Assembly.GetAssembly(GetType()).GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            return mapping;
        }

        private IDictionary<string, string> ObterPropriedades()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var property = new Dictionary<string, string>();

            property.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");

            switch (_bancoDeDados)
            {
                case BancoDeDados.Postgresql:
                case BancoDeDados.MySql:
                    property.Add("connection.isolation", "ReadUncommitted");
                    break;
                case BancoDeDados.Sqlite:

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            property.Add("dialect", _bancoDeDados.GetStringDialectNHibernate());
            property.Add("connection.driver_class", _bancoDeDados.GetStringDriverNHibernate());
            property.Add("connection.connection_string", _bancoDeDados.GetStringConexao());
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