using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers;
using GThorRepositorioNHibernate.Helpers.Ext;

namespace GThorNegocio.Negocios
{
    internal class NegocioCidade : INegocioCidade
    {
        private readonly IRepositorioCidade _repositorioCidade;

        public NegocioCidade(IRepositorioCidade repositorioCidade)
        {
            _repositorioCidade = repositorioCidade;
        }

        public Cidade CarregarPorId(int id)
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioCidade.SetNHibernateHelper(instancia);
                return _repositorioCidade.CarregarPorId(id);
            }
        }

        public IEnumerable<Cidade> Lista()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioCidade.SetNHibernateHelper(instancia);
                return _repositorioCidade.Lista();
            }
        }
    }
}