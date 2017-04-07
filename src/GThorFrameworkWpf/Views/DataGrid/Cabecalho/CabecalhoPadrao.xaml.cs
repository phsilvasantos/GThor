using System.Windows.Input;
using GThorFrameworkWpf.Models.DataGrid;

namespace GThorFrameworkWpf.Views.DataGrid.Cabecalho
{
    /// <summary>
    /// Interaction logic for CabecalhoPadrao.xaml
    /// </summary>
    public partial class CabecalhoPadrao
    {
        private IDataGridModel Model => (IDataGridModel) DataContext;

        public CabecalhoPadrao()
        {
            InitializeComponent();
        }

        private void KeyDown_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            if (Model.IniciaPesquisa(Model.PesquisarTexto))
            {
                Model.AplicaPesquisa(Model.PesquisarTexto);
            }
        }
    }
}
