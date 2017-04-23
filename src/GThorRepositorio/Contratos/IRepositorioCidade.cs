using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioCidade :
        IDaoContexto,
        IDaoBase<Cidade, int>
    {
        
    }
}