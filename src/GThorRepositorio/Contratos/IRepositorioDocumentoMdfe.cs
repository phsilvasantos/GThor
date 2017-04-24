using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioDocumentoMdfe :
        IRepositorioContexto,
        IRepositorioBase<DocumentoMdfe, int>,
        ISuporteSalvar<DocumentoMdfe>,
        ISuporteDeletar<DocumentoMdfe>
    {
        
    }
}