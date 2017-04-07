using System.Windows.Controls;

namespace ComercialFrameworkWpf.Views.DataGrid
{
    public class CabecalhoGridModel
    {
        public UserControl Cabecalho { get; }

        public CabecalhoGridModel(UserControl cabecalho)
        {
            Cabecalho = cabecalho;
        }
    }
}