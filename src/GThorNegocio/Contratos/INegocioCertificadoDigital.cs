using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dto.CertificadosDigitais;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioCertificadoDigital : 
        INegocioBase<CertificadoDigital, int>,
        INegocioSalvar<CertificadoDigital>,
        INegocioDeletar<CertificadoDigital>
    {
        IEnumerable<CertificadoDigitalComboBoxDto> BuscarParaComboBox();
    }
}