using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorFrameworkDominio.Dto.CertificadosDigitais;
using GThorNegocio.Criadores;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox.CertificadosDigitais
{
    public partial class ComboBoxCertificadoDigital : INotifyPropertyChanged
    {
        private IEnumerable<CertificadoDigitalComboBoxDto> _cacheCertificadosDigitais;

        private static readonly RoutedEvent PickItemCertificadoDigitalEvent =
            EventManager.RegisterRoutedEvent("PickItemCertificadoDigital", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxCertificadoDigital));

        public event RoutedEventHandler PickItemCertificadoDigital
        {
            add => AddHandler(PickItemCertificadoDigitalEvent, value);
            remove => RemoveHandler(PickItemCertificadoDigitalEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemCertificadoDigitalEvent, this));
        }

        private ObservableCollection<CertificadoDigitalComboBoxDto> _listaCertificadoDigital;
        private CertificadoDigitalComboBoxDto _certificadoDigitalSelecionado;

        public CertificadoDigitalComboBoxDto CertificadoDigitalSelecionado
        {
            get => _certificadoDigitalSelecionado;
            set
            {
                if (Equals(value, _certificadoDigitalSelecionado)) return;
                _certificadoDigitalSelecionado = value;
                OnPropertyChanged();
                OnChanceItem();
            }
        }

        public ObservableCollection<CertificadoDigitalComboBoxDto> ListaCertificadoDigital
        {
            get => _listaCertificadoDigital;
            set
            {
                if (Equals(value, _listaCertificadoDigital)) return;
                _listaCertificadoDigital = value;
                OnPropertyChanged();
            }
        }

        public CertificadoDigitalComboBoxDto Padrao { get; } = new CertificadoDigitalComboBoxDto {Id = 1};

        public ComboBoxCertificadoDigital()
        {
            DataContext = this;
            InitializeComponent();
            ListaCertificadoDigital = new ObservableCollection<CertificadoDigitalComboBoxDto>();
            InicializaCertificadosDigitais();

            AtualizarComboBox();
        }

        private void InicializaCertificadosDigitais()
        {
            var negocio = NegocioCriador.CriaNegocioCertificadoDigital();

            _cacheCertificadosDigitais = new ObservableCollection<CertificadoDigitalComboBoxDto>(negocio.BuscarParaComboBox());
        }

        private void AtualizarComboBox()
        {
            ListaCertificadoDigital.Clear();

            foreach (var certificadoDigitalComboBoxDto in _cacheCertificadosDigitais)
            {
                ListaCertificadoDigital.Add(certificadoDigitalComboBoxDto);
            }

            CertificadoDigitalSelecionado = ListaCertificadoDigital[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
