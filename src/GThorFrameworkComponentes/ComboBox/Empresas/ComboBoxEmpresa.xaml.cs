using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorFrameworkDominio.Dto.Empresas;
using GThorNegocio.Criadores;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox.Empresas
{
    public partial class ComboBoxEmpresa : INotifyPropertyChanged
    {
        private IEnumerable<EmpresaComboBoxDto> _cacheEmpresas;

        private static readonly RoutedEvent PickItemEmpresaEvent =
            EventManager.RegisterRoutedEvent("PickItemEmpresa", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxEmpresa));

        public event RoutedEventHandler PickItemEmpresa
        {
            add => AddHandler(PickItemEmpresaEvent, value);
            remove => RemoveHandler(PickItemEmpresaEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemEmpresaEvent, this));
        }

        private ObservableCollection<EmpresaComboBoxDto> _listaEmpresa;
        private EmpresaComboBoxDto _empresaSelecionada;

        public EmpresaComboBoxDto EmpresaSelecionada
        {
            get => _empresaSelecionada;
            set
            {
                if (Equals(value, _empresaSelecionada)) return;
                _empresaSelecionada = value;
                OnPropertyChanged();
                OnChanceItem();
            }
        }

        public ObservableCollection<EmpresaComboBoxDto> ListaEmpresa
        {
            get => _listaEmpresa;
            set
            {
                if (Equals(value, _listaEmpresa)) return;
                _listaEmpresa = value;
                OnPropertyChanged();
            }
        }

        public EmpresaComboBoxDto Padrao { get; } = new EmpresaComboBoxDto {Id = 1};


        public ComboBoxEmpresa()
        {
            DataContext = this;
            InitializeComponent();
            ListaEmpresa = new ObservableCollection<EmpresaComboBoxDto>();
            InicializaEmpresas();

            PesquisarPorEmpresa(new EmpresaComboBoxDto
            {
                Id = 1
            });
        }

        private void InicializaEmpresas()
        {
            var negocio = NegocioCriador.CriaNegocioEmpresa();

            _cacheEmpresas = new ObservableCollection<EmpresaComboBoxDto>(negocio.BuscarParaComboBox());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PesquisarPorEmpresa(EmpresaComboBoxDto empresa)
        {
            if (empresa == null)
            {
                return;
            }

            ListaEmpresa.Clear();

            var empresasFiltradas = _cacheEmpresas.Where(e => e.Id == empresa.Id);

            var empresasComboBoxDtos = empresasFiltradas as IList<EmpresaComboBoxDto> ?? empresasFiltradas.ToList();

            foreach (var empresaComboBoxDto in empresasComboBoxDtos)
            {
                ListaEmpresa.Add(empresaComboBoxDto);
            }

            EmpresaSelecionada = empresasComboBoxDtos[0];
        }
    }
}
