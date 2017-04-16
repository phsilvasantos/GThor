namespace GThorFrameworkRepositorio.Contratos
{
    public interface ISuporteDeletar<in TEntity>
    {
        void Deletar(TEntity entity);
    }
}