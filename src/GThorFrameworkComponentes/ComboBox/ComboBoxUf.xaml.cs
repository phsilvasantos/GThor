using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorNegocio.Dto;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Implementacao;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox
{
    public partial class ComboBoxUf : INotifyPropertyChanged
    {
        private static readonly RoutedEvent OnPickItemEvent =
            EventManager.RegisterRoutedEvent("OnPickItem", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxUf));

        public event RoutedEventHandler OnPickItem
        {
            add => AddHandler(OnPickItemEvent, value);
            remove => RemoveHandler(OnPickItemEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(OnPickItemEvent, this));
        }

        private ObservableCollection<UfComboBoxDto> _listaEstadoUf;
        private UfComboBoxDto _ufSelecionado;

        public UfComboBoxDto UfSelecionado
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

        public ObservableCollection<UfComboBoxDto> ListaEstadoUf
        {
            get => _listaEstadoUf;
            set
            {
                if (Equals(value, _listaEstadoUf)) return;
                _listaEstadoUf = value;
                OnPropertyChanged();
            }
        }

        public ComboBoxUf()
        {
            DataContext = this;
            PreencherListaEstadoUf();
            UfSelecionado = ListaEstadoUf[0];
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PreencherListaEstadoUf()
        {
            ListaEstadoUf = new ObservableCollection<UfComboBoxDto>();

            var listaUf = new NegocioUf(new RepositorioUf()).ListaParaComboBox();

            foreach (var ufComboBoxDto in listaUf)
            {
                ListaEstadoUf.Add(ufComboBoxDto);
            }
        }
    }
}
