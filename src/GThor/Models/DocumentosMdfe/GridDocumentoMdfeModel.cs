using System.Linq;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Negocios;

namespace GThor.Models.DocumentosMdfe
{
    public class GridDocumentoMdfeModel : DataGridPadraoModel<DocumentoMdfe>
    {
        private readonly NegocioDocumentoMdfe _negocioDocumentoMdfe;

        public GridDocumentoMdfeModel(NegocioDocumentoMdfe negocioDocumentoMdfe)
        {
            _negocioDocumentoMdfe = negocioDocumentoMdfe;
        }

        public override void BuscarRegistros()
        {
            Cache = _negocioDocumentoMdfe.Lista();
            PreencherLista(Cache);
        }

        public override void AplicaPesquisa(string pesquisarTexto)
        {
            if (pesquisarTexto.IsNotNullOrEmpty())
            {
                var lista = Cache.Where(docMdfe => docMdfe.Descricao.Contains(pesquisarTexto)).ToList();
                PreencherLista(lista);
                return;
            }

            PreencherLista(Cache.ToList());
        }

        public override void CriarColunas()
        {
            DocumentoMdfe documentoMdfe = null;
            AdicionarDataGridColumn(() => documentoMdfe.Id, 40);
            AdicionarDataGridColumn(() => documentoMdfe.AmbienteSefaz, 150);
            AdicionarDataGridColumn(() => documentoMdfe.Serie, 80);
            AdicionarDataGridColumn(() => documentoMdfe.UltimoNumeroUsado, 170);
            AdicionarDataGridColumn(() => documentoMdfe.Descricao);
        }
    }
}