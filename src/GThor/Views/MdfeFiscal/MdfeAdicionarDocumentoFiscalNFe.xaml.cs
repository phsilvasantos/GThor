using System.Linq;
using System.Windows;
using GThor.Models.MdfeFiscal;
using GThorFrameworkComponentes.ComboBox.EstadosUFs;

namespace GThor.Views.MdfeFiscal
{
    public partial class MdfeAdicionarDocumentoFiscalNFe
    {
        private readonly MdfeAdicionarDocumentoFiscalNFeModel _nFeModel;

        public MdfeAdicionarDocumentoFiscalNFe(MdfeAdicionarDocumentoFiscalNFeModel nFeModel)
        {
            _nFeModel = nFeModel;
            DataContext = _nFeModel;
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
            CbCidadeCarregamento.PickItemCidade += ComboBoxCidadeCarregamento_OnPickItem;
            CbCidadeCarregamento.PesquisaPorUf(_nFeModel.UfsPesquisa.ToArray());
        }

        private void ComboBoxCidadeCarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxCidade = e.Source as ComboBoxCidade;
            _nFeModel.Cidade = comboBoxCidade?.CidadeSelecionado;
        }
    }
}
