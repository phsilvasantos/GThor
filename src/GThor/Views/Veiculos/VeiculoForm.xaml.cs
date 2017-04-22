using System.Windows;
using GThor.Models.Veiculos;
using GThorFrameworkComponentes.ComboBox;

namespace GThor.Views.Veiculos
{
    public partial class VeiculoForm
    {
        private readonly VeiculoFormModel _model;
        public VeiculoForm()
        {
            _model = new VeiculoFormModel();
            DataContext = _model;
            InitializeComponent();
        }

        private void ComboBoxUf_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            _model.UfDtoSelecionado = comboBoxUf?.UfSelecionado;
        }
    }
}
