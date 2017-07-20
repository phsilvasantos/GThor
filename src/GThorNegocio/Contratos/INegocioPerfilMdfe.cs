using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioPerfilMdfe :
        INegocioSalvar<PerfilMdfe>,
        INegocioDeletar<PerfilMdfe>,
        INegocioSuporteGridModel<PerfilMdfeDto>,
        INegocioBase<PerfilMdfe, int>
    {
        IEnumerable<PerfilMdfeDto> BuscarParaComboBox();
    }
}