using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GThor.Models.MdfeFiscal;
using GThor.Models.MdfeFiscal.Abas;
using GThor.Models.MdfeFiscal.EntidadesModels;
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

        private void AdicionaNFe(object sender, RoutedEventArgs e)
        {

            var model = new MdfeAdicionarDocumentoFiscalNFeModel {UfsPesquisa = Model.UfsPesquisa};


            model.AdicionarDocumentoNFeHandler += AdicionarDocumentoNFeAction;

            var shildwindow = new MdfeAdicionarDocumentoFiscalNFe(model);

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MetroWindow;

            window.ShowChildWindowAsync(shildwindow, ChildWindowManager.OverlayFillBehavior.FullWindow);


        }

        private void AdicionarDocumentoNFeAction(object sender, IDocumentoModel e)
        {
            Model.AdicionarDocumento(e);
        }

        private void MdfeDocumentosControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
