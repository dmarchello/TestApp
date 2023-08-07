﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApp.Infrastructure.Persistence;

#nullable disable

namespace TestApp.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestApp.Domain.Entities.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("X");

                    b.HasIndex("Y");

                    b.ToTable("Coordinate");
                });

            modelBuilder.Entity("TestApp.Domain.Entities.Rectangle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BottomRightId")
                        .HasColumnType("int");

                    b.Property<int>("TopLeftId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BottomRightId");

                    b.HasIndex("TopLeftId");

                    b.ToTable("Rectangles");
                });

            modelBuilder.Entity("TestApp.Domain.Entities.Rectangle", b =>
                {
                    b.HasOne("TestApp.Domain.Entities.Coordinate", "BottomRight")
                        .WithMany()
                        .HasForeignKey("BottomRightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestApp.Domain.Entities.Coordinate", "TopLeft")
                        .WithMany()
                        .HasForeignKey("TopLeftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BottomRight");

                    b.Navigation("TopLeft");
                });
#pragma warning restore 612, 618
        }
    }
}
