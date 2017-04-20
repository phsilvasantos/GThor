using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GThorRepositorioEntityFramework.Contexto;
using GThorFrameworkDominio.Dominios.Certificados;

namespace GThorRepositorioEntityFramework.Migrations
{
    [DbContext(typeof(GThorContexto))]
    [Migration("20170420001945_CriaTabelaUsuarioECertificadoDigital")]
    partial class CriaTabelaUsuarioECertificadoDigital
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
        }
    }
}
