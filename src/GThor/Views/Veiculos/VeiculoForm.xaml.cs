using System.Windows;
using GThor.Models.Veiculos;
using GThorFrameworkComponentes.ComboBox;
using GThorFrameworkDominio.Dominios.EstadosUf;

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

            InicializaComboBox();
        }

        private void InicializaComboBox()
        {
            ComboBoxUf.PickItem += ComboBoxUf_OnPickItem;
            ComboBoxUf.UfSelecionado = new Uf {Id = 1};
        }

        private void ComboBoxUf_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            _model.UfSelecionado = comboBoxUf?.UfSelecionado;
        }
    }
}
