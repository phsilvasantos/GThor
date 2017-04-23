using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioUsuario : 
        IDaoContexto,
        IDaoBase<Usuario, int>, 
        ISuporteSalvar<Usuario>,
        ISuporteDeletar<Usuario>
    {
        
    }
}