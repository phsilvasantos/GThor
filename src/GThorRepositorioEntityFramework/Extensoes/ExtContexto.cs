using GThorFrameworkRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Contratos;

namespace GThorRepositorioEntityFramework.Extensoes
{
    public static class ExtContexto
    {
        public static void SetGThorContexto(this IDaoContexto repositorioBase, GThorContexto contexto)
        {
            var repositorio = (IRepositorioBase) repositorioBase;

            repositorio.GThorContexto = contexto;
        }

        public static void SalvarAlteracoes(this IDaoContexto repositorioBase)
        {
            var repositorio = (IRepositorioBase)repositorioBase;

            repositorio.SalvarAlteracoes();
        }
    }
}