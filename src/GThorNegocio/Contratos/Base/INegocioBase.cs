using System.Collections.Generic;

namespace GThorNegocio.Contratos.Base
{
    public interface INegocioBase<out TEntity, in TId>
    {
        TEntity CarregarPorId(TId id);

        IEnumerable<TEntity> Lista();
    }
}