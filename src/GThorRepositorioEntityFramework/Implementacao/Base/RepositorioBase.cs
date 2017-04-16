using GThorRepositorioEntityFramework.Contexto;

namespace GThorRepositorioEntityFramework.Implementacao.Base
{
    public class RepositorioBase
    {
        protected GThorContexto GThorContexto { get; }

        protected RepositorioBase()
        {
            GThorContexto = new GThorContexto();
        }

        public void SalvarAlteracoes()
        {
            GThorContexto.SaveChanges();
        }
    }
}