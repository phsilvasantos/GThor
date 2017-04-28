using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Pessoas;
using GThorFrameworkDominio.Dto;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;
using NHibernate.Transform;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioPessoa : RepositorioBase, IRepositorioPessoa
    {
        public IEnumerable<PessoaDto> BuscarParaGridModel()
        {
            Pessoa pessoaAlias = null;
            PessoaDto resultado = null;

            var query = Sessao.QueryOver(() => pessoaAlias)
                .SelectList(list => list.Select(() => pessoaAlias.Id).WithAlias(() => resultado.Id)
                    .Select(() => pessoaAlias.Nome).WithAlias(() => resultado.Nome)
                    .Select(() => pessoaAlias.Cnpj).WithAlias(() => resultado.Cnpj)
                    .Select(() => pessoaAlias.Cpf).WithAlias(() => resultado.Cpf));

            query.TransformUsing(Transformers.AliasToBean<PessoaDto>());

            var lista = query.List<PessoaDto>();

            return lista;
        }

        public void SalvarOuAtualizar(Pessoa entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        public Pessoa CarregarPorId(int id)
        {
            return Sessao.Get<Pessoa>(id);
        }

        public IEnumerable<Pessoa> Lista()
        {
            return Sessao.QueryOver<Pessoa>().List<Pessoa>();
        }
    }
}