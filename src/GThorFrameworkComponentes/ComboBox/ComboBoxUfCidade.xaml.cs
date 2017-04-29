using System.Windows;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkComponentes.ComboBox
{
    public partial class ComboBoxUfCidade
    {

        private static readonly RoutedEvent PickItemComboUfCidadeEvent =
            EventManager.RegisterRoutedEvent("PickItemComboUfCidadeCidade", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxUfCidade));


        public event RoutedEventHandler PickItemComboUfCidade
        {
            add => AddHandler(PickItemComboUfCidadeEvent, value);
            remove => RemoveHandler(PickItemComboUfCidadeEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemComboUfCidadeEvent, this));
        }

        public Uf UfSelecionado => ComboBoxUfPicker.UfSelecionado;

        public Cidade CidadeSelecionada => ComboBoxCidadePicker.CidadeSelecionado;

        public ComboBoxUfCidade()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void InicializaComboBox()
        {
            ComboBoxUfPicker.PickItem += ComboBoxUf_OnPickItem;
            ComboBoxUfPicker.UfSelecionado = ComboBoxUfPicker.Default;

            ComboBoxCidadePicker.PickItemCidade += ComboBoxCidade_OnPickItemCidade;
        }

        private void ComboBoxCidade_OnPickItemCidade(object sender, RoutedEventArgs e)
        {
            OnChanceItem();
        }

        private void ComboBoxUf_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;

            var uf = comboBoxUf?.UfSelecionado;

            ComboBoxCidadePicker.PesquisaPorUf(uf);

            OnChanceItem();
        }

        private void ComboBoxUfCidade_OnLoaded(object sender, RoutedEventArgs e)
        {
            InicializaComboBox();
        }

        public void SetEstadoUf(Uf uf)
        {
            ComboBoxUfPicker.UfSelecionado = uf;
        }

        public void SetCidade(Cidade cidade)
        {
            ComboBoxCidadePicker.CidadeSelecionado = cidade;
        }

        public void SetEstadoUfId(int id)
        {
            SetEstadoUf(new Uf {Id = id});
        }

        public void SetCidadeId(int id)
        {
            SetCidade(new Cidade {Id = id});
        }
    }
}
