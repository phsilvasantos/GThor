using System;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorioEntityFramework.Contratos
{
    public interface IRepositorioUsuario : 
        IRepositorioBase,
        IDaoBase<Usuario, int>, 
        IDisposable, 
        ISuporteSalvar<Usuario>,
        ISuporteDeletar<Usuario>
    {
        
    }
}