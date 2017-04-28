using System;
using System.Linq;
using GThor.Views.DocumentosMdfe;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;
using GThorNegocio.Criadores;

namespace GThor.Models.DocumentosMdfe
{
    public class GridDocumentoMdfeModel : DataGridPadraoModel<DocumentoMdfe>
    {
        private readonly INegocioDocumentoMdfe _negocioDocumentoMdfe;

        public GridDocumentoMdfeModel(INegocioDocumentoMdfe negocioDocumentoMdfe)
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


        public override void NovoRegistroAction(object obj)
        {
            var model = new DocumentoMdfeFormModel(NegocioCriador.CriaNegocioDocumentoMdfe())
            {
                DocumentoMdfe = new DocumentoMdfe()
            };

            model.AtualizarListaHandler += AtualizaLista;

            var formulario = new DocumentoMdfeForm(model);

            formulario.ShowDialog();
        }

        public override void DuploClickDataGrid()
        {
            var model = new DocumentoMdfeFormModel(NegocioCriador.CriaNegocioDocumentoMdfe())
            {
                DocumentoMdfe = EntidadeSelecionada
            };

            model.AtualizarListaHandler += AtualizaLista;

            var formulario = new DocumentoMdfeForm(model);

            formulario.ShowDialog();
        }

        protected override void DeletarRegistroSelecionado()
        {
            _negocioDocumentoMdfe.Deletar(EntidadeSelecionada);
        }

        private void AtualizaLista(object sender, EventArgs e)
        {
            IniciaPesquisa(PesquisarTexto);
        }
    }
}