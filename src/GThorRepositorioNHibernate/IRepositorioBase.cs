using NHibernate;

namespace GThorRepositorioNHibernate
{
    public interface IRepositorioBase
    {
        ISession Sessao { get; set; }
    }
}