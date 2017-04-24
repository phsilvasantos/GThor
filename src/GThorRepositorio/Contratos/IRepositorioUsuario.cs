using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioUsuario : 
        IRepositorioContexto,
        IRepositorioBase<Usuario, int>, 
        ISuporteSalvar<Usuario>,
        ISuporteDeletar<Usuario>
    {
        
    }
}