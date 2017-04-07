using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GThorFrameworkWpf.Models.DataGrid;

namespace ComercialFrameworkWpf.Views.DataGrid.Corpo
{
    public partial class CorpoPadrao
    {
        private IDataGridModel Model => (IDataGridModel) DataContext;

        public CorpoPadrao()
        {
            InitializeComponent();
        }

        private void DoubleClickDataGridRow(object sender, MouseButtonEventArgs e)
        {
            Model.DuploClickDataGrid();
        }

        private void CorpoPadrao_OnLoaded(object sender, RoutedEventArgs e)
        {
            MontarColunasDataGrid();
        }

        private void MontarColunasDataGrid()
        {
            var starWidth = new DataGridLength(1.0, DataGridLengthUnitType.Star);

            if (!Model.BotaoOpcoes)
                DataGrid.Columns.RemoveAt(0);

            if (!Model.BotaoEditar && !Model.BotaoOpcoes)
                DataGrid.Columns.RemoveAt(0);

            if (!Model.BotaoEditar && Model.BotaoOpcoes)
                DataGrid.Columns.RemoveAt(1);

            if (!Model.BotaoDeletar && Model.BotaoOpcoes && Model.BotaoEditar)
                DataGrid.Columns.RemoveAt(2);

            if (!Model.BotaoDeletar && Model.BotaoOpcoes && !Model.BotaoEditar)
                DataGrid.Columns.RemoveAt(1);

            if (!Model.BotaoDeletar && !Model.BotaoOpcoes && Model.BotaoEditar)
                DataGrid.Columns.RemoveAt(1);

            if (!Model.BotaoDeletar && !Model.BotaoOpcoes && !Model.BotaoEditar)
                DataGrid.Columns.RemoveAt(0);

            foreach (var dataGridColumn in Model.ColunasDataGrid)
            {
                if (dataGridColumn.Width.IsAuto)
                    dataGridColumn.Width = starWidth;

                DataGrid.Columns.Add(dataGridColumn);
            }
        }
    }
}
