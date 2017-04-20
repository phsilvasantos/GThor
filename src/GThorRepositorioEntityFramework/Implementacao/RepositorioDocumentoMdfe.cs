using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    public class RepositorioDocumentoMdfe : RepositorioBase, IRepositorioDocumentoMdfe
    {
        public DocumentoMdfe CarregarPorId(int id)
        {
            return GThorContexto.DocumentoMdfe.FirstOrDefault(mdfe => mdfe.Id == id);
        }

        public IEnumerable<DocumentoMdfe> Lista()
        {
            return GThorContexto.DocumentoMdfe.ToList();
        }

        public void Dispose()
        {
            GThorContexto.Dispose();
        }

        public void SalvarOuAtualizar(DocumentoMdfe entity)
        {
            if (entity.Id == 0)
            {
                GThorContexto.DocumentoMdfe.Add(entity);
                return;
            }

            GThorContexto.DocumentoMdfe.Update(entity);
        }

        public void Deletar(DocumentoMdfe entity)
        {
            GThorContexto.DocumentoMdfe.Remove(entity);
        }
    }
}