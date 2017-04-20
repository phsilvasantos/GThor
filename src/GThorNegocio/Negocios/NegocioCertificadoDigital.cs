using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    public class NegocioCertificadoDigital : INegocioCertificadoDigital
    {
        private readonly IRepositorioCertificadoDigital _repositorioCertificadoDigital;

        public NegocioCertificadoDigital(IRepositorioCertificadoDigital repositorioCertificadoDigital)
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

        public IEnumerable<CertificadoDigital> Lista()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioCertificadoDigital.SetGThorContexto(contexto);
                return _repositorioCertificadoDigital.Lista();
            }
        }

        public void Deletar(CertificadoDigital certificadoDigital)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioCertificadoDigital.SetGThorContexto(contexto);
                _repositorioCertificadoDigital.Deletar(certificadoDigital);
                _repositorioCertificadoDigital.SalvarAlteracoes();
            }
        }
    }
}