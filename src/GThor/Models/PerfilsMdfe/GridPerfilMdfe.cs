using System.Linq;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dto;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;

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
    }
}