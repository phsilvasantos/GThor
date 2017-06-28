using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dto.DocumentosMdfe;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioDocumentoMdfe :
        IRepositorioContexto,
        IRepositorioBase<DocumentoMdfe, int>,
        ISuporteSalvar<DocumentoMdfe>,
        ISuporteDeletar<DocumentoMdfe>
    {
        IEnumerable<DocumentoMdfeComboBoxDto> BuscarParaComboBox();
    }
}