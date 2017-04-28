using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;

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
    }
}