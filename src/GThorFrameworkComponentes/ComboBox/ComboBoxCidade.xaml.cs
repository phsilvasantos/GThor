using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorNegocio.Criadores;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox
{
    public partial class ComboBoxCidade : INotifyPropertyChanged
    {
        private static IEnumerable<Cidade> _cacheCidades;

        private static readonly RoutedEvent PickItemEvent =
            EventManager.RegisterRoutedEvent("PickItem", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxUf));

        public event RoutedEventHandler PickItem
        {
            add => AddHandler(PickItemEvent, value);
            remove => RemoveHandler(PickItemEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemEvent, this));
        }

        private ObservableCollection<Cidade> _listaCidade;
        private Cidade _cidadeSelecionado;

        public Cidade CidadeSelecionado
        {
            get => _cidadeSelecionado;
            set
            {
                if (Equals(value, _cidadeSelecionado)) return;
                _cidadeSelecionado = value;
                OnPropertyChanged();
                OnChanceItem();
            }
        }

        public ObservableCollection<Cidade> ListaCidade
        {
            get => _listaCidade;
            set
            {
                if (Equals(value, _listaCidade)) return;
                _listaCidade = value;
                OnPropertyChanged();
            }
        }

        private void PreencherListaCidade()
        {
            ListaCidade = new ObservableCollection<Cidade>();

            if (_cacheCidades == null)
            {
                _cacheCidades = NegocioCriador.CriaNegocioCidade().Lista();
            }

            foreach (var ufComboBoxDto in _cacheCidades)
            {
                ListaCidade.Add(ufComboBoxDto);
            }
        }


        public ComboBoxCidade()
        {
            DataContext = this;
            InitializeComponent();
            PreencherListaCidade();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
