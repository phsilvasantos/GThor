using GThorFrameworkDominio.Base;

namespace GThorFrameworkDominio.Dominios.Usuarios
{
    public class Usuario : EntidadeDominio
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }

        protected override int IdUnico => Id;
    }
}