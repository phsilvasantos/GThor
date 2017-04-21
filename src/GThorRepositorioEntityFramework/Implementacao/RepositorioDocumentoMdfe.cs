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
            return GThorContexto.DocumentosMdfe.FirstOrDefault(mdfe => mdfe.Id == id);
        }

        public IEnumerable<DocumentoMdfe> Lista()
        {
            return GThorContexto.DocumentosMdfe.ToList();
        }

        public void Dispose()
        {
            GThorContexto.Dispose();
        }

        public void SalvarOuAtualizar(DocumentoMdfe entity)
        {
            if (entity.Id == 0)
            {
                GThorContexto.DocumentosMdfe.Add(entity);
                return;
            }

            GThorContexto.DocumentosMdfe.Update(entity);
        }

        public void Deletar(DocumentoMdfe entity)
        {
            GThorContexto.DocumentosMdfe.Remove(entity);
        }
    }
}