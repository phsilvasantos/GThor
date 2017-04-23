using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Criadores;
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

        public Usuario CarregarPorId(int id)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioUsuario.SetGThorContexto(contexto);
                return _repositorioUsuario.CarregarPorId(id);
            }
        }

        public IEnumerable<Usuario> Lista()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioUsuario.SetGThorContexto(contexto);
                return _repositorioUsuario.Lista();
            }
        }

        public void Deletar(Usuario usuario)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioUsuario.SetGThorContexto(contexto);
                _repositorioUsuario.Deletar(usuario);
                _repositorioUsuario.SalvarAlteracoes();
            }
        }

        public void SalvarOuAtualizar(Usuario entity)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioUsuario.SetGThorContexto(contexto);
                _repositorioUsuario.SalvarOuAtualizar(entity);
                _repositorioUsuario.SalvarAlteracoes();
            }
        }
    }
}