using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers;
using GThorRepositorioNHibernate.Helpers.Ext;

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
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioPerfilMdfe.SetNHibernateHelper(instancia);
                _repositorioPerfilMdfe.SalvarOuAtualizar(entity);
            }
        }

        public void Deletar(PerfilMdfe entity)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioPerfilMdfe.SetNHibernateHelper(instancia);
                _repositorioPerfilMdfe.Deletar(entity);
            }
        }

        public IEnumerable<PerfilMdfeDto> BuscarParaGridModel()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioPerfilMdfe.SetNHibernateHelper(instancia);
                return _repositorioPerfilMdfe.BuscarParaGridModel();
            }
        }

        public PerfilMdfe CarregarPorId(int id)
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioPerfilMdfe.SetNHibernateHelper(instancia);
                return _repositorioPerfilMdfe.CarregarPorId(id);
            }
        }

        public IEnumerable<PerfilMdfe> Lista()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioPerfilMdfe.SetNHibernateHelper(instancia);
                return _repositorioPerfilMdfe.Lista();
            }
        }
    }
}