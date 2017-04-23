using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Criadores;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    internal class NegocioCidade : INegocioCidade
    {
        private readonly IRepositorioCidade _repositorioCidade;

        public NegocioCidade(IRepositorioCidade repositorioCidade)
        {
            _repositorioCidade = repositorioCidade;
        }

        public Cidade CarregarPorId(int id)
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioCidade.SetGThorContexto(contexto);
                return _repositorioCidade.CarregarPorId(id);
            }
        }

        public IEnumerable<Cidade> Lista()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioCidade.SetGThorContexto(contexto);
                return _repositorioCidade.Lista();
            }
        }
    }
}