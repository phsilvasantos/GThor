using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class Mdfe
    {
        public virtual int Id { get; set; }
        public virtual int Serie { get; set; }
        public virtual long NumeroManifesto { get; set; }
        public virtual PerfilMdfe PerfilMdfe { get; set; }
        public virtual TipoEmitente TipoEmitente { get; set; }
        public virtual TipoTransportador TipoTransportador { get; set; }
        public virtual Modal Modal { get; set; }
        public virtual Uf UfCarregamento { get; set; }
        public virtual Uf UfDescarregamento { get; set; }
        public virtual string Rntrc { get; set; }
        public virtual string Observacao { get; set; }

        public virtual MdfeEmitente Emitente { get; set; }
        public virtual MdfeTotal Total { get; set; } 
        public virtual MdfeVeiculoTracao VeiculoTracao { get; set; } 
        public virtual MdfeEmissaoFinalizada Finalizada { get; set; }

        public virtual List<MdfeMunicipioCarregamento> MuniciposDeCarregamento { get; set; }
        public virtual List<MdfePercurso> Percurso { get; set; }
        public virtual List<MdfeMunicipioDescarga> Descarga { get; set; }
        public virtual List<MdfeSeguro> Seguro { get; set; }
        public virtual List<MdfeCiot> Ciot { get; set; } 
        public virtual List<MdfeValePedagio> ValePediagio { get; set; } 
        public virtual List<MdfeContratante> Contratante { get; set; } 
        public virtual List<MdfeCondutor> Condutor { get; set; } 
    }
}