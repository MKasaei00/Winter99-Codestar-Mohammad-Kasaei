﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(SearchContext))]
    partial class SearchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistence.DocumentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Persistence.TokenDocumentModel", b =>
                {
                    b.Property<int>("TokenModelId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentModelId")
                        .HasColumnType("int");

                    b.HasKey("TokenModelId", "DocumentModelId");

                    b.HasIndex("DocumentModelId");

                    b.ToTable("TokenDocuments");
                });

            modelBuilder.Entity("Persistence.TokenModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("Persistence.TokenDocumentModel", b =>
                {
                    b.HasOne("Persistence.DocumentModel", "DocumentModel")
                        .WithMany("TokenDocumentModels")
                        .HasForeignKey("DocumentModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.TokenModel", "TokenModel")
                        .WithMany("TokenDocumentModels")
                        .HasForeignKey("TokenModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentModel");

                    b.Navigation("TokenModel");
                });

            modelBuilder.Entity("Persistence.DocumentModel", b =>
                {
                    b.Navigation("TokenDocumentModels");
                });

            modelBuilder.Entity("Persistence.TokenModel", b =>
                {
                    b.Navigation("TokenDocumentModels");
                });
#pragma warning restore 612, 618
        }
    }
}
