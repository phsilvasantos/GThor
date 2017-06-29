namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Seguro
{
    public class MdfeNumeroAverbacao
    {
        public virtual int Id { get; set; }
        public virtual MdfeSeguro Seguro { get; set; }
        public virtual string Averbacao { get; set; }
    }
}