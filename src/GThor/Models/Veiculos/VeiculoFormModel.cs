using System;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Veiculos;
using GThorFrameworkDominio.Dominios.Veiculos.Flags;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Contratos;

namespace GThor.Models.Veiculos
{
    public class VeiculoFormModel : ModelViewBase
    {
        private readonly INegocioVeiculo _negocioVeiculo;

        public VeiculoFormModel(INegocioVeiculo negocioVeiculo)
        {
            _negocioVeiculo = negocioVeiculo;
        }

        private Uf _ufSelecionado;
        private string _codigoInterno;
        private string _descricao;
        private string _placa;
        private string _renavam;
        private TipoRodado _tipoRodado;
        private int _taraEmKg;
        private int _capacidadeEmKg;
        private short _capacidadeEmM3;
        private TipoCarroceria _tipoCarroceria;

        public Veiculo Veiculo { get; set; }

        public string CodigoInterno
        {
            get => _codigoInterno;
            set
            {
                if (value == _codigoInterno) return;
                _codigoInterno = value;
                OnPropertyChanged();
            }
        }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == _descricao) return;
                _descricao = value;
                OnPropertyChanged();
            }
        }

        public string Placa
        {
            get => _placa;
            set
            {
                if (value == _placa) return;
                _placa = value;
                OnPropertyChanged();
            }
        }

        public Uf UfSelecionado
        {
            get => _ufSelecionado;
            set
            {
                _ufSelecionado = value;
                OnPropertyChanged();
            }
        }

        public string Renavam
        {
            get => _renavam;
            set
            {
                if (value == _renavam) return;
                _renavam = value;
                OnPropertyChanged();
            }
        }

        public TipoRodado TipoRodado
        {
            get => _tipoRodado;
            set
            {
                if (value == _tipoRodado) return;
                _tipoRodado = value;
                OnPropertyChanged();
            }
        }

        public int TaraEmKg
        {
            get => _taraEmKg;
            set
            {
                if (value == _taraEmKg) return;
                _taraEmKg = value;
                OnPropertyChanged();
            }
        }

        public int CapacidadeEmKg
        {
            get => _capacidadeEmKg;
            set
            {
                if (value == _capacidadeEmKg) return;
                _capacidadeEmKg = value;
                OnPropertyChanged();
            }
        }

        public short CapacidadeEmM3
        {
            get => _capacidadeEmM3;
            set
            {
                if (value == _capacidadeEmM3) return;
                _capacidadeEmM3 = value;
                OnPropertyChanged();
            }
        }

        public TipoCarroceria TipoCarroceria
        {
            get => _tipoCarroceria;
            set
            {
                if (value == _tipoCarroceria) return;
                _tipoCarroceria = value;
                OnPropertyChanged();
            }
        }

        protected override void LoadedCommandAction(object obj)
        {
            TipoRodado = TipoRodado.Truck;
            TipoCarroceria = TipoCarroceria.NaoAplicavel;

            ValidaAntesSalvar += Validar;
            Salvar += SalvarConcluido;


            if (Veiculo.Id == 0) return;

            CodigoInterno = Veiculo.CodigoInterno;
            Descricao = Veiculo.Descricao;
            Placa = Veiculo.Placa;
            UfSelecionado = Veiculo.Uf;
            Renavam = Veiculo.Renavam;
            TipoRodado = Veiculo.TipoRodado;
            TaraEmKg = Veiculo.TaraEmKg;
            CapacidadeEmKg = Veiculo.CapacidadeEmKg;
            CapacidadeEmM3 = Veiculo.CapacidadeEmM3;
            TipoCarroceria = Veiculo.TipoCarroceria;
        }

        private void Validar(object sender, EventArgs e)
        {
            CodigoInterno = CodigoInterno.TrimOrEmpty();
            Descricao = Descricao.TrimOrEmpty();
            Placa = Placa.TrimOrEmpty();
            Renavam = Renavam.TrimOrEmpty();

            if (Placa.IsNullOrEmpty()) throw new ArgumentException("Ei, você esqueceu de adicionar uma placa");
            if (Renavam.IsNullOrEmpty()) throw new ArgumentException("Ei, você esqueceu de adicionar um renavam");
            if (Renavam.Length < 9) throw new ArgumentException("Xii, o renavam deve ter no mínimo 9 digitos e no máximo 11 hehe");
            if (UfSelecionado == null) throw new ArgumentException("Ei, você esqueceu de adicionar um Estado (UF)");
        }

        private void SalvarConcluido(object sender, EventArgs e)
        {
            Veiculo.CodigoInterno = CodigoInterno;
            Veiculo.Descricao = Descricao;
            Veiculo.Placa = Placa;
            Veiculo.UfId = UfSelecionado.Id;
            Veiculo.Renavam = Renavam;
            Veiculo.TipoRodado = TipoRodado;
            Veiculo.TaraEmKg = TaraEmKg;
            Veiculo.CapacidadeEmKg = CapacidadeEmKg;
            Veiculo.CapacidadeEmM3 = CapacidadeEmM3;
            Veiculo.TipoCarroceria = TipoCarroceria;

            _negocioVeiculo.SalvarOuAtualizar(Veiculo);
        }
    }
}