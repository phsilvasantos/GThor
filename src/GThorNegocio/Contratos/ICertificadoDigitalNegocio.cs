using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;

namespace GThorNegocio.Contratos
{
    public interface ICertificadoDigitalNegocio
    {
        IEnumerable<CertificadoDigital> Lista();
        void Deletar(CertificadoDigital certificadoDigital);
    }
}