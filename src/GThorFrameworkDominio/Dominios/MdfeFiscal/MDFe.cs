﻿using System.Collections.Generic;
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

        public virtual List<MdfeMunicipioCarregamento> MuniciposDeCarregamento { get; set; }
        public virtual List<MdfePercurso> Percurso { get; set; }
    }
}