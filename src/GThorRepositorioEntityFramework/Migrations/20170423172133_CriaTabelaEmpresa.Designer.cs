using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GThorRepositorioEntityFramework.Contexto;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;
using GThorFrameworkDominio.Dominios.Veiculos.Flags;

namespace GThorRepositorioEntityFramework.Migrations
{
    [DbContext(typeof(GThorContexto))]
    [Migration("20170423172133_CriaTabelaEmpresa")]
    partial class CriaTabelaEmpresa
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
                        .HasMaxLength(100);

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

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(100);

                    b.Property<short>("Serie")
                        .HasColumnName("serie");

                    b.Property<long>("UltimoNumeroUsado")
                        .HasColumnName("ultimoNumeroUsado");

                    b.HasKey("Id");

                    b.ToTable("documentoMdfe");
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Empresas.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("bairro")
                        .HasMaxLength(60);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("cep")
                        .HasMaxLength(8);

                    b.Property<int>("CidadeId")
                        .HasColumnName("cidadeId");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("cnpj")
                        .HasMaxLength(14);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnName("complemento")
                        .HasMaxLength(60);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(255);

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnName("inscricaoEstadual")
                        .HasMaxLength(30);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("logradouro")
                        .HasMaxLength(255);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("nomeFantasia")
                        .HasMaxLength(255);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("numero")
                        .HasMaxLength(60);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnName("razaoSocial")
                        .HasMaxLength(255);

                    b.Property<string>("Rntrc")
                        .IsRequired()
                        .HasColumnName("rntrc")
                        .HasMaxLength(8);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("telefone")
                        .HasMaxLength(11);

                    b.Property<int>("UfId")
                        .HasColumnName("ufId");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("UfId");

                    b.ToTable("empresa");
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

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Veiculos.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CapacidadeEmKg")
                        .HasColumnName("capacidadeEmKg");

                    b.Property<short>("CapacidadeEmM3")
                        .HasColumnName("capacidadeEmM3");

                    b.Property<string>("CodigoInterno")
                        .IsRequired()
                        .HasColumnName("codigoInterno")
                        .HasMaxLength(10);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(100);

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnName("placa")
                        .HasMaxLength(7);

                    b.Property<string>("Renavam")
                        .IsRequired()
                        .HasColumnName("renavam")
                        .HasMaxLength(11);

                    b.Property<int>("TaraEmKg")
                        .HasColumnName("taraEmKg");

                    b.Property<int>("TipoCarroceria")
                        .HasColumnName("tipoCarroceria");

                    b.Property<int>("TipoRodado")
                        .HasColumnName("tipoRodado");

                    b.Property<int>("UfId")
                        .HasColumnName("ufId");

                    b.HasKey("Id");

                    b.HasIndex("UfId");

                    b.ToTable("veiculo");
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Cidades.Cidade", b =>
                {
                    b.HasOne("GThorFrameworkDominio.Dominios.EstadosUf.Uf", "Uf")
                        .WithMany()
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Empresas.Empresa", b =>
                {
                    b.HasOne("GThorFrameworkDominio.Dominios.Cidades.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GThorFrameworkDominio.Dominios.EstadosUf.Uf", "Uf")
                        .WithMany()
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GThorFrameworkDominio.Dominios.Veiculos.Veiculo", b =>
                {
                    b.HasOne("GThorFrameworkDominio.Dominios.EstadosUf.Uf", "Uf")
                        .WithMany()
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
