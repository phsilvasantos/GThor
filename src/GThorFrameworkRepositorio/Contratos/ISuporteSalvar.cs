namespace GThorFrameworkRepositorio.Contratos
{
    public interface ISuporteSalvar<in TEntity>
    {
        void SalvarOuAtualizar(TEntity entity);
    }
}