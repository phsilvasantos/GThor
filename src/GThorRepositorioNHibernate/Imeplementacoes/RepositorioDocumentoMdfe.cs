using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dto.DocumentosMdfe;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;
using NHibernate.Transform;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioDocumentoMdfe : RepositorioBase, IRepositorioDocumentoMdfe
    {
        public DocumentoMdfe CarregarPorId(int id)
        {
            return Sessao.Get<DocumentoMdfe>(id);
        }

        public IEnumerable<DocumentoMdfe> Lista()
        {
            return Sessao.QueryOver<DocumentoMdfe>().List<DocumentoMdfe>();
        }

        public void SalvarOuAtualizar(DocumentoMdfe entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        public void Deletar(DocumentoMdfe entity)
        {
            Sessao.Delete(entity);
        }

        public IEnumerable<DocumentoMdfeComboBoxDto> BuscarParaComboBox()
        {
            DocumentoMdfe documentoMdfe = null;
            DocumentoMdfeComboBoxDto resposta = null;

            var query = Sessao.QueryOver(() => documentoMdfe)
                .SelectList(list => list.Select(() => documentoMdfe.Id).WithAlias(() => resposta.Id)
                    .Select(() => documentoMdfe.Descricao).WithAlias(() => resposta.Descricao));

            query.TransformUsing(Transformers.AliasToBean<DocumentoMdfeComboBoxDto>());

            var lista = query.List<DocumentoMdfeComboBoxDto>();

            return lista;
        }
    }
}