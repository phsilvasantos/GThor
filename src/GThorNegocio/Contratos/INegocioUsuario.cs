using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;

namespace GThorNegocio.Contratos
{
    public interface INegocioUsuario
    {
        IEnumerable<Usuario> Lista();
        void Deletar(Usuario usuario);
        void Salvar(Usuario usuario);
    }
}