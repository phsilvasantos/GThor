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


        protected override void LoadedCommandAction(object obj)
        {
            ValidaAntesSalvar += ValidarInformacoes;
        }

        private void ValidarInformacoes(object sender, EventArgs e)
        {
            RazaoSocial = RazaoSocial.TrimOrEmpty();

            if (RazaoSocial.IsNullOrEmpty()) throw new ArgumentException("");
        }
    }
}