using GThorFrameworkDominio.Dominios.Certificados;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    public class CertificadoDigitalNegocio : ICertificadoDigitalNegocio
    {
        private readonly IRepositorioCertificadoDigital _repositorioCertificadoDigital;

        public CertificadoDigitalNegocio(IRepositorioCertificadoDigital repositorioCertificadoDigital)
        {
            _repositorioCertificadoDigital = repositorioCertificadoDigital;
        }

        public void SalvarOuAtualizar(CertificadoDigital certificadoDigital)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioCertificadoDigital.SetGThorContexto(contexto);
                _repositorioCertificadoDigital.SalvarOuAtualizar(certificadoDigital);
                _repositorioCertificadoDigital.SalvarAlteracoes();
            }
        }
    }
}