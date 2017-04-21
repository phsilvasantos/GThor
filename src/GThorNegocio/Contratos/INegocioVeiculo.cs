using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Veiculos;

namespace GThorNegocio.Contratos
{
    public interface INegocioVeiculo
    {
        void SalvarOuAtualizar(Veiculo veiculo);
        IEnumerable<Veiculo> Lista();
        void Deletar(Veiculo veiculo);
    }
}