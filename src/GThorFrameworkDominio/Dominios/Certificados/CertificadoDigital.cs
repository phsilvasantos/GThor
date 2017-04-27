namespace GThorFrameworkDominio.Dominios.Certificados
{
    public class CertificadoDigital
    {
        public CertificadoDigital()
        {
            Tipo = TipoCertificado.A1Arquivo;
        }

        public virtual int Id { get; set; }

        public virtual string CaminhoCertificado { get; set; }

        public virtual string Serial { get; set; }

        public virtual TipoCertificado Tipo { get; set; }

        public virtual string Senha { get; set; }

        public virtual string Descricao { get; set; }
    }
}