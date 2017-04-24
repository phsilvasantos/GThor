using System.Collections.Generic;

namespace GThorNegocio.Contratos.Base
{
    public interface INegocioSuporteGridModel<out TEntity>
    {
        IEnumerable<TEntity> BuscarParaGridModel();
    }
}