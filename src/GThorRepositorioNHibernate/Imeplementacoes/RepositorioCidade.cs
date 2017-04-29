using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioCidade : RepositorioBase, IRepositorioCidade
    {
        public Cidade CarregarPorId(int id)
        {
            return Sessao.Get<Cidade>(id);
        }

        public IEnumerable<Cidade> Lista()
        {
            var lista = Sessao.QueryOver<Cidade>().List<Cidade>();

            return lista;
        }
    }
}