using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkRepositorio.Contratos;
using NHibernate;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioUsuario : 
        IRepositorioContexto,
        IRepositorioBase<Usuario, int>, 
        ISuporteSalvar<Usuario>,
        ISuporteDeletar<Usuario>
    {
        ISession Sessao { get; set; }
    }
}