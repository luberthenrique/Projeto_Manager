﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Manager.api.Data;

namespace Projeto_Manager.api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("Projeto_Manager.api.Model.Dado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHora");

                    b.Property<string>("Descricao");

                    b.Property<string>("Left");

                    b.Property<string>("Right");

                    b.Property<string>("Situacao");

                    b.HasKey("Id");

                    b.ToTable("Dado");
                });
#pragma warning restore 612, 618
        }
    }
}
