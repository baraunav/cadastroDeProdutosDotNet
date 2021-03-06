﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210103023530_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Domain.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TipoProdutoid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<float>("preco")
                        .HasColumnType("REAL");

                    b.Property<int>("quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("TipoProdutoid");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Domain.TipoProduto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("TipoProdutos");
                });

            modelBuilder.Entity("Domain.Produto", b =>
                {
                    b.HasOne("Domain.TipoProduto", "TipoProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("TipoProdutoid");

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("Domain.TipoProduto", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
