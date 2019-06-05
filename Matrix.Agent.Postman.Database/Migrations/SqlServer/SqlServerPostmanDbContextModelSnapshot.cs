﻿// <auto-generated />
using Matrix.Agent.Postman.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Matrix.Agent.Postman.Database.Migrations.SqlServer
{
    [DbContext(typeof(SqlServerPostmanDbContext))]
    partial class SqlServerPostmanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Matrix.Agent.Postman.Database.Entities.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Application");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(4096);

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("HTML");

                    b.Property<int>("Status");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Matrix.Agent.Postman.Database.Entities.EmailAddress", b =>
                {
                    b.Property<Guid>("EmailId");

                    b.Property<string>("Address")
                        .HasMaxLength(256);

                    b.Property<bool>("Blind");

                    b.Property<bool>("Copy");

                    b.HasKey("EmailId", "Address");

                    b.ToTable("EmailAddress");
                });

            modelBuilder.Entity("Matrix.Agent.Postman.Database.Entities.PhoneMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Application");

                    b.Property<string>("From");

                    b.Property<string>("Message");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("PhoneMessages");
                });

            modelBuilder.Entity("Matrix.Agent.Postman.Database.Entities.PhoneNumber", b =>
                {
                    b.Property<Guid>("PhoneMessageId");

                    b.Property<string>("Number")
                        .HasMaxLength(256);

                    b.HasKey("PhoneMessageId", "Number");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("Matrix.Agent.Postman.Database.Entities.EmailAddress", b =>
                {
                    b.HasOne("Matrix.Agent.Postman.Database.Entities.Email", "Email")
                        .WithMany("To")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matrix.Agent.Postman.Database.Entities.PhoneNumber", b =>
                {
                    b.HasOne("Matrix.Agent.Postman.Database.Entities.PhoneMessage", "PhoneMessage")
                        .WithMany("To")
                        .HasForeignKey("PhoneMessageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
