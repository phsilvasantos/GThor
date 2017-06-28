using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dto.DocumentosMdfe;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioDocumentoMdfe :
        INegocioBase<DocumentoMdfe, int>,
        INegocioSalvar<DocumentoMdfe>,
        INegocioDeletar<DocumentoMdfe>
    {
        IEnumerable<DocumentoMdfeComboBoxDto> BuscarParaComboBox();
    }
}