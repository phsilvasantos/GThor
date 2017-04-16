using GThorRepositorioEntityFramework.Contexto;

namespace GThorRepositorioEntityFramework.Contratos
{
    public interface IRepositorioBase
    {
        GThorContexto GThorContexto { get; set; }
        void SalvarAlteracoes();
    }
}