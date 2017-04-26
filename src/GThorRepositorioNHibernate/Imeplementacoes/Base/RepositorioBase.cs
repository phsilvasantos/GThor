using NHibernate;

namespace GThorRepositorioNHibernate.Imeplementacoes.Base
{
    public class RepositorioBase : IRepositorioBase
    {
        public ISession Sessao { get; set; }
    }
}