using System;
using System.Windows.Input;
using GThorFrameworkBiblioteca.Ferramentas.HelpersCriptografia;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Negocios;

namespace GThor.Models.CertificadoDigitais
{
    public class CertificadoDigitalFormModel : ModelViewBase
    {
        private readonly NegocioCertificadoDigital _certificadoDigitalNegocio;
        private string _arquivo;
        private string _descricao;
        private bool _isArquivo;
        private bool _isSenha;
        private bool _isSerial;
        private string _senha;
        private string _serial;
        private TipoCertificado _tipoCertificado;

        public CertificadoDigitalFormModel(NegocioCertificadoDigital certificadoDigitalNegocio)
        {
            _certificadoDigitalNegocio = certificadoDigitalNegocio;
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

        public TipoCertificado TipoCertificado
        {
            get => _tipoCertificado;
            set
            {
                _tipoCertificado = value;
                MudarUiPorTipo(_tipoCertificado);
                OnPropertyChanged();
            }
        }

        public bool IsSenha
        {
            get => _isSenha;
            set
            {
                if (value == _isSenha) return;
                _isSenha = value;
                OnPropertyChanged();
            }
        }

        public bool IsSerial
        {
            get => _isSerial;
            set
            {
                if (value == _isSerial) return;
                _isSerial = value;
                OnPropertyChanged();
            }
        }

        public bool IsArquivo
        {
            get => _isArquivo;
            set
            {
                if (value == _isArquivo) return;
                _isArquivo = value;
                OnPropertyChanged();
            }
        }

        public string Arquivo
        {
            get => _arquivo;
            set
            {
                if (value == _arquivo) return;
                _arquivo = value;
                OnPropertyChanged();
            }
        }

        public string Serial
        {
            get => _serial;
            set
            {
                if (value == _serial) return;
                _serial = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get => _senha;
            set
            {
                if (value == _senha) return;
                _senha = value;
                OnPropertyChanged();
            }
        }

        public CertificadoDigital CertificadoDigital { get; set; }

        public ICommand CommandBuscarSerial => GetSimpleCommand(BuscarSerial);

        private void BuscarSerial(object obj)
        {
            var certificado = DFe.Utils.Assinatura.CertificadoDigital.ListareObterDoRepositorio();

            using (certificado)
            {
                Serial = certificado.SerialNumber;
            }
        }

        private void MudarUiPorTipo(TipoCertificado tipoCertificado)
        {
            LimparCampos();

            switch (tipoCertificado)
            {
                case TipoCertificado.A1Repositorio:
                    IsArquivo = false;
                    IsSerial = true;
                    IsSenha = false;
                    break;
                case TipoCertificado.A3:
                    IsArquivo = false;
                    IsSerial = true;
                    IsSenha = true;
                    break;

                case TipoCertificado.A1Arquivo:
                    IsArquivo = true;
                    IsSerial = false;
                    IsSenha = true;
                    break;
            }
        }

        private void LimparCampos()
        {
            Arquivo = string.Empty;
            Senha = string.Empty;
            Serial = string.Empty;
        }

        protected override void LoadedCommandAction(object obj)
        {
            ValidaAntesSalvar += Validacoes;
            Salvar += SalvaCertificado;


            if (CertificadoDigital.Id != 0)
            {
                TipoCertificado = CertificadoDigital.Tipo;
                Senha = SimetricaHelper.Descomputar(CertificadoDigital.Senha);
                Arquivo = CertificadoDigital.CaminhoCertificado;
                Serial = SimetricaHelper.Descomputar(CertificadoDigital.Serial);
                Descricao = CertificadoDigital.Descricao;
            }
        }

        private void SalvaCertificado(object sender, EventArgs e)
        {
            CertificadoDigital.Senha = SimetricaHelper.Computar(Senha);
            CertificadoDigital.CaminhoCertificado = Arquivo;
            CertificadoDigital.Serial = SimetricaHelper.Computar(Serial);
            CertificadoDigital.Tipo = TipoCertificado;
            CertificadoDigital.Descricao = Descricao;

            _certificadoDigitalNegocio.SalvarOuAtualizar(CertificadoDigital);
        }

        private void Validacoes(object sender, EventArgs e)
        {
            Descricao = Descricao.TrimOrEmpty();
            Serial = Serial.TrimOrEmpty();
            Senha = Senha.TrimOrEmpty();
            Arquivo = Arquivo.TrimOrEmpty();

            if (Descricao.IsNullOrEmpty()) throw new ArgumentException("Ei, você tem que adicionar uma descrição querido(a)");


            switch (TipoCertificado)
            {
                case TipoCertificado.A1Arquivo:
                        if (Arquivo.IsNullOrEmpty()) throw new ArgumentException("Ei, você tem que adicionar um caminho para o arquivo de certificado digital querido(a)");

                        if (Senha.IsNullOrEmpty()) throw new ArgumentException("Ei, você tem que adicionar uma senha querido(a)");
                    break;
                case TipoCertificado.A3:
                case TipoCertificado.A1Repositorio:
                        if (Serial.IsNullOrEmpty()) throw new ArgumentException("Ei, você tem que adicionar um serial de certificado digital querido(a)");
                    break;
            }
        }
    }
}