using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioCertificadoDigital :
        IDaoContexto,
        IDaoBase<CertificadoDigital, int>,
        ISuporteSalvar<CertificadoDigital>,
        ISuporteDeletar<CertificadoDigital>
    {
        
    }
}