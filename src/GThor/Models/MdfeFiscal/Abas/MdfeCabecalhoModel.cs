using System;
using System.Collections.ObjectModel;
using GThor.Models.MdfeFiscal.Base;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Criadores;

namespace GThor.Models.MdfeFiscal.Abas
{
    public class MdfeCabecalhoModel : MdfeViewModel
    {
        public event EventHandler TrocouUfCarregamentoHandler;
        public event EventHandler TrocouUfDescarregamentoHandler;

        private ObservableCollection<PerfilMdfeDto> _colecaoPerfilMdfe;
        private PerfilMdfeDto _perfilMdfeDtoSelecionado;
        private bool _isGeracaoNumeracaoManual;
        private short _serie;
        private bool _isHomologacao;
        private long _numeroFiscal;
        private TipoEmitente _tipoEmitente;
        private UnidadeMedida _unidadeMedida;
        private decimal _pesoBruto;
        private decimal _valorTotalCarga;
        private string _observacoes;

        public ObservableCollection<PerfilMdfeDto> ColecaoPerfilMdfe
        {
            get => _colecaoPerfilMdfe;
            set
            {
                if (Equals(value, _colecaoPerfilMdfe)) return;
                _colecaoPerfilMdfe = value;
                OnPropertyChanged();
            }
        }

        public PerfilMdfeDto PerfilMdfeDtoSelecionado
        {
            get => _perfilMdfeDtoSelecionado;
            set
            {
                if (Equals(value, _perfilMdfeDtoSelecionado)) return;
                _perfilMdfeDtoSelecionado = value;
                OnPropertyChanged();
                PreenchePerfil();
            }
        }

        public bool IsGeracaoNumeracaoManual
        {
            get => _isGeracaoNumeracaoManual;
            set
            {
                if (value == _isGeracaoNumeracaoManual) return;
                _isGeracaoNumeracaoManual = value;
                OnPropertyChanged();
            }
        }

        public short Serie
        {
            get => _serie;
            set
            {
                if (value == _serie) return;
                _serie = value;
                OnPropertyChanged();
            }
        }

        public bool IsHomologacao
        {
            get => _isHomologacao;
            set
            {
                if (value == _isHomologacao) return;
                _isHomologacao = value;
                OnPropertyChanged();
            }
        }

        public long NumeroFiscal
        {
            get => _numeroFiscal;
            set
            {
                if (value == _numeroFiscal) return;
                _numeroFiscal = value;
                OnPropertyChanged();
            }
        }

        public TipoEmitente TipoEmitente
        {
            get => _tipoEmitente;
            set
            {
                if (value == _tipoEmitente) return;
                _tipoEmitente = value;
                OnPropertyChanged();
            }
        }

        public UnidadeMedida UnidadeMedida
        {
            get => _unidadeMedida;
            set
            {
                if (value == _unidadeMedida) return;
                _unidadeMedida = value;
                OnPropertyChanged();
            }
        }

        public decimal PesoBruto
        {
            get => _pesoBruto;
            set
            {
                if (value == _pesoBruto) return;
                _pesoBruto = value;
                OnPropertyChanged();
            }
        }

        public decimal ValorTotalCarga
        {
            get => _valorTotalCarga;
            set
            {
                if (value == _valorTotalCarga) return;
                _valorTotalCarga = value;
                OnPropertyChanged();
            }
        }

        public string Observacoes
        {
            get => _observacoes;
            set
            {
                if (value == _observacoes) return;
                _observacoes = value;
                OnPropertyChanged();
            }
        }

        public Uf UfCarregamento { get; set; }
        public Uf UfDescarregamento { get; set; }

        private void PreenchePerfil()
        {
            var perfilSelecionado = NegocioCriador.CriaNegocioPerfilMdfe().CarregarPorId(PerfilMdfeDtoSelecionado.Id);

            Serie = perfilSelecionado.DocumentoMdfe.Serie;
            IsHomologacao = perfilSelecionado.DocumentoMdfe.AmbienteSefaz == AmbienteSefaz.Homologacao;
            UfCarregamento = perfilSelecionado.Empresa.Uf;
            UfDescarregamento = perfilSelecionado.Empresa.Uf;

            OnTrocouUfCarregamentoHandler();
            OnTrocouUfDescarregamentoHandler();
        }

        protected override void Loaded()
        {
            Habilitado = true;
            Selecionado = true;
            IsGeracaoNumeracaoManual = true;
            TipoEmitente = TipoEmitente.Transportadora;
            UnidadeMedida = UnidadeMedida.Kg;

            InicializaComboBoxPerfilMdfe();
        }

        private void InicializaComboBoxPerfilMdfe()
        {
            var listaPerfilMdfe = NegocioCriador.CriaNegocioPerfilMdfe().BuscarParaComboBox();

            ColecaoPerfilMdfe = new ObservableCollection<PerfilMdfeDto>(listaPerfilMdfe);


        }

        protected virtual void OnTrocouUfCarregamentoHandler()
        {
            TrocouUfCarregamentoHandler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnTrocouUfDescarregamentoHandler()
        {
            TrocouUfDescarregamentoHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}