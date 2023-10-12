﻿// <auto-generated />
using System;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(FacilityReportContext))]
    partial class FacilityReportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("username");

                    b.HasKey("AccountId");

                    b.HasIndex(new[] { "Email" }, "UQ__Account__AB6E616404176BC4")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "UQ__Account__B43B145F50121052")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "UQ__Account__F3DBC57223143E54")
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

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("reportId");

                    b.Property<Guid>("ResourcesId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("resourcesId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("status");

                    b.HasKey("EquipmentId");

                    b.HasIndex("ReportId");

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
                        .HasMaxLength(5000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5000)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<int>("NumberFeedBack")
                        .HasColumnType("int")
                        .HasColumnName("numberFeedBack");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("reportId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5000)")
                        .HasColumnName("status");

                    b.HasKey("FeedBackId");

                    b.HasIndex("AccountId");

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
                        .HasName("PK__HistoryE__19BDBDD35836AD21");

                    b.HasIndex("EquipmentId");

                    b.ToTable("HistoryEquipment", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Image", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("imageId");

                    b.Property<string>("DateImgae")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
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
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
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
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("status");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("taskId");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int")
                        .HasColumnName("totalQuantity_");

                    b.Property<int>("UsedQuantity")
                        .HasColumnType("int")
                        .HasColumnName("usedQuantity_");

                    b.HasKey("ResourcesId")
                        .HasName("PK__Resource__557C3399331034E6");

                    b.HasIndex("TaskId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Domain.Entity.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("taskId");

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
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("title");

                    b.HasKey("TaskId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Equipment", b =>
                {
                    b.HasOne("Domain.Entity.Post", "Report")
                        .WithMany("Equipment")
                        .HasForeignKey("ReportId")
                        .IsRequired()
                        .HasConstraintName("FK__Equipment__repor__49C3F6B7");

                    b.HasOne("Domain.Entity.Resource", "Resources")
                        .WithMany("Equipment")
                        .HasForeignKey("ResourcesId")
                        .IsRequired()
                        .HasConstraintName("FK__Equipment__resou__4AB81AF0");

                    b.Navigation("Report");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Domain.Entity.Feedback", b =>
                {
                    b.HasOne("Domain.Entity.Account", "Account")
                        .WithMany("Feedbacks")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__accoun__403A8C7D");

                    b.HasOne("Domain.Entity.Post", "Report")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ReportId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__report__3F466844");

                    b.Navigation("Account");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Domain.Entity.HistoryEquipment", b =>
                {
                    b.HasOne("Domain.Entity.Equipment", "Equipment")
                        .WithMany("HistoryEquipments")
                        .HasForeignKey("EquipmentId")
                        .IsRequired()
                        .HasConstraintName("FK__HistoryEq__equip__4D94879B");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Domain.Entity.Image", b =>
                {
                    b.HasOne("Domain.Entity.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK__Image__postId__5070F446");

                    b.Navigation("Post");
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
                    b.HasOne("Domain.Entity.Task", "Task")
                        .WithMany("Resources")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("FK__Resources__taskI__46E78A0C");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Domain.Entity.Task", b =>
                {
                    b.HasOne("Domain.Entity.Account", "Creator")
                        .WithMany("TaskCreators")
                        .HasForeignKey("CreatorId")
                        .IsRequired()
                        .HasConstraintName("FK__Task__creatorId__4316F928");

                    b.HasOne("Domain.Entity.Account", "Employee")
                        .WithMany("TaskEmployees")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__Task__employeeId__440B1D61");

                    b.Navigation("Creator");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entity.Account", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Posts");

                    b.Navigation("TaskCreators");

                    b.Navigation("TaskEmployees");
                });

            modelBuilder.Entity("Domain.Entity.Equipment", b =>
                {
                    b.Navigation("HistoryEquipments");
                });

            modelBuilder.Entity("Domain.Entity.Post", b =>
                {
                    b.Navigation("Equipment");

                    b.Navigation("Feedbacks");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Domain.Entity.Resource", b =>
                {
                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Domain.Entity.Task", b =>
                {
                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
