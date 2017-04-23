using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    internal class NegocioUsuario : INegocioUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public NegocioUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public IEnumerable<Usuario> Lista()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUsuario.SetGThorContexto(contexto);
                return _repositorioUsuario.Lista();
            }
        }

        public void Deletar(Usuario usuario)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUsuario.SetGThorContexto(contexto);
                _repositorioUsuario.Deletar(usuario);
                _repositorioUsuario.SalvarAlteracoes();
            }
        }

        public void Salvar(Usuario usuario)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUsuario.SetGThorContexto(contexto);
                _repositorioUsuario.SalvarOuAtualizar(usuario);
                _repositorioUsuario.SalvarAlteracoes();
            }
        }
    }
}