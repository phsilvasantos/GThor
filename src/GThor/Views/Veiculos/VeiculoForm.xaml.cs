using System.Windows;
using GThor.Models.Veiculos;
using GThorFrameworkComponentes.ComboBox;
using GThorFrameworkDominio.Dominios.EstadosUf;
using ComboBoxUf = GThorFrameworkComponentes.ComboBox.EstadosUFs.ComboBoxUf;

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
            ComboBoxUf.UfSelecionado = ComboBoxUf.Default;

            if (_model.Veiculo.Id != 0)
            {
                ComboBoxUf.UfSelecionado = ComboBoxUf.Default;
            }
        }

        private void ComboBoxUf_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            _model.UfSelecionado = comboBoxUf?.UfSelecionado;
        }
    }
}
