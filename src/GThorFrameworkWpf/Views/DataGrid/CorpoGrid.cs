using System.Windows.Controls;

namespace ComercialFrameworkWpf.Views.DataGrid
{
    public class CorpoGridModel
    {
        public UserControl Cropo { get; }

        public CorpoGridModel(UserControl cropo)
        {
            Cropo = cropo;
        }
    }
}