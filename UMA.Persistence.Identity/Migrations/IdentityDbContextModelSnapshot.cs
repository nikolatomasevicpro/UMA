﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UMA.Persistence.Identity.Context;

namespace UMA.Persistence.Identity.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UMA.Domain.Identity.Identity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Identity");
                });

            modelBuilder.Entity("UMA.Domain.Identity.IdentityRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("IdentityId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityRole");
                });

            modelBuilder.Entity("UMA.Domain.Identity.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("IdentityId");

                    b.Property<string>("Locale")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6)
                        .HasDefaultValue("en-US");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("UMA.Domain.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("UMA.Domain.Identity.IdentityRole", b =>
                {
                    b.HasOne("UMA.Domain.Identity.Identity", "Identity")
                        .WithMany("IdentityRoles")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UMA.Domain.Identity.Role", "Role")
                        .WithMany("IdentityRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UMA.Domain.Identity.Profile", b =>
                {
                    b.HasOne("UMA.Domain.Identity.Identity", "Identity")
                        .WithOne("Profile")
                        .HasForeignKey("UMA.Domain.Identity.Profile", "IdentityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
