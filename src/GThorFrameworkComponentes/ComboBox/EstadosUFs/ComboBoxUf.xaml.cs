using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorNegocio.Criadores;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox.EstadosUFs
{
    public partial class ComboBoxUf : INotifyPropertyChanged
    {
        private static IEnumerable<Uf> _cacheUfs;

        private static readonly RoutedEvent PickItemEvent =
            EventManager.RegisterRoutedEvent("PickItem", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxUf));


        public string CLabel
        {
            get => (string)GetValue(CLabelProperty);
            set => SetValue(CLabelProperty, value);
        }

        public static readonly DependencyProperty CLabelProperty =
            DependencyProperty.Register("CLabel", typeof(string), typeof(ComboBoxUf), new PropertyMetadata(string.Empty, CLabelCallback));

        private static void CLabelCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBoxUf = d as ComboBoxUf;

            if (comboBoxUf == null) return;

            comboBoxUf.CLabelNome.Text = e.NewValue.ToString();
        }


        public event RoutedEventHandler PickItem
        {
            add => AddHandler(PickItemEvent, value);
            remove => RemoveHandler(PickItemEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemEvent, this));
        }

        private ObservableCollection<Uf> _listaEstadoUf;
        private Uf _ufSelecionado;

        public Uf UfSelecionado
        {
            get => _ufSelecionado;
            set
            {
                if (Equals(value, _ufSelecionado)) return;
                _ufSelecionado = value;
                OnPropertyChanged();
                OnChanceItem();
            }
        }

        public ObservableCollection<Uf> ListaEstadoUf
        {
            get => _listaEstadoUf;
            set
            {
                if (Equals(value, _listaEstadoUf)) return;
                _listaEstadoUf = value;
                OnPropertyChanged();
            }
        }

        public Uf Default => ListaEstadoUf[0];

        private void PreencherListaEstadoUf()
        {
            ListaEstadoUf = new ObservableCollection<Uf>();

            if (_cacheUfs == null)
            {
                _cacheUfs = NegocioCriador.CriaNegocioUf().Lista();
            }

            foreach (var ufComboBoxDto in _cacheUfs)
            {
                ListaEstadoUf.Add(ufComboBoxDto);
            }
        }

        public ComboBoxUf()
        {
            DataContext = this;
            PreencherListaEstadoUf();
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
