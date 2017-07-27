using GThorFrameworkDominio.Dominios.Cidades;

namespace GThor.Models.MdfeFiscal.EntidadesModels
{
    public interface IDocumentoModel
    {
        Cidade Cidade { get; set; }
        string Chave { get; set; }
        string CodigoBarras { get; set; }
    }
}