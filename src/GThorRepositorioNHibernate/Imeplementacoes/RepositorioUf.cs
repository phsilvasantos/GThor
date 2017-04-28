using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioUf : RepositorioBase, IRepositorioUf
    {
        public Uf CarregarPorId(int id)
        {
            return Sessao.Get<Uf>(id);
        }

        public IEnumerable<Uf> Lista()
        {
            return Sessao.QueryOver<Uf>().List<Uf>();
        }
    }
}