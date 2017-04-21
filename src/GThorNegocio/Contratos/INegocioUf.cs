using System.Collections.Generic;
using GThorNegocio.Dto;

namespace GThorNegocio.Contratos
{
    public interface INegocioUf
    {
        IEnumerable<UfComboBoxDto> ListaParaComboBox();
    }
}