using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GThor.Models.MdfeFiscal;
using GThor.Models.MdfeFiscal.Abas;
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

        private MdfeDocumentosModel Model => DataContext as MdfeDocumentosModel;

        private void OnDoubleClickItem(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void OnClickDeletaItem(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            var model = new MdfeAdicionarDocumentoFiscalModel {UfsPesquisa = Model.UfsPesquisa};


            var shildwindow = new MdfeAdicionarDocumentoFiscal(model);

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MetroWindow;

            window.ShowChildWindowAsync(shildwindow, ChildWindowManager.OverlayFillBehavior.FullWindow);


        }

        private void MdfeDocumentosControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
