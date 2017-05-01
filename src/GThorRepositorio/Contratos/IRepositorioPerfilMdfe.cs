using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;
using GThorFrameworkDominio.Dto;
using GThorFrameworkRepositorio.Contratos;
using GThorRepositorio.Contratos.Base;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioPerfilMdfe : 
        IRepositorioContexto,
        IRepositorioBase<PerfilMdfe, int>,
        ISuporteSalvar<PerfilMdfe>,
        ISuporteDeletar<PerfilMdfe>,
        ISuporteGridModel<PerfilMdfeDto>
    {
        
    }
}