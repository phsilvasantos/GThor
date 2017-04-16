using System.Collections.Generic;

namespace GThorFrameworkRepositorio.Contratos
{
    public interface IDaoBase<TEntity, in TId>
    {
        TEntity CarregarPorId(TId id);

        IList<TEntity> Lista();
    }
}