using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GThor.Models.MdfeFiscal.Base;
using GThorFrameworkDominio.Dominios.Cidades;
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
        public event EventHandler<MdfeCabecalhoModel> ProximoMdfeDocumento;

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
        private bool _isPerfilSelecionado;
        private ObservableCollection<Uf> _percurso;
        private Uf _percursoSelecionado;

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

        public bool IsPerfilSelecionado
        {
            get => _isPerfilSelecionado;
            set
            {
                if (value == _isPerfilSelecionado) return;
                _isPerfilSelecionado = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Uf> Percurso
        {
            get => _percurso;
            set
            {
                if (Equals(value, _percurso)) return;
                _percurso = value;
                OnPropertyChanged();
            }
        }

        private void PreenchePerfil()
        {
            var perfilSelecionado = NegocioCriador.CriaNegocioPerfilMdfe().CarregarPorId(PerfilMdfeDtoSelecionado.Id);

            Serie = perfilSelecionado.DocumentoMdfe.Serie;
            IsHomologacao = perfilSelecionado.DocumentoMdfe.AmbienteSefaz == AmbienteSefaz.Homologacao;
            UfCarregamento = perfilSelecionado.Empresa.Uf;
            UfDescarregamento = perfilSelecionado.Empresa.Uf;

            OnTrocouUfCarregamentoHandler();
            OnTrocouUfDescarregamentoHandler();

            IsPerfilSelecionado = true;
        }

        public event EventHandler LoadedCabecalho;

        protected override void Loaded()
        {
            Habilitado = true;
            Selecionado = true;
            IsGeracaoNumeracaoManual = true;
            TipoEmitente = TipoEmitente.Transportadora;
            UnidadeMedida = UnidadeMedida.Kg;

            InicializaComboBoxPerfilMdfe();
            InicializaPercurso();
            InicializaMunicipioCarregamento();
            OnLoadedCabecalho();
        }

        private void InicializaMunicipioCarregamento()
        {
            MunicipioCarregamento = new ObservableCollection<Cidade>();
        }

        private void InicializaPercurso()
        {
            Percurso = new ObservableCollection<Uf>();
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

        public ICommand AdicionarPercursoCommand => GetSimpleCommand(AdicionarPercursoAction);

        public Uf PercursoSelecionado
        {
            get => _percursoSelecionado;
            set
            {
                if (Equals(value, _percursoSelecionado)) return;
                _percursoSelecionado = value;
                OnPropertyChanged();
            }
        }

        private void AdicionarPercursoAction(object obj)
        {
            ValidacoesUfs();

            if (UfCarregamento == UfDescarregamento)
            {
                throw new ArgumentException("A uf de carregamento é igual a uf de descarregamento, logo então não tenho percurso");
            }

            if (PercursoSelecionado == UfCarregamento)
            {
                throw new ArgumentException("Não pode adicionar a uf de carregamento no percurso");
            }

            if (PercursoSelecionado == UfDescarregamento)
            {
                throw new ArgumentException("Não pode adicionar a uf de descarregamento no percurso");
            }

            if (Percurso.Any(p => p == PercursoSelecionado))
            {
                throw new ArgumentException("Xii, esta uf já esta na lista");
            }

            Percurso.Add(PercursoSelecionado);

        }

        private void ValidacoesUfs()
        {
            ValidacaoCarregamentoEDescarregamento();

            if (PercursoSelecionado == null) throw new ArgumentException("Selecione uma percurso hehe");
        }

        private void ValidacaoCarregamentoEDescarregamento()
        {
            if (UfCarregamento == null) throw new ArgumentException("Selecione uma Uf de carregamento hehe");

            if (UfDescarregamento == null) throw new ArgumentException("Selecione uma Uf de descarregamento hehe");
        }

        public ICommand DeletarPercursoCommand => GetSimpleCommand(DeletarPercursoAction);

        public ICommand DeletarCidadeCommand => GetSimpleCommand(DeletarCidadeAction);

        public ObservableCollection<Cidade> MunicipioCarregamento { get; set; }

        public Cidade MunicipioCarregamentoSelecionado { get; set; }

        public ICommand AdicionarMunicipioCarregamentoCommand => GetSimpleCommand(AdicionarMunicipioCarregamentoAction);

        public ICommand ProximaMdfeDocumentoCommand => GetSimpleCommand(ProximaMdfeDocumentoAction);

        private void ProximaMdfeDocumentoAction(object obj)
        {
            ValidacaoCarregamentoEDescarregamento();
            ValidaPercursoXMunicipiosCarregamento();

            OnProximoMdfeDocumento();
        }

        private void ValidaPercursoXMunicipiosCarregamento()
        {
            if (MunicipioCarregamento.Count == 0)
            {
                throw new ArgumentException("Adicionar pelo menos um municipio de carregamento hihi");
            }

            var listaDeUfsCaminho = Percurso.ToList();

            listaDeUfsCaminho.Add(UfCarregamento);
            listaDeUfsCaminho.Add(UfDescarregamento);

            IList<Cidade> cidadesFiltradas = listaDeUfsCaminho
                .SelectMany(uf => MunicipioCarregamento.Where(c => c.Uf.Id == uf.Id)).ToList();

            if (cidadesFiltradas.Count == 0)
            {
                throw new ArgumentException(
                    "Bom pelo que olhei, você tem municipios de carregamentos que não é equivalente ao percurso");
            }
        }

        private void AdicionarMunicipioCarregamentoAction(object obj)
        {
            MunicipioCarregamento.Add(MunicipioCarregamentoSelecionado);
        }

        private void DeletarCidadeAction(object obj)
        {
            var municipioCarregamentoSelecionadoAtualmente = MunicipioCarregamentoSelecionado;

            MunicipioCarregamento.Remove(MunicipioCarregamentoSelecionado);

            MunicipioCarregamentoSelecionado = municipioCarregamentoSelecionadoAtualmente;
        }

        private void DeletarPercursoAction(object obj)
        {
            if (MunicipioCarregamento.Count(m => m.Uf == PercursoSelecionado) != 0)
            {
                throw new ArgumentException("Deletar municipios carregamento vinculados a esta uf : " + PercursoSelecionado.Nome);
            }


            var percursoSelecionadoAtualmente = PercursoSelecionado;

            Percurso.Remove(PercursoSelecionado);

            PercursoSelecionado = percursoSelecionadoAtualmente;
        }

        protected virtual void OnLoadedCabecalho()
        {
            LoadedCabecalho?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnProximoMdfeDocumento()
        {
            ProximoMdfeDocumento?.Invoke(this, this);
        }
    }
}