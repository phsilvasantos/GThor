namespace GThorNegocio.Contratos.Base
{
    public interface INegocioSalvar<in TEntity>
    {
        void SalvarOuAtualizar(TEntity entity);
    }
}