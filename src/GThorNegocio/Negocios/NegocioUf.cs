using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Uf> ListaParaComboBox()
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