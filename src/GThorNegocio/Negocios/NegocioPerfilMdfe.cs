using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;

namespace GThorNegocio.Negocios
{
    public class NegocioPerfilMdfe : INegocioPerfilMdfe
    {
        private readonly IRepositorioPerfilMdfe _repositorioPerfilMdfe;

        public NegocioPerfilMdfe(IRepositorioPerfilMdfe repositorioPerfilMdfe)
        {
            _repositorioPerfilMdfe = repositorioPerfilMdfe;
        }

        public void SalvarOuAtualizar(PerfilMdfe entity)
        {
            _repositorioPerfilMdfe.SalvarOuAtualizar(entity);
        }

        public void Deletar(PerfilMdfe entity)
        {
            _repositorioPerfilMdfe.Deletar(entity);
        }

        public IEnumerable<PerfilMdfeDto> BuscarParaGridModel()
        {
            return _repositorioPerfilMdfe.BuscarParaGridModel();
        }

        public PerfilMdfe CarregarPorId(int id)
        {
            return _repositorioPerfilMdfe.CarregarPorId(id);
        }

        public IEnumerable<PerfilMdfe> Lista()
        {
            return _repositorioPerfilMdfe.Lista();
        }
    }
}