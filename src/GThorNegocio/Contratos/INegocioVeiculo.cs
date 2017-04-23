using GThorFrameworkDominio.Dominios.Veiculos;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioVeiculo :
        INegocioBase<Veiculo, int>,
        INegocioSalvar<Veiculo>,
        INegocioDeletar<Veiculo>
    {
    }
}