using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace GThorFrameworkWpf.Models.DataGrid
{
    public interface IDataGridModel
    {
        UserControl PopupFiltro { get; set; }

        ObservableCollection<DataGridColumn> ColunasDataGrid { get; set; }

        void BuscarRegistros();

        string PesquisarTexto { get; set; }
        bool BotaoDeletar { get; set; }
        bool BotaoEditar { get; set; }
        bool BotaoOpcoes { get; set; }

        bool IniciaPesquisa(string pesquisarTexto);
        void AplicaPesquisa(string pesquisarTexto);
        void DuploClickDataGrid();
    }
}