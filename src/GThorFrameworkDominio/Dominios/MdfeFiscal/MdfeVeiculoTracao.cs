﻿using GThorFrameworkDominio.Dominios.Pessoas;
using GThorFrameworkDominio.Dominios.Veiculos;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    // todo mapear 5
    public class MdfeVeiculoTracao
    {
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual Pessoa Proprietario { get; set; }
    }
}