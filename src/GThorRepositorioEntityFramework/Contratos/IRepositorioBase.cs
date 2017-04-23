using GThorRepositorioEntityFramework.Contexto.Contratos;

namespace GThorRepositorioEntityFramework.Contratos
{
    public interface IRepositorioBase
    {
        IGThorContexto GThorContexto { get; set; }
        void SalvarAlteracoes();
    }
}