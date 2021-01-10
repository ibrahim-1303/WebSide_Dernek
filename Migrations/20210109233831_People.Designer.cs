﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proje008.Models;

namespace Proje008.Migrations
{
    [DbContext(typeof(MojoDbContext))]
    [Migration("20210109233831_People")]
    partial class People
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Proje008.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("KullanıcıAdı")
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Sifre")
                        .HasColumnType("Varchar(10)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Proje008.Models.Anasayfa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnasayfaAciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnasayfaAciklama2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnasayfaAciklama3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnasayfaAciklama4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnasayfaBaslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnasayfaBaslik2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnasayfaBaslik3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnasayfaBaslik4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimYolu")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResimYolu1")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResimYolu2")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResimYolu3")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResimYolu4")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Anasayfas");
                });

            modelBuilder.Entity("Proje008.Models.Hakkimizda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimYolu")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Hakkimizdas");
                });

            modelBuilder.Entity("Proje008.Models.Hizmetlerimiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimYolu")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Hizmetlerimizs");
                });

            modelBuilder.Entity("Proje008.Models.NeSöylüyor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meslek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimYolu")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("NeSöylüyors");
                });

            modelBuilder.Entity("Proje008.Models.Projeler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kategori")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KategoriYili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimYolu")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResimYolu1")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResimYolu2")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Yer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projelers");
                });
#pragma warning restore 612, 618
        }
    }
}
