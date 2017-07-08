using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.SimpleChildWindow;

namespace GThor.Views.MdfeFiscal
{
    public partial class MdfeDocumentosControl
    {
        public MdfeDocumentosControl()
        {
            InitializeComponent();
        }

        private void OnDoubleClickItem(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void OnClickDeletaItem(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var shildwindow = new MdfeAdicionarDocumentoFiscal();

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MetroWindow;

            window.ShowChildWindowAsync(shildwindow, ChildWindowManager.OverlayFillBehavior.FullWindow);


        }
    }
}
