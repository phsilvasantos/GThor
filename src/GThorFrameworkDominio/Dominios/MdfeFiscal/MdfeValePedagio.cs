namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeValePedagio
    {
        public virtual int Id { get; set; }
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual string CnpjEmpresaFornecedora { get; set; } 
        public virtual string DocumentoUnicoResponsavelPagamento { get; set; } 
        public virtual string NumeroDoComprovanteCompra { get; set; } 
        public virtual decimal Valor { get; set; } 
    }
}