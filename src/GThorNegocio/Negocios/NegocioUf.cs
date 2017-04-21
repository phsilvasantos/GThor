using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    public class NegocioUf : INegocioUf
    {
        private readonly IRepositorioUf _repositorioUf;

        public NegocioUf(IRepositorioUf repositorioUf)
        {
            _repositorioUf = repositorioUf;
        }

        public IEnumerable<Uf> Lista()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUf.SetGThorContexto(contexto);
                return _repositorioUf.Lista();
            }
        }
    }
}