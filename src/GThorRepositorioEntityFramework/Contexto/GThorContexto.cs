using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dominios.EstadosUf;
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
        public DbSet<Uf> Uf { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<DocumentoMdfe> DocumentoMdfe { get; set; }
    }
}