﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagementSystem.Data;

namespace UserManagementSystem.Data.Migrations
{
    [DbContext(typeof(UserManagementContext))]
    partial class UserManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserManagementSystem.Data.Entity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "Admin",
                            Description = "This is an admin permission."
                        },
                        new
                        {
                            Id = 2,
                            Code = "Editor",
                            Description = "This is a editor permission."
                        },
                        new
                        {
                            Id = 3,
                            Code = "Reader",
                            Description = "This is a reader permission."
                        });
                });

            modelBuilder.Entity("UserManagementSystem.Data.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "firstUser@sth.com",
                            FirstName = "First",
                            LastName = "Last",
                            Password = "userPassword",
                            Status = 0,
                            UserName = "userName"
                        });
                });

            modelBuilder.Entity("UserManagementSystem.Data.Entity.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionFK")
                        .HasColumnType("int");

                    b.Property<int?>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("UserFK")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("UserManagementSystem.Data.Entity.UserPermission", b =>
                {
                    b.HasOne("UserManagementSystem.Data.Entity.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId");

                    b.HasOne("UserManagementSystem.Data.Entity.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
