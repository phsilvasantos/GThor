using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioEmpresa :
        INegocioBase<Empresa, int>,
        INegocioSalvar<Empresa>,
        INegocioDeletar<Empresa>
    {
        IEnumerable<EmpresaDto> BuscarParaGridModel();
    }
}