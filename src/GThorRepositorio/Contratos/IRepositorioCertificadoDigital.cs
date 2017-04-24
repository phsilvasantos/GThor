using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioCertificadoDigital :
        IRepositorioContexto,
        IRepositorioBase<CertificadoDigital, int>,
        ISuporteSalvar<CertificadoDigital>,
        ISuporteDeletar<CertificadoDigital>
    {
        
    }
}