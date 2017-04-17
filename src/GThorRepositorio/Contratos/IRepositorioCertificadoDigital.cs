using System;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioCertificadoDigital :
        IDaoContexto,
        IDaoBase<CertificadoDigital, int>,
        IDisposable,
        ISuporteSalvar<CertificadoDigital>,
        ISuporteDeletar<CertificadoDigital>
    {
        
    }
}