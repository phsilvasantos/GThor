using System.Linq;
using System.Windows;
using GThor.Models.MdfeFiscal;

namespace GThor.Views.MdfeFiscal
{
    public partial class MdfeAdicionarDocumentoFiscal
    {
        private readonly MdfeAdicionarDocumentoFiscalModel _model;

        public MdfeAdicionarDocumentoFiscal(MdfeAdicionarDocumentoFiscalModel model)
        {
            _model = model;
            DataContext = _model;
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
            CbCidadeCarregamento.PickItemCidade += ComboBoxCidadeCarregamento_OnPickItem;
            CbCidadeCarregamento.PesquisaPorUf(_model.UfsPesquisa.ToArray());
        }

        private void ComboBoxCidadeCarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
