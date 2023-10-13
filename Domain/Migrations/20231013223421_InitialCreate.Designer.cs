﻿// <auto-generated />
using System;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(FacilityReportContext))]
    [Migration("20231013223421_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entity.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("address");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("role");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("AccountId");

                    b.HasIndex(new[] { "Email" }, "UQ__Account__AB6E6164E43B4FD9")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "UQ__Account__B43B145FA4C9659A")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "UQ__Account__F3DBC572F6D49005")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Equipment", b =>
                {
                    b.Property<Guid>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("equipmentId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<string>("ImageEquip")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("imageEquip");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("location");

                    b.Property<Guid>("ResourcesId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("resourcesId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.HasKey("EquipmentId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Domain.Entity.Feedback", b =>
                {
                    b.Property<Guid>("FeedBackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("feedBackId");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("equipmentId");

                    b.Property<int>("NumberFeedBack")
                        .HasColumnType("int")
                        .HasColumnName("numberFeedBack");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("reportId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.HasKey("FeedBackId");

                    b.HasIndex("AccountId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ReportId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.HistoryEquipment", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("historyId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("equipmentId");

                    b.Property<string>("NameHistory")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("nameHistory");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("status");

                    b.HasKey("HistoryId")
                        .HasName("PK__HistoryE__19BDBDD3247C79B7");

                    b.HasIndex("EquipmentId");

                    b.ToTable("HistoryEquipment", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Image", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("imageId");

                    b.Property<DateTime>("DateImgae")
                        .HasColumnType("date")
                        .HasColumnName("dateImgae");

                    b.Property<string>("NameImage")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("nameImage");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("postId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("status");

                    b.HasKey("ImageId");

                    b.HasIndex("PostId");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Job", b =>
                {
                    b.Property<Guid>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("jobId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("creatorId");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("date")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employeeId");

                    b.Property<string>("NameTask")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("nameTask");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("title");

                    b.HasKey("JobId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("postId");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("image");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("title");

                    b.HasKey("PostId");

                    b.HasIndex("AccountId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Resource", b =>
                {
                    b.Property<Guid>("ResourcesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("resourcesId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("image");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("jobId");

                    b.Property<string>("NameResource")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("nameResource");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("size");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int")
                        .HasColumnName("totalQuantity_");

                    b.Property<int>("UsedQuantity")
                        .HasColumnType("int")
                        .HasColumnName("usedQuantity_");

                    b.HasKey("ResourcesId")
                        .HasName("PK__Resource__557C33998F6B65AB");

                    b.HasIndex("JobId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Domain.Entity.Equipment", b =>
                {
                    b.HasOne("Domain.Entity.Resource", "Resources")
                        .WithMany("Equipment")
                        .HasForeignKey("ResourcesId")
                        .IsRequired()
                        .HasConstraintName("FK__Equipment__resou__45F365D3");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Domain.Entity.Feedback", b =>
                {
                    b.HasOne("Domain.Entity.Account", "Account")
                        .WithMany("Feedbacks")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__accoun__4F7CD00D");

                    b.HasOne("Domain.Entity.Equipment", "Equipment")
                        .WithMany("Feedbacks")
                        .HasForeignKey("EquipmentId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__equipm__5070F446");

                    b.HasOne("Domain.Entity.Post", "Report")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ReportId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__report__4E88ABD4");

                    b.Navigation("Account");

                    b.Navigation("Equipment");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Domain.Entity.HistoryEquipment", b =>
                {
                    b.HasOne("Domain.Entity.Equipment", "Equipment")
                        .WithMany("HistoryEquipments")
                        .HasForeignKey("EquipmentId")
                        .IsRequired()
                        .HasConstraintName("FK__HistoryEq__equip__48CFD27E");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Domain.Entity.Image", b =>
                {
                    b.HasOne("Domain.Entity.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK__Image__postId__4BAC3F29");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Entity.Job", b =>
                {
                    b.HasOne("Domain.Entity.Account", "Creator")
                        .WithMany("JobCreators")
                        .HasForeignKey("CreatorId")
                        .IsRequired()
                        .HasConstraintName("FK__Job__creatorId__3F466844");

                    b.HasOne("Domain.Entity.Account", "Employee")
                        .WithMany("JobEmployees")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__Job__employeeId__403A8C7D");

                    b.Navigation("Creator");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entity.Post", b =>
                {
                    b.HasOne("Domain.Entity.Account", "Account")
                        .WithMany("Posts")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__Post__accountId__3C69FB99");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Entity.Resource", b =>
                {
                    b.HasOne("Domain.Entity.Job", "Job")
                        .WithMany("Resources")
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FK__Resources__jobId__4316F928");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Domain.Entity.Account", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("JobCreators");

                    b.Navigation("JobEmployees");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Domain.Entity.Equipment", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("HistoryEquipments");
                });

            modelBuilder.Entity("Domain.Entity.Job", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Domain.Entity.Post", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Domain.Entity.Resource", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}