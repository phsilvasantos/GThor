using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dominios.Empresas;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils
{
    public class PerfilMdfe
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual DocumentoMdfe DocumentoMdfe  { get; set; }
        public virtual CertificadoDigital CertificadoDigital { get; set; }

    }
}