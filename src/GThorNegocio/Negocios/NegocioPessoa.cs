using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Pessoas;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers;
using GThorRepositorioNHibernate.Helpers.Ext;

namespace GThorNegocio.Negocios
{
    internal class NegocioPessoa : INegocioPessoa
    {
        private readonly IRepositorioPessoa _repositorioPessoa;

        public NegocioPessoa(IRepositorioPessoa repositorioPessoa)
        {
            _repositorioPessoa = repositorioPessoa;
        }

        public IEnumerable<PessoaDto> BuscarParaGridModel()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioPessoa.SetSession(instancia);
                return _repositorioPessoa.BuscarParaGridModel();
            }
        }

        public void SalvarOuAtualizar(Pessoa entity)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioPessoa.SetSession(instancia);
                _repositorioPessoa.SalvarOuAtualizar(entity);
            }
        }

        public Pessoa CarregarPorId(int id)
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioPessoa.SetSession(instancia);
                return _repositorioPessoa.CarregarPorId(id);
            }
        }

        public IEnumerable<Pessoa> Lista()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioPessoa.SetSession(instancia);
                return _repositorioPessoa.Lista();
            }
        }
    }
}