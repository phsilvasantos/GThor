namespace GThorNegocio.Contratos.Base
{
    public interface INegocioDeletar<in TEntity>
    {
        void Deletar(TEntity entity);
    }
}