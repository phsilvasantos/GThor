using System;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
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
        private bool _isFisica;
        private bool _isJuridica;

        public PessoaFormModel(INegocioPessoa negocioPessoa)
        {
            _negocioPessoa = negocioPessoa;
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

                switch (value)
                {
                    case TipoPessoa.Fisica:
                        IsJuridica = false;
                        IsFisica = true;
                        break;
                    case TipoPessoa.Juridica:
                        IsJuridica = true;
                        IsFisica = false;
                        break;
                }
            }
        }

        public bool IsFisica
        {
            get => _isFisica;
            set
            {
                if (value == _isFisica) return;
                _isFisica = value;
                OnPropertyChanged();

                LimpaCamposPessoaFisicaEJuridica();
            }
        }

        public bool IsJuridica
        {
            get => _isJuridica; set
            {
                if (value == _isJuridica) return;
                _isJuridica = value;
                OnPropertyChanged();

                LimpaCamposPessoaFisicaEJuridica();
            }
        }

        private void LimpaCamposPessoaFisicaEJuridica()
        {
            Cnpj = string.Empty;
            NomeFantasia = string.Empty;
            Cpf = string.Empty;
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

                Rntrc = string.Empty;
                TipoProprietario = TipoProprietario.Agregado;
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

        protected override void Loaded()
        {
            TipoPessoa = TipoPessoa.Fisica;
            TipoProprietario = TipoProprietario.Agregado;
            ValidaAntesSalvar += ValidarInformacoes;
            Salvar += SalvarAction;


            if (Pessoa.Id == 0) return;
            {
                if (Pessoa.Transportadora != null && Pessoa.Transportadora.Id != 0)
                {
                    IsTransportadora = true;
                    Rntrc = Pessoa.Transportadora.Rntrc;
                    TipoProprietario = Pessoa.Transportadora.TipoProprietario;
                }

                if (Pessoa.Condutor != null && Pessoa.Condutor.Id != 0)
                {
                    IsCondutor = true;
                }

                Nome = Pessoa.Nome;
                TipoPessoa = Pessoa.TipoPessoa;
                InscricaoEstadual = Pessoa.InscricaoEstadual;
                NomeFantasia = Pessoa.NomeFantasia;
                Cnpj = Pessoa.Cnpj;
                Cpf = Pessoa.Cpf;
                Email = Pessoa.Email;
                Telefone = Pessoa.Telefone;
            }
        }

        private void SalvarAction(object sender, EventArgs e)
        {

            if (IsTransportadora)
            {
                var idTransportadora = Pessoa.Transportadora == null ? 0 : Pessoa.Transportadora.Id;

                Pessoa.Transportadora = new Transportadora(Pessoa, idTransportadora)
                {
                    Rntrc = Rntrc,
                    TipoProprietario = TipoProprietario
                };
            }

            if (IsCondutor)
            {
                var idCondutor = Pessoa.Condutor == null ? 0 : Pessoa.Condutor.Id;

                Pessoa.Condutor = new Condutor(Pessoa, idCondutor);
            }

            if (!IsTransportadora)
            {
                Pessoa.Transportadora = null;
            }

            if (!IsCondutor)
            {
                Pessoa.Condutor = null;
            }

            Pessoa.Nome = Nome;
            Pessoa.TipoPessoa = TipoPessoa;
            Pessoa.InscricaoEstadual = InscricaoEstadual;
            Pessoa.NomeFantasia = NomeFantasia;
            Pessoa.Cnpj = Cnpj;
            Pessoa.Cpf = Cpf;
            Pessoa.Email = Email;
            Pessoa.Telefone = Telefone;
            Pessoa.Uf = Uf;
            Pessoa.Cidade = Cidade;

            _negocioPessoa.SalvarOuAtualizar(Pessoa);
        }

        private void ValidarInformacoes(object sender, EventArgs e)
        {
            if (Nome.IsNullOrEmpty()) throw new ArgumentException("Sem me informar um nome não posso te cadastrar");

            ValidaPorTipoPessoa();

            if (Email.IsNotNullOrEmpty())
                Email.EumEmail();

            if (!IsCondutor) return;
            if (TipoPessoa != TipoPessoa.Fisica) throw new ArgumentException("Xiii, para você ser um condutor você deve ser uma pessoa física");
        }

        private void ValidaPorTipoPessoa()
        {
            switch (TipoPessoa)
            {
                case TipoPessoa.Fisica:
                    if (Cpf.IsNullOrEmpty()) throw new ArgumentException("Sem me informar um CPF não posso te cadastrar");

                    Cpf.EumCpf();

                    break;

                case TipoPessoa.Juridica:
                    if (Cnpj.IsNullOrEmpty()) throw new ArgumentException("Sem me informar um CNPJ não posso te cadastrar");

                    Cnpj.EumCnpj();

                    if (NomeFantasia.IsNullOrEmpty())
                        throw new ArgumentException("Sem me informar um nome fantasia te cadastrar");
                    break;
                default:
                    throw new ArgumentException("Oxi, esse tipo pessoa não existe");
            }
        }
    }
}