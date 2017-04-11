using System;
using NHibernate;

namespace GThorRepositorioNHibernate.Helpers.Contratos
{
    public interface INHibernateHelper : IDisposable
    {
        void IniciaTransacao();

        void SalvarAlteracoes();

        void Inicializa();

        ISession Sessao { get; }
    }
}