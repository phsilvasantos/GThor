using System;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Contratos;

namespace GThor.Models.Empresas
{
    public class EmpresaFormModel : ModelViewBase
    {
        private readonly INegocioEmpresa _negocioEmpresa;

        public EmpresaFormModel(INegocioEmpresa negocioEmpresa)
        {
            _negocioEmpresa = negocioEmpresa;
        }

        private string _razaoSocial;
        private string _nomeFantasia;
        private string _cnpj;
        private string _inscricaoEstadual;
        private string _rntrc;
        private string _logradouro;
        private string _numero;
        private string _bairro;
        private string _complemento;
        private string _telefone;
        private string _email;
        private string _cep;

        public Empresa Empresa { get; set; }

        public string RazaoSocial
        {
            get => _razaoSocial;
            set
            {
                if (value == _razaoSocial) return;
                _razaoSocial = value;
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

        public string Logradouro
        {
            get => _logradouro;
            set
            {
                if (value == _logradouro) return;
                _logradouro = value;
                OnPropertyChanged();
            }
        }

        public string Numero
        {
            get => _numero;
            set
            {
                if (value == _numero) return;
                _numero = value;
                OnPropertyChanged();
            }
        }

        public string Bairro
        {
            get => _bairro;
            set
            {
                if (value == _bairro) return;
                _bairro = value;
                OnPropertyChanged();
            }
        }

        public string Complemento
        {
            get => _complemento;
            set
            {
                if (value == _complemento) return;
                _complemento = value;
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

        public string Cep
        {
            get => _cep;
            set
            {
                if (value == _cep) return;
                _cep = value;
                OnPropertyChanged();
            }
        }

        public Uf Uf { get; set; }
        public Cidade Cidade { get; set; }


        protected override void Loaded()
        {
            ValidaAntesSalvar += ValidarInformacoes;

            Salvar += SalvarConclui;

            if (Empresa.Id == 0) return;

            RazaoSocial = Empresa.RazaoSocial;
            NomeFantasia = Empresa.NomeFantasia;
            Cnpj = Empresa.Cnpj;
            InscricaoEstadual = Empresa.InscricaoEstadual;
            Rntrc = Empresa.Rntrc;
            Logradouro = Empresa.Logradouro;
            Numero = Empresa.Numero;
            Bairro = Empresa.Bairro;
            Complemento = Empresa.Complemento;
            Telefone = Empresa.Telefone;
            Email = Empresa.Email;
            Cep = Empresa.Cep;
            Uf = Empresa.Uf;
            Cidade = Empresa.Cidade;
        }

        private void SalvarConclui(object sender, EventArgs e)
        {
            Empresa.RazaoSocial = RazaoSocial;
            Empresa.NomeFantasia = NomeFantasia;
            Empresa.Cnpj = Cnpj;
            Empresa.InscricaoEstadual = InscricaoEstadual;
            Empresa.Rntrc = Rntrc;
            Empresa.Logradouro = Logradouro;
            Empresa.Numero = Numero;
            Empresa.Bairro = Bairro;
            Empresa.Complemento = Complemento;
            Empresa.Telefone = Telefone;
            Empresa.Email = Email;
            Empresa.Cep = Cep;
            Empresa.UfId = Uf.Id;
            Empresa.CidadeId = Cidade.Id;
            Empresa.Uf = null;
            Empresa.Cidade = null;

            _negocioEmpresa.SalvarOuAtualizar(Empresa);
        }

        private void ValidarInformacoes(object sender, EventArgs e)
        {
            RazaoSocial = RazaoSocial.TrimOrEmpty();
            NomeFantasia = NomeFantasia.TrimOrEmpty();
            Cnpj = Cnpj.TrimOrEmpty();
            InscricaoEstadual = InscricaoEstadual.TrimOrEmpty();
            Rntrc = Rntrc.TrimOrEmpty();
            Logradouro = Logradouro.TrimOrEmpty();
            Numero = Numero.TrimOrEmpty();
            Bairro = Bairro.TrimOrEmpty();
            Complemento = Complemento.TrimOrEmpty();
            Telefone = Telefone.TrimOrEmpty();
            Email = Email.TrimOrEmpty();
            Cep = Cep.TrimOrEmpty();

            if (RazaoSocial.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem razão social? So pode cadastrar se tiver");
            if (NomeFantasia.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem nome fantasia? So pode cadastrar se tiver");

            if (Cnpj.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem cnpj? So pode cadastrar se tiver");
            if (Cnpj.Length != 14) throw new ArgumentException("Hmm, esse cnpj está incorreto");
            Cnpj.EumCnpj();

            if (Rntrc.IsNotNullOrEmpty())
                if (Rntrc.Length != 8) throw new ArgumentException("Hmm, esse rntrc está incorreto, o mesmo deve ter 8 digitos");

            if (Logradouro.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem logradouro? So pode cadastrar se tiver");

            if (Numero.IsNullOrEmpty()) Numero = "S/N";

            if (Bairro.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem bairro? So pode cadastrar se tiver");

            if (Telefone.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem telefone? So pode cadastrar se tiver");

            if (Email.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem email? So pode cadastrar se tiver");
            
            Email.EumEmail();

            if (Uf == null) throw new ArgumentException("Hmm, sua empresa não tem estado(uf)? So pode cadastrar se tiver");

            if (Cidade == null) throw new ArgumentException("Hmm, sua empresa não tem cidade? So pode cadastrar se tiver");

            if (Cep.IsNullOrEmpty()) throw new ArgumentException("Hmm, sua empresa não tem cep? So pode cadastrar se tiver");
        }
    }
}