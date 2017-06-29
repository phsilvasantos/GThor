using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class Mdfe
    {
        public int Id { get; set; }
        public int Serie { get; set; }
        public string NumeroManifesto { get; set; }
        public PerfilMdfe PerfilMdfe { get; set; }
        public TipoEmitente TipoEmitente { get; set; }
        public TipoTransportador TipoTransportador { get; set; }
        public Modal Modal { get; set; }
        public Uf UfCarregamento { get; set; }
        public Uf UfDescarregamento { get; set; }
        public string Rntrc { get; set; }
        public string Observacao { get; set; }
    }
}