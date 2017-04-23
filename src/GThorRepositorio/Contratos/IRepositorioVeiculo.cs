using GThorFrameworkDominio.Dominios.Veiculos;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioVeiculo :
        IDaoContexto,
        IDaoBase<Veiculo, int>,
        ISuporteSalvar<Veiculo>,
        ISuporteDeletar<Veiculo>
    {
        
    }
}