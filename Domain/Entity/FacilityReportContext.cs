﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Entity
{
    public partial class FacilityReportContext : DbContext
    {
        public FacilityReportContext()
        {
        }

        public FacilityReportContext(DbContextOptions<FacilityReportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<HistoryEquipment> HistoryEquipments { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=FacilityReport;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UQ__Account__AB6E616438192AAC")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Account__B43B145FCFB2D8F0")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Account__F3DBC572E6EDA6FA")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("accountId");

                entity.Property(e => e.Address)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasIndex(e => e.ResourcesId, "IX_Equipment_resourcesId");

                entity.Property(e => e.EquipmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("equipmentId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.ImageEquip)
                    .IsUnicode(false)
                    .HasColumnName("imageEquip");

                entity.Property(e => e.Location)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.ResourcesId).HasColumnName("resourcesId");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Resources)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ResourcesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__resou__45F365D3");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.HasIndex(e => e.AccountId, "IX_Feedback_accountId");

                entity.HasIndex(e => e.EquipmentId, "IX_Feedback_equipmentId");

                entity.Property(e => e.FeedBackId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("feedBackId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Comment)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentId");

                entity.Property(e => e.NumberFeedBack).HasColumnName("numberFeedBack");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Feedback__accoun__5070F446");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__equipm__5165187F");
            });

            modelBuilder.Entity<HistoryEquipment>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__HistoryE__19BDBDD3A787AABA");

                entity.ToTable("HistoryEquipment");

                entity.HasIndex(e => e.JobId, "AK_HistoryEquipment_jobId")
                    .IsUnique();

                entity.HasIndex(e => e.EquipmentId, "IX_HistoryEquipment_equipmentId");

                entity.HasIndex(e => e.JobId, "IX_HistoryEquipment_jobId")
                    .IsUnique();

                entity.Property(e => e.HistoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("historyId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentId");

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.NameHistory)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("nameHistory");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.HistoryEquipments)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HistoryEq__equip__48CFD27E");

                entity.HasOne(d => d.Job)
                    .WithOne(p => p.HistoryEquipment)
                    .HasForeignKey<HistoryEquipment>(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HistoryEq__jobId__49C3F6B7");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.HasIndex(e => e.FeedbackId, "IX_Image_feedbackId");

                entity.Property(e => e.ImageId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("imageId");

                entity.Property(e => e.DateImgae)
                    .HasColumnType("datetime")
                    .HasColumnName("dateImgae");

                entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");

                entity.Property(e => e.NameImage)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("nameImage");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.FeedbackId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.HasIndex(e => e.CreatorId, "IX_Job_creatorId");

                entity.HasIndex(e => e.EmployeeId, "IX_Job_employeeId");

                entity.Property(e => e.JobId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("jobId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creatorId");

                entity.Property(e => e.Deadline)
                    .HasColumnType("datetime")
                    .HasColumnName("deadline");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.NameTask)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("nameTask");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.JobCreators)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job__creatorId__3F466844");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job__employeeId__403A8C7D");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.HasIndex(e => e.AccountId, "IX_Notification_AccountId");

                entity.Property(e => e.NotificationId).ValueGeneratedOnAdd();

                entity.Property(e => e.Message)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourcesId)
                    .HasName("PK__Resource__557C3399398C1175");

                entity.HasIndex(e => e.JobId, "AK_Resources_jobId")
                    .IsUnique();

                entity.HasIndex(e => e.JobId, "IX_Resources_jobId")
                    .IsUnique();

                entity.Property(e => e.ResourcesId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("resourcesId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.NameResource)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("nameResource");

                entity.Property(e => e.Size)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TotalQuantity).HasColumnName("totalQuantity");

                entity.Property(e => e.UsedQuantity).HasColumnName("usedQuantity");

                entity.HasOne(d => d.Job)
                    .WithOne(p => p.Resource)
                    .HasForeignKey<Resource>(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resources__jobId__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
