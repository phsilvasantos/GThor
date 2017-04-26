using GThorFrameworkRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers.Contratos;

namespace GThorRepositorioNHibernate.Helpers.Ext
{
    public static class ExNHibernateHelper
    {
        public static void SetSession(this IRepositorioContexto repositorioBase, INHibernateHelper hibernateHelper)
        {
            var repositorio = (IRepositorioBase) repositorioBase;

            repositorio.Sessao = hibernateHelper.Sessao;
        }
    }
}