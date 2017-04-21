using System.Collections.Generic;
using System.Linq;
using GThorNegocio.Contratos;
using GThorNegocio.Dto;
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

        public IEnumerable<UfComboBoxDto> ListaParaComboBox()
        {
            using (var contexto = new GThorContexto())
            {
                _repositorioUf.SetGThorContexto(contexto);
                var listaUfs = _repositorioUf.Lista();

                return listaUfs.Select(uf => new UfComboBoxDto
                    {
                        Id = uf.Id,
                        Nome = uf.Nome
                    })
                    .ToList();
            }
        }
    }
}