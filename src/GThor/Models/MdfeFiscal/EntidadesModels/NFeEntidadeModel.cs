using GThorFrameworkDominio.Dominios.Cidades;

namespace GThor.Models.MdfeFiscal.EntidadesModels
{
    public class NFeEntidadeModel : IDocumentoModel
    {
        public Cidade Cidade { get; set; }
        public string Chave { get; set; }
        public string CodigoBarras { get; set; }
    }
}