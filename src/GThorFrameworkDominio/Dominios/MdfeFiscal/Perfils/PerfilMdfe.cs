using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Veiculos;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils
{
    public class PerfilMdfe
    {
        public virtual int Id { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual DocumentoMdfe DocumentoMdfe  { get; set; }
        public virtual CertificadoDigital CertificadoDigital { get; set; }
        public virtual Uf UfCarregamento { get; set; }
        public virtual Uf UfDescarregamento { get; set; }
        public virtual Veiculo VeiculoTracao { get; set; }
        public virtual string Observacao { get; set; }

    }
}