using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorRepositorio.Contratos;
using NHibernate;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public ISession Sessao { get; set; }

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