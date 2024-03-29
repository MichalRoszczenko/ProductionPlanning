﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Production.Infrastructure.Persistence;

#nullable disable

namespace Production.Infrastructure.Migrations
{
    [DbContext(typeof(ProductionDbContext))]
    [Migration("20230918125544_AddedInjectionMachineRestrictions")]
    partial class AddedInjectionMachineRestrictions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Production.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid>("InjectionMoldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InjectionMoldId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Production.Domain.Entities.InjectionMold", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Consumption")
                        .HasColumnType("decimal(4,2)");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId")
                        .IsUnique()
                        .HasFilter("[MaterialId] IS NOT NULL");

                    b.ToTable("InjectionMolds");
                });

            modelBuilder.Entity("Production.Domain.Entities.InjectionMoldingMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("Tonnage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InjectionMoldingMachines");
                });

            modelBuilder.Entity("Production.Domain.Entities.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Production.Domain.Entities.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InjectionMoldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InjectionMoldingMachineId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionTimeInHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InjectionMoldId");

                    b.HasIndex("InjectionMoldingMachineId");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("Production.Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("Production.Domain.Entities.InjectionMold", "InjectionMold")
                        .WithMany("Ingredients")
                        .HasForeignKey("InjectionMoldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InjectionMold");
                });

            modelBuilder.Entity("Production.Domain.Entities.InjectionMold", b =>
                {
                    b.HasOne("Production.Domain.Entities.Material", "Material")
                        .WithOne("InjectionMold")
                        .HasForeignKey("Production.Domain.Entities.InjectionMold", "MaterialId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Production.Domain.Entities.Material", b =>
                {
                    b.OwnsOne("Production.Domain.Entities.MaterialStock", "Stock", b1 =>
                        {
                            b1.Property<int>("MaterialId")
                                .HasColumnType("int");

                            b1.Property<int>("MaterialInStock")
                                .HasColumnType("int");

                            b1.Property<int>("MaterialOnProduction")
                                .HasColumnType("int");

                            b1.Property<int>("MaterialToOrder")
                                .HasColumnType("int");

                            b1.Property<int>("PlannedMaterialDemand")
                                .HasColumnType("int");

                            b1.HasKey("MaterialId");

                            b1.ToTable("Materials");

                            b1.WithOwner()
                                .HasForeignKey("MaterialId");
                        });

                    b.Navigation("Stock")
                        .IsRequired();
                });

            modelBuilder.Entity("Production.Domain.Entities.Production", b =>
                {
                    b.HasOne("Production.Domain.Entities.InjectionMold", "InjectionMold")
                        .WithMany("Productions")
                        .HasForeignKey("InjectionMoldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Production.Domain.Entities.InjectionMoldingMachine", "InjectionMoldingMachine")
                        .WithMany("Productions")
                        .HasForeignKey("InjectionMoldingMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Production.Domain.Entities.MaterialStatus", "MaterialStatus", b1 =>
                        {
                            b1.Property<int>("ProductionId")
                                .HasColumnType("int");

                            b1.Property<bool>("MaterialIsAvailable")
                                .HasColumnType("bit");

                            b1.Property<int>("MaterialUsage")
                                .HasColumnType("int");

                            b1.HasKey("ProductionId");

                            b1.ToTable("Productions");

                            b1.WithOwner()
                                .HasForeignKey("ProductionId");
                        });

                    b.Navigation("InjectionMold");

                    b.Navigation("InjectionMoldingMachine");

                    b.Navigation("MaterialStatus")
                        .IsRequired();
                });

            modelBuilder.Entity("Production.Domain.Entities.InjectionMold", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Productions");
                });

            modelBuilder.Entity("Production.Domain.Entities.InjectionMoldingMachine", b =>
                {
                    b.Navigation("Productions");
                });

            modelBuilder.Entity("Production.Domain.Entities.Material", b =>
                {
                    b.Navigation("InjectionMold");
                });
#pragma warning restore 612, 618
        }
    }
}
