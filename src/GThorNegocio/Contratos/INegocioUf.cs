using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorNegocio.Contratos
{
    public interface INegocioUf
    {
        IEnumerable<Uf> Lista();
    }
}