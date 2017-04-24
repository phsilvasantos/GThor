using GThorFrameworkDominio.Dominios.Veiculos;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioVeiculo :
        IRepositorioContexto,
        IRepositorioBase<Veiculo, int>,
        ISuporteSalvar<Veiculo>,
        ISuporteDeletar<Veiculo>
    {
        
    }
}