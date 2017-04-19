using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace GThorRepositorioEntityFramework.Contexto
{
    public class GThorContexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=gthor;Username=postgres;Password=root");
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CertificadoDigital> CertificadoDigital { get; set; }
    }
}