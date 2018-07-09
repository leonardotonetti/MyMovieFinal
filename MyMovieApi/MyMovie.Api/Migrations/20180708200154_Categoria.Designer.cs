﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMovie.Api.Data;

namespace MyMovie.Api.Migrations
{
    [DbContext(typeof(MyMovieContext))]
    [Migration("20180708200154_Categoria")]
    partial class Categoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyMovie.Api.Data.Categoria.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlteracaoUsuarioId");

                    b.Property<bool>("Ativo");

                    b.Property<int>("CadastroUsuarioId");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("CategoriaId");

                    b.HasIndex("AlteracaoUsuarioId");

                    b.HasIndex("CadastroUsuarioId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("MyMovie.Api.Data.Usuario.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MyMovie.Api.Data.Categoria.Categoria", b =>
                {
                    b.HasOne("MyMovie.Api.Data.Usuario.Usuario", "AlteracaoUsuario")
                        .WithMany("Alteracao")
                        .HasForeignKey("AlteracaoUsuarioId");

                    b.HasOne("MyMovie.Api.Data.Usuario.Usuario", "CadastroUsuario")
                        .WithMany("Cadastro")
                        .HasForeignKey("CadastroUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}