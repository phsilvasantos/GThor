using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkDominio.Dominios.Veiculos;
using GThorRepositorioEntityFramework.Log;
using Microsoft.EntityFrameworkCore;

namespace GThorRepositorioEntityFramework.Contexto
{
    public class GThorContexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=gthor;Username=postgres;Password=root");

        #if DEBUG
            optionsBuilder.UseLoggerFactory(new EfLoggerFactory());
        #endif

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CertificadoDigital> CertificadosDigitais { get; set; }
        public DbSet<Uf> Ufs { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<DocumentoMdfe> DocumentosMdfe { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}