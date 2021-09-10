﻿// <auto-generated />
using System;
using DisneyCodeFirst.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DisneyCodeFirst.Migrations
{
    [DbContext(typeof(DisneyContext))]
    [Migration("20210905230451_Tercera")]
    partial class Tercera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DisneyCodeFirst.Entities.Genero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreGenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("DisneyCodeFirst.Entities.PeliculaOSerie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroID")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("GeneroID");

                    b.ToTable("PeliculaOSerie");
                });

            modelBuilder.Entity("DisneyCodeFirst.Entities.Personaje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Personaje");
                });

            modelBuilder.Entity("DisneyCodeFirst.Entities.User", b =>
                {
                    b.Property<string>("UserNameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserNameId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PeliculaOSeriePersonaje", b =>
                {
                    b.Property<int>("PeliculaOSeriesID")
                        .HasColumnType("int");

                    b.Property<int>("personajeID")
                        .HasColumnType("int");

                    b.HasKey("PeliculaOSeriesID", "personajeID");

                    b.HasIndex("personajeID");

                    b.ToTable("PeliculaOSeriePersonaje");
                });

            modelBuilder.Entity("DisneyCodeFirst.Entities.PeliculaOSerie", b =>
                {
                    b.HasOne("DisneyCodeFirst.Entities.Genero", "Genero")
                        .WithMany("peliculaOSeries")
                        .HasForeignKey("GeneroID");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("PeliculaOSeriePersonaje", b =>
                {
                    b.HasOne("DisneyCodeFirst.Entities.PeliculaOSerie", null)
                        .WithMany()
                        .HasForeignKey("PeliculaOSeriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DisneyCodeFirst.Entities.Personaje", null)
                        .WithMany()
                        .HasForeignKey("personajeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DisneyCodeFirst.Entities.Genero", b =>
                {
                    b.Navigation("peliculaOSeries");
                });
#pragma warning restore 612, 618
        }
    }
}
