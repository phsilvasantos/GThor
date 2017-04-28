using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Veiculos;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers;
using GThorRepositorioNHibernate.Helpers.Ext;

namespace GThorNegocio.Negocios
{
    internal class NegocioVeiculo : INegocioVeiculo
    {
        private readonly IRepositorioVeiculo _repositorioVeiculo;

        public NegocioVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public void SalvarOuAtualizar(Veiculo veiculo)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioVeiculo.SetSession(instancia);
                _repositorioVeiculo.SalvarOuAtualizar(veiculo);
            }
        }

        public Veiculo CarregarPorId(int id)
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioVeiculo.SetSession(instancia);
                return _repositorioVeiculo.CarregarPorId(id);
            }
        }

        public IEnumerable<Veiculo> Lista()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioVeiculo.SetSession(instancia);
                return _repositorioVeiculo.Lista();
            }
        }

        public void Deletar(Veiculo veiculo)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioVeiculo.SetSession(instancia);
                _repositorioVeiculo.Deletar(veiculo);
            }
        }
    }
}