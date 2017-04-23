using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioDocumentoMdfe :
        IDaoContexto,
        IDaoBase<DocumentoMdfe, int>,
        ISuporteSalvar<DocumentoMdfe>,
        ISuporteDeletar<DocumentoMdfe>
    {
        
    }
}