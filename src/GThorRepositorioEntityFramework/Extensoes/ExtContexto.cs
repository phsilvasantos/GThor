using GThorFrameworkRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto.Contratos;
using GThorRepositorioEntityFramework.Contratos;

namespace GThorRepositorioEntityFramework.Extensoes
{
    public static class ExtContexto
    {
        public static void SetGThorContexto(this IDaoContexto repositorioBase, IGThorContexto contexto)
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