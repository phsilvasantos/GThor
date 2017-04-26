using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes;

namespace GThorRepositorioNHibernate.Criadores
{
    public static class RepositorioCriador
    {
        public static IRepositorioUsuario CriaRepositorioUsuario()
        {
            return new RepositorioUsuario();
        }
    }
}