using System.Reflection;
using GThorRepositorioNHibernate.Criadores.Contratos;
using NHibernate;
using NHibernate.Cfg;

namespace GThorRepositorioNHibernate.Criadores
{
    public class CriaSessionFactorySqlite : ICriaSessionFactory
    {
        public ISessionFactory CriaSessionFactoryNHibernate()
        { 
            var cfg = new Configuration();

            var assembly = Assembly.GetAssembly(GetType());

            cfg.Configure(assembly, "GThorRepositorioNHibernate.hibernate.cfg.xml");

            var iSessionFactory = cfg.BuildSessionFactory();

            return iSessionFactory;
        }
    }
}