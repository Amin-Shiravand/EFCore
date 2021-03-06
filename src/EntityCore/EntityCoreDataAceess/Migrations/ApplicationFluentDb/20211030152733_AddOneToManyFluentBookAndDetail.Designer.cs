// <auto-generated />
using System;
using EntityCoreDataAceess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityCoreDataAceess.Migrations.ApplicationFluentDb
{
    [DbContext(typeof(ApplicationFluentDbContext))]
    [Migration("20211030152733_AddOneToManyFluentBookAndDetail")]
    partial class AddOneToManyFluentBookAndDetail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityCoreModel.Models.Fluent.FluentAuthor", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("FluentAuthors");
                });

            modelBuilder.Entity("EntityCoreModel.Models.Fluent.FluentBook", b =>
                {
                    b.Property<int>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FluentBookDetail_Id")
                        .HasColumnType("int");

                    b.Property<int>("FluentPublisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Book_Id");

                    b.HasIndex("FluentBookDetail_Id")
                        .IsUnique();

                    b.HasIndex("FluentPublisher_Id");

                    b.ToTable("FluentBooks");
                });

            modelBuilder.Entity("EntityCoreModel.Models.Fluent.FluentBookDetail", b =>
                {
                    b.Property<int>("FluentBookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("FluentBookDetail_Id");

                    b.ToTable("FluentBookDetails");
                });

            modelBuilder.Entity("EntityCoreModel.Models.Fluent.FluentPublisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("FluentPublishers");
                });

            modelBuilder.Entity("EntityCoreModel.Models.Fluent.FluentBook", b =>
                {
                    b.HasOne("EntityCoreModel.Models.Fluent.FluentBookDetail", "FluentBookDetail")
                        .WithOne("FluentBook")
                        .HasForeignKey("EntityCoreModel.Models.Fluent.FluentBook", "FluentBookDetail_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityCoreModel.Models.Fluent.FluentPublisher", "FluentPublisher")
                        .WithMany("FluentBooks")
                        .HasForeignKey("FluentPublisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FluentBookDetail");

                    b.Navigation("FluentPublisher");
                });

            modelBuilder.Entity("EntityCoreModel.Models.Fluent.FluentBookDetail", b =>
                {
                    b.Navigation("FluentBook");
                });

            modelBuilder.Entity("EntityCoreModel.Models.Fluent.FluentPublisher", b =>
                {
                    b.Navigation("FluentBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
