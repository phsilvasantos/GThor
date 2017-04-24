using System.Collections.Generic;

namespace GThorFrameworkRepositorio.Contratos
{
    public interface IRepositorioBase<out TEntity, in TId>
    {
        TEntity CarregarPorId(TId id);

        IEnumerable<TEntity> Lista();
    }
}