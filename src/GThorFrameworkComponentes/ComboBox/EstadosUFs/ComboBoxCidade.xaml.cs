using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorNegocio.Criadores;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox.EstadosUFs
{
    public partial class ComboBoxCidade : INotifyPropertyChanged
    {
        private static IEnumerable<Cidade> _cacheCidades;

        private static readonly RoutedEvent PickItemCidadeEvent =
            EventManager.RegisterRoutedEvent("PickItemCidade", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxUf));

        public event RoutedEventHandler PickItemCidade
        {
            add => AddHandler(PickItemCidadeEvent, value);
            remove => RemoveHandler(PickItemCidadeEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemCidadeEvent, this));
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

        public void PesquisaPorUf(Uf uf)
        {
            if (uf == null)
            {
                return;
            }

            ListaCidade.Clear();
            var cidadesFiltradas = _cacheCidades.Where(c => c.Uf.Id == uf.Id);

            var ufComboBoxDtos = cidadesFiltradas as IList<Cidade> ?? cidadesFiltradas.ToList();

            foreach (var ufComboBoxDto in ufComboBoxDtos)
            {
                ListaCidade.Add(ufComboBoxDto);
            }

            CidadeSelecionado = ufComboBoxDtos[0];
        }
    }
}
