// <auto-generated />
using System;
using DataAccesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Authority", b =>
                {
                    b.Property<int>("AuthrorityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthrorityID"), 1L, 1);

                    b.Property<string>("AuthorityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthrorityID");

                    b.ToTable("Authority");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("CustomerAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobID"), 1L, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Emergency")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LogCallID")
                        .HasColumnType("int");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDay")
                        .HasColumnType("datetime2");

                    b.HasKey("JobID");

                    b.HasIndex("LogCallID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.LogCall", b =>
                {
                    b.Property<int>("LogCallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogCallID"), 1L, 1);

                    b.Property<string>("CallInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateCallTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<bool>("IsJob")
                        .HasColumnType("bit");

                    b.Property<int>("WorkerID")
                        .HasColumnType("int");

                    b.HasKey("LogCallID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("WorkerID");

                    b.ToTable("logCalls");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Worker", b =>
                {
                    b.Property<int>("WorkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerID"), 1L, 1);

                    b.Property<int>("AuthorityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkerID");

                    b.HasIndex("AuthorityID");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Job", b =>
                {
                    b.HasOne("EntityLayer.Concrete.LogCall", "LogCall")
                        .WithMany()
                        .HasForeignKey("LogCallID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LogCall");
                });

            modelBuilder.Entity("EntityLayer.Concrete.LogCall", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Worker", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Authority", "Authority")
                        .WithMany()
                        .HasForeignKey("AuthorityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authority");
                });
#pragma warning restore 612, 618
        }
    }
}
