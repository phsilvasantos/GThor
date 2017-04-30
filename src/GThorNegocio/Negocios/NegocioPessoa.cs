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

                var pessoa = _repositorioPessoa.CarregarPorId(entity.Id);

                pessoa.CopiarPropriedades(entity);

                _repositorioPessoa.SalvarOuAtualizar(pessoa);
            }
        }

        public Pessoa CarregarPorId(int id)
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioPessoa.SetSession(instancia);

                var pessoa = _repositorioPessoa.CarregarPorId(id);

                if (pessoa.Transportadora == null)
                    pessoa.Transportadora = new Transportadora(pessoa, 0);

                if (pessoa.Condutor == null) 
                    pessoa.Condutor = new Condutor(pessoa, 0);

                return pessoa;
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