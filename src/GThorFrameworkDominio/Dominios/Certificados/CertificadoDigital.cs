namespace GThorFrameworkDominio.Dominios.Certificados
{
    public class CertificadoDigital
    {
        public int Id { get; set; }
        public string CaminhoCertificado { get; set; }
        public string Serial { get; set; }
        public TipoCertificado Tipo { get; set; }
    }
}