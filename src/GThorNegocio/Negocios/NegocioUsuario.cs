using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers;

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
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioUsuario.Sessao = instancia.Sessao;
                return _repositorioUsuario.CarregarPorId(id);
            }
        }

        public IEnumerable<Usuario> Lista()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioUsuario.Sessao = instancia.Sessao;
                return _repositorioUsuario.Lista();
            }
        }

        public void Deletar(Usuario usuario)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioUsuario.Sessao = instancia.Sessao;
                _repositorioUsuario.Deletar(usuario);
                
                instancia.SalvarAlteracoes();
            }
        }

        public void SalvarOuAtualizar(Usuario entity)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioUsuario.Sessao = instancia.Sessao;
                _repositorioUsuario.SalvarOuAtualizar(entity);
                
                instancia.SalvarAlteracoes();
            }
        }
    }
}