﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TFE_Khalifa_Sami_2021.DAL;

namespace TFE_Khalifa_Sami_2021.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TFE_Khalifa_Sami_2021.Models.Contract", b =>
                {
                    b.Property<int>("IdContract")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BeginContract")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndContract")
                        .HasColumnType("datetime2");

                    b.Property<float>("GuaranteeAmount")
                        .HasColumnType("real");

                    b.Property<int>("IdProperty")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SignatureDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdContract");

                    b.HasIndex("IdProperty");

                    b.HasIndex("IdUser");

                    b.ToTable("CommandContract");
                });

            modelBuilder.Entity("TFE_Khalifa_Sami_2021.Models.Property", b =>
                {
                    b.Property<int>("IdProperty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("FixedChargesCost")
                        .HasColumnType("real");

                    b.Property<float?>("RentCost")
                        .HasColumnType("real");

                    b.Property<int?>("UserIdUser")
                        .HasColumnType("int");

                    b.HasKey("IdProperty");

                    b.HasIndex("UserIdUser");

                    b.ToTable("CommandProperty");
                });

            modelBuilder.Entity("TFE_Khalifa_Sami_2021.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalRegister")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("CommandUser");
                });

            modelBuilder.Entity("TFE_Khalifa_Sami_2021.Models.Contract", b =>
                {
                    b.HasOne("TFE_Khalifa_Sami_2021.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFE_Khalifa_Sami_2021.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TFE_Khalifa_Sami_2021.Models.Property", b =>
                {
                    b.HasOne("TFE_Khalifa_Sami_2021.Models.User", null)
                        .WithMany("PropertiesList")
                        .HasForeignKey("UserIdUser");
                });

            modelBuilder.Entity("TFE_Khalifa_Sami_2021.Models.User", b =>
                {
                    b.Navigation("PropertiesList");
                });
#pragma warning restore 612, 618
        }
    }
}
