using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dto;
using GThorFrameworkRepositorio.Contratos;
using GThorRepositorio.Contratos.Base;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioEmpresa :
        IRepositorioContexto,
        IRepositorioBase<Empresa, int>,
        ISuporteSalvar<Empresa>,
        ISuporteDeletar<Empresa>,
        ISuporteGridModel<EmpresaDto>
    {
    }
}