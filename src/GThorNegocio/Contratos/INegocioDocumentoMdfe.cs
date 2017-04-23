using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioDocumentoMdfe :
        INegocioBase<DocumentoMdfe, int>,
        INegocioSalvar<DocumentoMdfe>,
        INegocioDeletar<DocumentoMdfe>
    {
        
    }
}