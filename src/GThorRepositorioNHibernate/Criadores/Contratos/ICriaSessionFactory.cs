using NHibernate;

namespace GThorRepositorioNHibernate.Criadores.Contratos
{
    public interface ICriaSessionFactory
    {
        ISessionFactory CriaSessionFactoryNHibernate();
    }
}