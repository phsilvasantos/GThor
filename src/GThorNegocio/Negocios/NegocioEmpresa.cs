using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Criadores;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    internal class NegocioEmpresa : INegocioEmpresa
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;

        public NegocioEmpresa(IRepositorioEmpresa repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;
        }

        public Empresa CarregarPorId(int id)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioEmpresa.SetGThorContexto(contexto);
                return _repositorioEmpresa.CarregarPorId(id);
            }
        }

        public IEnumerable<Empresa> Lista()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioEmpresa.SetGThorContexto(contexto);
                return _repositorioEmpresa.Lista();
            }
        }

        public void SalvarOuAtualizar(Empresa entity)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioEmpresa.SetGThorContexto(contexto);
                _repositorioEmpresa.SalvarOuAtualizar(entity);
                _repositorioEmpresa.SalvarAlteracoes();
            }
        }

        public void Deletar(Empresa entity)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioEmpresa.SetGThorContexto(contexto);
                _repositorioEmpresa.Deletar(entity);
                _repositorioEmpresa.SalvarAlteracoes();
            }
        }
    }
}