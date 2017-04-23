using GThorFrameworkDominio.Dominios.Certificados;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioCertificadoDigital : 
        INegocioBase<CertificadoDigital, int>,
        INegocioSalvar<CertificadoDigital>,
        INegocioDeletar<CertificadoDigital>
    {
    }
}