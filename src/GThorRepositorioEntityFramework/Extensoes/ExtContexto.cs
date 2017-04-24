using GThorFrameworkRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto.Contratos;
using GThorRepositorioEntityFramework.Contratos;

namespace GThorRepositorioEntityFramework.Extensoes
{
    public static class ExtContexto
    {
        public static void SetGThorContexto(this IRepositorioContexto repositorioBase, IGThorContexto contexto)
        {
            var repositorio = (IRepositorioBase) repositorioBase;

            repositorio.GThorContexto = contexto;
        }

        public static void SalvarAlteracoes(this IRepositorioContexto repositorioBase)
        {
            var repositorio = (IRepositorioBase)repositorioBase;

            repositorio.SalvarAlteracoes();
        }
    }
}