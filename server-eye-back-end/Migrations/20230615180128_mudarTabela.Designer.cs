﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server_eye_back_end.Data;

#nullable disable

namespace server_eye_back_end.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230615180128_mudarTabela")]
    partial class mudarTabela
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("server_eye_back_end.Models.Os", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Oss");
                });

            modelBuilder.Entity("server_eye_back_end.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OsId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("server_eye_back_end.Models.Server", b =>
                {
                    b.HasOne("server_eye_back_end.Models.Os", "Os")
                        .WithMany("Servers")
                        .HasForeignKey("OsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Os");
                });

            modelBuilder.Entity("server_eye_back_end.Models.Os", b =>
                {
                    b.Navigation("Servers");
                });
#pragma warning restore 612, 618
        }
    }
}
