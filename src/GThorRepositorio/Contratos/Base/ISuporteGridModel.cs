using System.Collections.Generic;

namespace GThorRepositorio.Contratos.Base
{
    public interface ISuporteGridModel<out TEntity>
    {
        IEnumerable<TEntity> BuscarParaGridModel();
    }
}