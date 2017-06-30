namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    // todo mapear 3
    public class MdfeValePedagio
    {
        public virtual int Id { get; set; }
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual string CnpjEmpresaFornecedora { get; set; } // 14
        public virtual string DocumentoUnicoResponsavelPagamento { get; set; } // 14
        public virtual string NumeroDoComprovanteCompra { get; set; } //  20 Numeros OK
        public virtual string Valor { get; set; } // 15,2
    }
}