using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers;
using GThorRepositorioNHibernate.Helpers.Ext;

namespace GThorNegocio.Negocios
{
    internal class NegocioUf : INegocioUf
    {
        private readonly IRepositorioUf _repositorioUf;

        public NegocioUf(IRepositorioUf repositorioUf)
        {
            _repositorioUf = repositorioUf;
        }

        public Uf CarregarPorId(int id)
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioUf.SetNHibernateHelper(instancia);
                var uf = _repositorioUf.CarregarPorId(id);

                return uf;
            }
        }

        public IEnumerable<Uf> Lista()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioUf.SetNHibernateHelper(instancia);
                var listaUfs = _repositorioUf.Lista();

                return listaUfs;
            }
        }
    }
}