using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorRepositorio.Contratos;
using NHibernate;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ISession _sessao;

        public RepositorioUsuario(ISession sessao)
        {
            _sessao = sessao;
        }

        public Usuario CarregarPorId(int id)
        {
            return _sessao.Get<Usuario>(id);
        }

        public IEnumerable<Usuario> Lista()
        {
            return _sessao.QueryOver<Usuario>().List<Usuario>();
        }

        public void SalvarOuAtualizar(Usuario entity)
        {
            _sessao.SaveOrUpdate(entity);
        }

        public void Deletar(Usuario entity)
        {
            _sessao.Delete(entity);
        }
    }
}