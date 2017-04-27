using GThorFrameworkDominio.Dominios.Certificados;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GThorRepositorioNHibernate.Mapeamentos.Certificados
{
    public class CertificadoDigitalMapping : ClassMapping<CertificadoDigital>
    {
        public CertificadoDigitalMapping()
        {
            Table("certificadoDigital");

            Id(u => u.Id, m =>
            {
                m.Generator(new NativeGeneratorDef());
                m.Column("id");
            });

            Property(u => u.CaminhoCertificado, m =>
            {
                m.Column("caminhoCertificado");
                m.Length(255);
                m.NotNullable(true);
            });

            Property(u => u.Serial, m =>
            {
                m.Column("serial");
                m.Length(255);
                m.NotNullable(true);
            });

            Property(u => u.Tipo, m =>
            {
                m.Column("tipo");
                m.NotNullable(true);
            });

            Property(u => u.Senha, m =>
            {
                m.Column("senha");
                m.Length(255);
                m.NotNullable(true);
            });

            Property(u => u.Descricao, m =>
            {
                m.Column("descricao");
                m.Length(100);
                m.NotNullable(true);
            });
        }
    }
}