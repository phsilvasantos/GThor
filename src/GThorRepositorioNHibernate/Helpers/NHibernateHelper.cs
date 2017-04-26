using GThorRepositorioNHibernate.Criadores;
using GThorRepositorioNHibernate.Criadores.Contratos;
using GThorRepositorioNHibernate.Helpers.Contratos;
using NHibernate;

namespace GThorRepositorioNHibernate.Helpers
{
    public class NHibernateHelper : INHibernateHelper
    {
        private static INHibernateHelper _instancia;
        private readonly ISessionFactory _sessaoFabrica;
        private ITransaction _transacao;
        public ISession Sessao { get; private set; }

        public NHibernateHelper(ICriaSessionFactory criaSessionFactory)
        {
            _sessaoFabrica = criaSessionFactory.CriaSessionFactoryNHibernate();
        }

        public void Inicializa()
        {
            Sessao = _sessaoFabrica.OpenSession();
        }

        public void IniciaTransacao()
        {
            _transacao = Sessao.BeginTransaction();
        }

        public void SalvarAlteracoes()
        {
            try
            {
                if (_transacao != null && _transacao.IsActive)
                    _transacao.Commit();
            }
            catch
            {
                if (_transacao != null && _transacao.IsActive)
                    _transacao.Rollback();

                throw;
            }
            finally
            {
                Sessao.Dispose();
                _transacao = null;
            }
        }

        public static INHibernateHelper Instancia()
        {
            if(_instancia == null)
                _instancia = new NHibernateHelper(new CriaSessionFactoryPostgreSql());

            _instancia.Inicializa();

            return _instancia;
        }

        public static INHibernateHelper InstanciaComTransacao()
        {
            var iNhibernateHelper = Instancia();
            iNhibernateHelper.IniciaTransacao();

            return iNhibernateHelper;
        }

        public void Dispose()
        {
            SalvarAlteracoes();
        }
    }
}