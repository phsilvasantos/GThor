using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Extensoes;

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
            using (var contexto = new GThorContexto())
            {
                _repositorioDocumentoMdfe.SetGThorContexto(contexto);
                _repositorioDocumentoMdfe.SalvarOuAtualizar(documentoMdfe);
                _repositorioDocumentoMdfe.SalvarAlteracoes();
            }
        }

        public IEnumerable<DocumentoMdfe> Lista()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioDocumentoMdfe.SetGThorContexto(contexto);

                return _repositorioDocumentoMdfe.Lista();
            }
        }

        public void Deletar(DocumentoMdfe documentoMdfe)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioDocumentoMdfe.SetGThorContexto(contexto);
                _repositorioDocumentoMdfe.Deletar(documentoMdfe);
                _repositorioDocumentoMdfe.SalvarAlteracoes();
            }
        }
    }
}