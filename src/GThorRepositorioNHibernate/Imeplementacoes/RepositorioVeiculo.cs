using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Veiculos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioVeiculo : RepositorioBase, IRepositorioVeiculo
    {
        public Veiculo CarregarPorId(int id)
        {
            return Sessao.Get<Veiculo>(id);
        }

        public IEnumerable<Veiculo> Lista()
        {
            return Sessao.QueryOver<Veiculo>().List<Veiculo>();
        }

        public void SalvarOuAtualizar(Veiculo entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        public void Deletar(Veiculo entity)
        {
            Sessao.Delete(entity);
        }
    }
}