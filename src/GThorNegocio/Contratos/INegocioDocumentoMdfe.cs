using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;

namespace GThorNegocio.Contratos
{
    public interface INegocioDocumentoMdfe
    {
        void SalvarOuAtualizar(DocumentoMdfe documentoMdfe);
        IEnumerable<DocumentoMdfe> Lista();
        void Deletar(DocumentoMdfe documentoMdfe);
    }
}