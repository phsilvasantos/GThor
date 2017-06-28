using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dto.CertificadosDigitais;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioCertificadoDigital :
        IRepositorioContexto,
        IRepositorioBase<CertificadoDigital, int>,
        ISuporteSalvar<CertificadoDigital>,
        ISuporteDeletar<CertificadoDigital>
    {
        IEnumerable<CertificadoDigitalComboBoxDto> BuscarParaComboBox();
    }
}