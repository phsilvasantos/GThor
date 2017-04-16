using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorNegocio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Contratos;

namespace GThorNegocio.Negocios
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public UsuarioNegocio(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public IEnumerable<Usuario> Lista()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUsuario.GThorContexto = contexto;
                return _repositorioUsuario.Lista();
            }
        }

        public void Deletar(Usuario usuario)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUsuario.GThorContexto = contexto;
                _repositorioUsuario.Deletar(usuario);
                _repositorioUsuario.SalvarAlteracoes();
            }
        }

        public void Salvar(Usuario usuario)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUsuario.GThorContexto = contexto;
                _repositorioUsuario.SalvarOuAtualizar(usuario);
                _repositorioUsuario.SalvarAlteracoes();
            }
        }
    }
}