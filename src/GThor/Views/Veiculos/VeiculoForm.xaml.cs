using System.Windows;
using GThor.Models.Veiculos;
using GThorFrameworkComponentes.ComboBox;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThor.Views.Veiculos
{
    public partial class VeiculoForm
    {
        private readonly VeiculoFormModel _model;
        public VeiculoForm(VeiculoFormModel model)
        {
            _model = model;
            DataContext = _model;
            InitializeComponent();

            InicializaComboBox();
        }

        private void InicializaComboBox()
        {
            ComboBoxUf.PickItem += ComboBoxUf_OnPickItem;
            ComboBoxUf.UfSelecionado = new Uf {Id = 1};

            if (_model.Veiculo.Id != 0)
            {
                ComboBoxUf.UfSelecionado = new Uf {Id = _model.Veiculo.UfId};
            }
        }

        private void ComboBoxUf_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            _model.UfSelecionado = comboBoxUf?.UfSelecionado;
        }
    }
}
