using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;
using GThorFrameworkDominio.Dto;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;
using NHibernate.Transform;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioPerfilMdfe : RepositorioBase, IRepositorioPerfilMdfe
    {
        public PerfilMdfe CarregarPorId(int id)
        {
            return Sessao.Get<PerfilMdfe>(id);
        }

        public IEnumerable<PerfilMdfe> Lista()
        {
            return Sessao.QueryOver<PerfilMdfe>().List<PerfilMdfe>();
        }

        public void SalvarOuAtualizar(PerfilMdfe entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        public void Deletar(PerfilMdfe entity)
        {
            Sessao.Delete(entity);
        }

        public IEnumerable<PerfilMdfeDto> BuscarParaGridModel()
        {
            PerfilMdfe perfilMdfeAlias = null;
            DocumentoMdfe documentoMdfeAlias = null;

            PerfilMdfeDto resultado = null;

            var queryOver = Sessao.QueryOver(() => perfilMdfeAlias)
                .JoinAlias(() => perfilMdfeAlias.DocumentoMdfe, () => documentoMdfeAlias)
                .SelectList(list => list
                    .Select(() => perfilMdfeAlias.Id).WithAlias(() => resultado.Id)
                    .Select(() => perfilMdfeAlias.Descricao).WithAlias(() => resultado.Descricao)
                    .Select(() => documentoMdfeAlias.AmbienteSefaz).WithAlias(() => resultado.AmbienteSefaz)
                    .Select(() => documentoMdfeAlias.UltimoNumeroUsado).WithAlias(() => resultado.UltimoNumeroEmitido));

            queryOver.TransformUsing(Transformers.AliasToBean<PerfilMdfeDto>());

            var lista = queryOver.List<PerfilMdfeDto>();

            return lista;

        }
    }
}