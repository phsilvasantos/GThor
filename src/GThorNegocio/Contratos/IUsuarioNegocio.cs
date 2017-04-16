using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;

namespace GThorNegocio.Contratos
{
    public interface IUsuarioNegocio
    {
        IEnumerable<Usuario> Lista();
        void Deletar(Usuario usuario);
    }
}