using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GThorRepositorioEntityFramework.Contexto;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;

namespace GThorRepositorioEntityFramework.Migrations
{
    [DbContext(typeof(GThorContexto))]
    [Migration("20170420221809_CriaTableaDocumentoMdfe")]
    partial class CriaTableaDocumentoMdfe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Certificados.CertificadoDigital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("CaminhoCertificado")
                        .IsRequired()
                        .HasColumnName("caminhoCertificado")
                        .HasMaxLength(255);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(255);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("senha")
                        .HasMaxLength(255);

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnName("serial")
                        .HasMaxLength(255);

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("certificadoDigital");
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Cidades.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CodigoIbge")
                        .HasColumnName("codigoIbge");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(100);

                    b.Property<int>("UfId")
                        .HasColumnName("ufId");

                    b.HasKey("Id");

                    b.HasIndex("UfId");

                    b.ToTable("cidade");
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.DocumentoMdfe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AmbienteSefaz")
                        .HasColumnName("ambienteSefaz");

                    b.Property<short>("Serie")
                        .HasColumnName("serie");

                    b.Property<long>("UltimoNumeroUsado")
                        .HasColumnName("ultimoNumeroUsado");

                    b.HasKey("Id");

                    b.ToTable("documentoMdfe");
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.EstadosUf.Uf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<byte>("CodigoIbge")
                        .HasColumnName("codigoIbge");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(100);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("sigla")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("uf");
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("login")
                        .HasMaxLength(20);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("senha")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Cidades.Cidade", b =>
                {
                    b.HasOne("GThorFrameworkDominio.Dominios.EstadosUf.Uf", "Uf")
                        .WithMany()
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
