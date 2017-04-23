using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioEmpresa :
        IDaoContexto,
        IDaoBase<Empresa, int>,
        ISuporteSalvar<Empresa>,
        ISuporteDeletar<Empresa>
    {
        
    }
}