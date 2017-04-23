using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Veiculos;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    internal class NegocioVeiculo : INegocioVeiculo
    {
        private readonly IRepositorioVeiculo _repositorioVeiculo;

        public NegocioVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public void SalvarOuAtualizar(Veiculo veiculo)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioVeiculo.SetGThorContexto(contexto);
                _repositorioVeiculo.SalvarOuAtualizar(veiculo);
                _repositorioVeiculo.SalvarAlteracoes();
            }
        }

        public Veiculo CarregarPorId(int id)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioVeiculo.SetGThorContexto(contexto);
                return _repositorioVeiculo.CarregarPorId(id);
            }
        }

        public IEnumerable<Veiculo> Lista()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioVeiculo.SetGThorContexto(contexto);
                return _repositorioVeiculo.Lista();
            }
        }

        public void Deletar(Veiculo veiculo)
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioVeiculo.SetGThorContexto(contexto);
                _repositorioVeiculo.Deletar(veiculo);
                _repositorioVeiculo.SalvarAlteracoes();
            }
        }
    }
}