using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public Usuario CarregarPorId(int id)
        {
            return Sessao.Get<Usuario>(id);
        }

        public IEnumerable<Usuario> Lista()
        {
            return Sessao.QueryOver<Usuario>().List<Usuario>();
        }

        public void SalvarOuAtualizar(Usuario entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        public void Deletar(Usuario entity)
        {
            Sessao.Delete(entity);
        }
    }
}