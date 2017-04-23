using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Contexto.Contratos;

namespace GThorRepositorioEntityFramework.Criadores
{
    public static class ContextoCriador
    {
        public static IGThorContexto CriaContexto()
        {
            return new GThorContexto();
        }
    }
}