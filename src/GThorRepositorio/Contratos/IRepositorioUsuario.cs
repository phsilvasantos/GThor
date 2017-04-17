using System;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioUsuario : 
        IDaoContexto,
        IDaoBase<Usuario, int>, 
        IDisposable, 
        ISuporteSalvar<Usuario>,
        ISuporteDeletar<Usuario>
    {
        
    }
}