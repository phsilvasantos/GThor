using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Contratos;

namespace GThorRepositorioEntityFramework.Implementacao.Base
{
    public class RepositorioBase : IRepositorioBase
    {
        public GThorContexto GThorContexto { get; set; }

        protected RepositorioBase()
        {
        }

        public void SalvarAlteracoes()
        {
            GThorContexto.SaveChanges();
        }
    }
}