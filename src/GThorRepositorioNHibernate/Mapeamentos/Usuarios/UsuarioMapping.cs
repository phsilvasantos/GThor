using GThorFrameworkDominio.Dominios.Usuarios;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GThorRepositorioNHibernate.Mapeamentos.Usuarios
{
    public class UsuarioMapping : ClassMapping<Usuario>
    {
        public UsuarioMapping()
        {
            Table("usuario");

            Id(u => u.Id, m =>
            {
                m.Generator(new NativeGeneratorDef());
                m.Column("id");
            });

            Property(u => u.Login, m =>
            {
                m.Column("login");
                m.Length(20);
                m.NotNullable(true);
            });

            Property(u => u.Senha, m =>
            {
                m.Column("senha");
                m.Length(40);
                m.NotNullable(true);
            });
        }
    }
}