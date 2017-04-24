using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioUf :
        IRepositorioContexto,
        IRepositorioBase<Uf, int>
    {
        
    }
}