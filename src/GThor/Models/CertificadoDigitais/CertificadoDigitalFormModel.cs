using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.CertificadoDigitais
{
    public class CertificadoDigitalFormModel : ModelViewBase
    {
        private TipoCertificado _tipoCertificado;
        private string _arquivo;
        private string _serial;
        private string _senha;

        public TipoCertificado TipoCertificado
        {
            get => _tipoCertificado;
            set
            {
                if (value == _tipoCertificado) return;
                _tipoCertificado = value;
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
    }
}