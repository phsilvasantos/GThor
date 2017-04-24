using GThorFrameworkDominio.Dto;
using GThorFrameworkWpf.Models.DataGrid;

namespace GThor.Models.Pessoas
{
    public class GridPessoaModel : DataGridPadraoModel<PessoaDto>
    {
        public override void BuscarRegistros()
        {
            throw new System.NotImplementedException();
        }

        public override void AplicaPesquisa(string pesquisarTexto)
        {
            throw new System.NotImplementedException();
        }

        public override void CriarColunas()
        {
            throw new System.NotImplementedException();
        }
    }
}