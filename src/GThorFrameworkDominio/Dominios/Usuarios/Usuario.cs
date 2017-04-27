namespace GThorFrameworkDominio.Dominios.Usuarios
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }
    }
}