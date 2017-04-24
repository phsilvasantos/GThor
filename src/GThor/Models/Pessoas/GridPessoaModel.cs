using System.Linq;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dto;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;

namespace GThor.Models.Pessoas
{
    public class GridPessoaModel : DataGridPadraoModel<PessoaDto>
    {
        private readonly INegocioPessoa _negocioPessoa;

        public GridPessoaModel(INegocioPessoa negocioPessoa)
        {
            _negocioPessoa = negocioPessoa;
        }

        public override void BuscarRegistros()
        {
            Cache = _negocioPessoa.BuscarParaGridModel();
            PreencherLista(Cache);
        }

        public override void AplicaPesquisa(string pesquisarTexto)
        {
            if (pesquisarTexto.IsNotNullOrEmpty())
            {
                var listaFiltrada = Cache.Where(p => p.Id.ToString() == pesquisarTexto
                                                     || p.Nome.Contains(pesquisarTexto)
                                                     || p.DocumentoUnico == pesquisarTexto);

                PreencherLista(listaFiltrada);
                return;
            }

            PreencherLista(Cache.ToList());
        }

        public override void CriarColunas()
        {
            PessoaDto pessoaDto = null;
            AdicionarDataGridColumn(() => pessoaDto.Id);
            AdicionarDataGridColumn(() => pessoaDto.Nome);
            AdicionarDataGridColumn(() => pessoaDto.DocumentoUnico);
        }
    }
}