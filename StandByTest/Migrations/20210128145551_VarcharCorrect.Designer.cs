﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StandByTest.Database;

namespace StandByTest.Migrations
{
    [DbContext(typeof(StandByDbContext))]
    [Migration("20210128145551_VarcharCorrect")]
    partial class VarcharCorrect
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("StandByTest.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClienteId")
                        .UseIdentityColumn();

                    b.Property<decimal>("Capital")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("capital");

                    b.Property<string>("Classificacao")
                        .IsRequired()
                        .HasColumnType("char(1)")
                        .HasColumnName("classificacao");

                    b.Property<string>("Cnpj")
                        .HasColumnType("varchar(max)")
                        .HasColumnName("cnpj");

                    b.Property<DateTime>("DataFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_fundacao");

                    b.Property<bool>("Quarentena")
                        .HasColumnType("bit")
                        .HasColumnName("quarentena");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("razao_social");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status_cliente");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
