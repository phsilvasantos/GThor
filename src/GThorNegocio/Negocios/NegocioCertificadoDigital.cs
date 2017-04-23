using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Criadores;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    internal class NegocioCertificadoDigital : INegocioCertificadoDigital
    {
        private readonly IRepositorioCertificadoDigital _repositorioCertificadoDigital;

        public NegocioCertificadoDigital(IRepositorioCertificadoDigital repositorioCertificadoDigital)
        {
            _repositorioCertificadoDigital = repositorioCertificadoDigital;
        }

        public void SalvarOuAtualizar(CertificadoDigital certificadoDigital)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioCertificadoDigital.SetGThorContexto(contexto);
                _repositorioCertificadoDigital.SalvarOuAtualizar(certificadoDigital);
                _repositorioCertificadoDigital.SalvarAlteracoes();
            }
        }

        public CertificadoDigital CarregarPorId(int id)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioCertificadoDigital.SetGThorContexto(contexto);
                return _repositorioCertificadoDigital.CarregarPorId(id);
            }
        }

        public IEnumerable<CertificadoDigital> Lista()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioCertificadoDigital.SetGThorContexto(contexto);
                return _repositorioCertificadoDigital.Lista();
            }
        }

        public void Deletar(CertificadoDigital certificadoDigital)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioCertificadoDigital.SetGThorContexto(contexto);
                _repositorioCertificadoDigital.Deletar(certificadoDigital);
                _repositorioCertificadoDigital.SalvarAlteracoes();
            }
        }
    }
}