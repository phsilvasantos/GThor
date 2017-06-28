using System;
using System.Linq;
using GThor.Views.PerfilsMdfe;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;
using GThorFrameworkDominio.Dto;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;
using GThorNegocio.Criadores;

namespace GThor.Models.PerfilsMdfe
{
    public class GridPerfilMdfe : DataGridPadraoModel<PerfilMdfeDto>
    {
        private readonly INegocioPerfilMdfe _negocioPerfilMdfe;

        public GridPerfilMdfe(INegocioPerfilMdfe negocioPerfilMdfe)
        {
            _negocioPerfilMdfe = negocioPerfilMdfe;
        }

        public override void BuscarRegistros()
        {
            Cache = _negocioPerfilMdfe.BuscarParaGridModel();
            PreencherLista(Cache);
        }

        public override void AplicaPesquisa(string pesquisarTexto)
        {
            if (pesquisarTexto.IsNotNullOrEmpty())
            {
                var listaFiltrada = Cache.Where(p => p.Id.ToString() == pesquisarTexto
                                                     || p.Descricao.Contains(pesquisarTexto)
                                                     || p.UltimoNumeroEmitido.ToString() == pesquisarTexto).ToList();

                PreencherLista(listaFiltrada);
                return;
            }

            PreencherLista(Cache.ToList());
        }

        public override void CriarColunas()
        {
            PerfilMdfeDto perfilMdfeDto = null;

            AdicionarDataGridColumn(() => perfilMdfeDto.Id, 40);
            AdicionarDataGridColumn(() => perfilMdfeDto.Descricao);
            AdicionarDataGridColumn(() => perfilMdfeDto.AmbienteSefaz, 200);
            AdicionarDataGridColumn(() => perfilMdfeDto.UltimoNumeroEmitido, 200);
        }

        public override void NovoRegistroAction(object obj)
        {
            var model = new PerfilMdfeFormModel(NegocioCriador.CriaNegocioPerfilMdfe()) {PerfilMdfe = new PerfilMdfe()};

            model.AtualizarListaHandler += AtualizarLista;

            new PerfilMdfeForm(model).ShowDialog();
        }

        public override void DuploClickDataGrid()
        {
            var perfilBuscado = _negocioPerfilMdfe.CarregarPorId(EntidadeSelecionada.Id);

            var model = new PerfilMdfeFormModel(NegocioCriador.CriaNegocioPerfilMdfe()) { PerfilMdfe = perfilBuscado };

            model.AtualizarListaHandler += AtualizarLista;

            new PerfilMdfeForm(model).ShowDialog();
        }

        private void AtualizarLista(object sender, EventArgs e)
        {
            IniciaPesquisa(PesquisarTexto);
        }

        protected override void DeletarRegistroSelecionado()
        {
            _negocioPerfilMdfe.Deletar(_negocioPerfilMdfe.CarregarPorId(EntidadeSelecionada.Id));
        }
    }
}