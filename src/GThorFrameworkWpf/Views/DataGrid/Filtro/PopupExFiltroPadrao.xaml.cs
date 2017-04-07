using System.Windows.Input;
using GThorFrameworkWpf.Models.DataGrid;

namespace ComercialFrameworkWpf.Views.DataGrid.Filtro
{
    public partial class PopupExFiltroPadrao
    {
        private IDataGridModel GetModel => (IDataGridModel) DataContext;

        public PopupExFiltroPadrao()
        {
            InitializeComponent();
        }

        private void PesquisaTexto_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            if (GetModel.IniciaPesquisa(GetModel.PesquisarTexto))
            {
                GetModel.AplicaPesquisa(GetModel.PesquisarTexto);
            }
        }
    }
}
