using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorFrameworkDominio.Dto.DocumentosMdfe;
using GThorNegocio.Criadores;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox.DocumentosDfe
{
    public partial class ComboBoxDocumentoMdfe : INotifyPropertyChanged
    {
        private IEnumerable<DocumentoMdfeComboBoxDto> _cacheDocumentoMdfeComboBoxDtos;

        private static readonly RoutedEvent PickItemDocumentoMdfeEvent =
            EventManager.RegisterRoutedEvent("PickItemDocumentoMdfe", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxDocumentoMdfe));

        public event RoutedEventHandler PickItemDocumentoMdfe
        {
            add => AddHandler(PickItemDocumentoMdfeEvent, value);
            remove => RemoveHandler(PickItemDocumentoMdfeEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemDocumentoMdfeEvent, this));
        }

        private ObservableCollection<DocumentoMdfeComboBoxDto> _listaDocumentoMdfe;
        private DocumentoMdfeComboBoxDto _documentoMdfeSelecionado;

        public DocumentoMdfeComboBoxDto DocumentoMdfeSelecionado
        {
            get => _documentoMdfeSelecionado;
            set
            {
                if (Equals(value, _documentoMdfeSelecionado)) return;
                _documentoMdfeSelecionado = value;
                OnPropertyChanged();
                OnChanceItem();
            }
        }

        public ObservableCollection<DocumentoMdfeComboBoxDto> ListaDocumentoMdfe
        {
            get => _listaDocumentoMdfe;
            set
            {
                if (Equals(value, _listaDocumentoMdfe)) return;
                _listaDocumentoMdfe = value;
                OnPropertyChanged();
            }
        }

        public DocumentoMdfeComboBoxDto Padrao { get; } = new DocumentoMdfeComboBoxDto { Id = 1 };

        public ComboBoxDocumentoMdfe()
        {
            DataContext = this;
            InitializeComponent();
            ListaDocumentoMdfe = new ObservableCollection<DocumentoMdfeComboBoxDto>();
            InicializaDocumentosMdfe();

            PesquisarPorDocumentoMdfe(Padrao);
        }

        private void InicializaDocumentosMdfe()
        {
            var negocio = NegocioCriador.CriaNegocioDocumentoMdfe();

            _cacheDocumentoMdfeComboBoxDtos = new ObservableCollection<DocumentoMdfeComboBoxDto>(negocio.BuscarParaComboBox());
        }

        private void PesquisarPorDocumentoMdfe(DocumentoMdfeComboBoxDto documentoMdfeComboBoxDto)
        {
            if (documentoMdfeComboBoxDto == null)
            {
                return;
            }

            ListaDocumentoMdfe.Clear();

            var documentosMdfeFiltradas = _cacheDocumentoMdfeComboBoxDtos.Where(e => e.Id == documentoMdfeComboBoxDto.Id);

            var documentoMdfeComboBoxDtos = documentosMdfeFiltradas as IList<DocumentoMdfeComboBoxDto> ?? documentosMdfeFiltradas.ToList();

            foreach (var mdfeComboBoxDto in documentoMdfeComboBoxDtos)
            {
                ListaDocumentoMdfe.Add(mdfeComboBoxDto);
            }

            DocumentoMdfeSelecionado = documentoMdfeComboBoxDtos[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
