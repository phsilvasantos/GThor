using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Extensoes;

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
            using (var contexto = new GThorContexto())
            {
                _repositorioUf.SetGThorContexto(contexto);
                var uf = _repositorioUf.CarregarPorId(id);

                return uf;
            }
        }

        public IEnumerable<Uf> Lista()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUf.SetGThorContexto(contexto);
                var listaUfs = _repositorioUf.Lista();

                return listaUfs;
            }
        }
    }
}