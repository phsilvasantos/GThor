using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Criadores;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    internal class NegocioDocumentoMdfe : INegocioDocumentoMdfe
    {
        private readonly IRepositorioDocumentoMdfe _repositorioDocumentoMdfe;

        public NegocioDocumentoMdfe(IRepositorioDocumentoMdfe repositorioDocumentoMdfe)
        {
            _repositorioDocumentoMdfe = repositorioDocumentoMdfe;
        }


        public void SalvarOuAtualizar(DocumentoMdfe documentoMdfe)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioDocumentoMdfe.SetGThorContexto(contexto);
                _repositorioDocumentoMdfe.SalvarOuAtualizar(documentoMdfe);
                _repositorioDocumentoMdfe.SalvarAlteracoes();
            }
        }

        public DocumentoMdfe CarregarPorId(int id)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioDocumentoMdfe.SetGThorContexto(contexto);

                return _repositorioDocumentoMdfe.CarregarPorId(id);
            }
        }

        public IEnumerable<DocumentoMdfe> Lista()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioDocumentoMdfe.SetGThorContexto(contexto);

                return _repositorioDocumentoMdfe.Lista();
            }
        }

        public void Deletar(DocumentoMdfe documentoMdfe)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioDocumentoMdfe.SetGThorContexto(contexto);
                _repositorioDocumentoMdfe.Deletar(documentoMdfe);
                _repositorioDocumentoMdfe.SalvarAlteracoes();
            }
        }
    }
}