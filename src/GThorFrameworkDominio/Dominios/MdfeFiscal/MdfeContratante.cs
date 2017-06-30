namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeContratante
    {
        public virtual int Id { get; set; }
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual string DocumentoUnico { get; set; } 
    }
}