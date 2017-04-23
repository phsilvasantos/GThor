using System.Windows;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkComponentes.ComboBox
{
    public partial class ComboBoxUfCidade
    {
        public ComboBoxUfCidade()
        {
            DataContext = this;
            InitializeComponent();
            InicializaComboBox();
        }

        private void InicializaComboBox()
        {
            ComboBoxUfPicker.PickItem += ComboBoxUf_OnPickItem;
            ComboBoxUfPicker.UfSelecionado = new Uf { Id = 1 };

            ComboBoxCidadePicker.PickItemCidade += ComboBoxCidade_OnPickItemCidade;
        }

        private void ComboBoxCidade_OnPickItemCidade(object sender, RoutedEventArgs e)
        {
        }

        private void ComboBoxUf_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;

            var uf = comboBoxUf?.UfSelecionado;

            ComboBoxCidadePicker.PesquisaPorUf(uf);
        }
    }
}
