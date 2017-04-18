namespace GThorFrameworkDominio.Dominios.Certificados
{
    public class CertificadoDigital
    {
        public CertificadoDigital()
        {
            Tipo = TipoCertificado.A1Arquivo;
        }

        public int Id { get; set; }
        public string CaminhoCertificado { get; set; }
        public string Serial { get; set; }
        public TipoCertificado Tipo { get; set; }
        public string Senha { get; set; }
        public string Descricao { get; set; }
    }
}