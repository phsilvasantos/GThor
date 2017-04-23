using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dto;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioEmpresa :
        IDaoContexto,
        IDaoBase<Empresa, int>,
        ISuporteSalvar<Empresa>,
        ISuporteDeletar<Empresa>
    {
        IEnumerable<EmpresaDto> BuscarParaGridModel();
    }
}