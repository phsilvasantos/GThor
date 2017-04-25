using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Pessoas;
using GThorFrameworkDominio.Dominios.Pessoas.Flags;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Contratos;

namespace GThor.Models.Pessoas
{
    public class PessoaFormModel : ModelViewBase
    {
        private readonly INegocioPessoa _negocioPessoa;
        private string _nome;
        private string _email;
        private TipoPessoa _tipoPessoa;
        private string _inscricaoEstadual;
        private string _telefone;
        private Uf _uf;
        private Cidade _cidade;
        private string _nomeFantasia;
        private string _cnpj;
        private string _cpf;
        private string _rntrc;
        private TipoProprietario _tipoProprietario;
        private bool _isTransportadora;
        private bool _isCondutor;

        public PessoaFormModel(INegocioPessoa negocioPessoa)
        {
            _negocioPessoa = negocioPessoa;

            TipoPessoa = TipoPessoa.Fisica;
        }

        public Pessoa Pessoa { get; set; }

        public string Nome
        {
            get => _nome;
            set
            {
                if (value == _nome) return;
                _nome = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value == _email) return;
                _email = value;
                OnPropertyChanged();
            }
        }

        public TipoPessoa TipoPessoa
        {
            get => _tipoPessoa;
            set
            {
                if (value == _tipoPessoa) return;
                _tipoPessoa = value;
                OnPropertyChanged();
            }
        }

        public string InscricaoEstadual
        {
            get => _inscricaoEstadual;
            set
            {
                if (value == _inscricaoEstadual) return;
                _inscricaoEstadual = value;
                OnPropertyChanged();
            }
        }

        public string Telefone
        {
            get => _telefone;
            set
            {
                if (value == _telefone) return;
                _telefone = value;
                OnPropertyChanged();
            }
        }

        public Uf Uf
        {
            get => _uf;
            set
            {
                if (Equals(value, _uf)) return;
                _uf = value;
                OnPropertyChanged();
            }
        }

        public Cidade Cidade
        {
            get => _cidade;
            set
            {
                if (Equals(value, _cidade)) return;
                _cidade = value;
                OnPropertyChanged();
            }
        }

        public string NomeFantasia
        {
            get => _nomeFantasia;
            set
            {
                if (value == _nomeFantasia) return;
                _nomeFantasia = value;
                OnPropertyChanged();
            }
        }

        public string Cnpj
        {
            get => _cnpj;
            set
            {
                if (value == _cnpj) return;
                _cnpj = value;
                OnPropertyChanged();
            }
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                if (value == _cpf) return;
                _cpf = value;
                OnPropertyChanged();
            }
        }

        public string Rntrc
        {
            get => _rntrc;
            set
            {
                if (value == _rntrc) return;
                _rntrc = value;
                OnPropertyChanged();
            }
        }

        public TipoProprietario TipoProprietario
        {
            get => _tipoProprietario;
            set
            {
                if (value == _tipoProprietario) return;
                _tipoProprietario = value;
                OnPropertyChanged();
            }
        }

        public bool IsTransportadora
        {
            get => _isTransportadora; set
            {
                if (value == _isTransportadora) return;
                _isTransportadora = value;
                OnPropertyChanged();
            }
        }

        public bool IsCondutor
        {
            get => _isCondutor; set
            {
                if (value == _isCondutor) return;
                _isCondutor = value;
                OnPropertyChanged();
            }
        }


    }
}