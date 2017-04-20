using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;

namespace GThorNegocio.Contratos
{
    public interface INegocioCertificadoDigital
    {
        void SalvarOuAtualizar(CertificadoDigital certificadoDigital);
        IEnumerable<CertificadoDigital> Lista();
        void Deletar(CertificadoDigital certificadoDigital);
    }
}