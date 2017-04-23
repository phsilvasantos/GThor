using System;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkDominio.Dominios.Veiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GThorRepositorioEntityFramework.Contexto.Contratos
{
    public interface IGThorContexto : IDisposable
    {
        DatabaseFacade Database { get; }

        void MigrarBancoDados();

        void SaveChangesThor();

        DbSet<Usuario> Usuarios { get; set; }
        DbSet<CertificadoDigital> CertificadosDigitais { get; set; }
        DbSet<Uf> Ufs { get; set; }
        DbSet<Cidade> Cidades { get; set; }
        DbSet<DocumentoMdfe> DocumentosMdfe { get; set; }
        DbSet<Veiculo> Veiculos { get; set; }
    }
}