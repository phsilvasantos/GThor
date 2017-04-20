using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;

namespace GThorNegocio.Negocios
{
    public class NegocioDocumentoMdfe : INegocioDocumentoMdfe
    {
        private readonly IRepositorioDocumentoMdfe _repositorioDocumentoMdfe;

        public NegocioDocumentoMdfe(IRepositorioDocumentoMdfe repositorioDocumentoMdfe)
        {
            _repositorioDocumentoMdfe = repositorioDocumentoMdfe;
        }


        public void SalvarOuAtualizar(DocumentoMdfe documentoMdfe)
        {
            _repositorioDocumentoMdfe.SalvarOuAtualizar(documentoMdfe);
        }

        public IEnumerable<DocumentoMdfe> Lista()
        {
            return _repositorioDocumentoMdfe.Lista();
        }

        public void Deletar(DocumentoMdfe documentoMdfe)
        {
            _repositorioDocumentoMdfe.Deletar(documentoMdfe);
        }
    }
}