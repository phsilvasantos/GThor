using GThorFrameworkDominio.Dominios.Usuarios;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioUsuario :
        INegocioBase<Usuario, int>,
        INegocioSalvar<Usuario>,
        INegocioDeletar<Usuario>
    {
        
    }
}