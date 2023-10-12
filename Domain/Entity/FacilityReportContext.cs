using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ULDR55OI\\MSSQLSERVER01;Database=FacilityReport;User ID=sa;Password=12345;TrustServerCertificate=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UQ__Account__AB6E616404176BC4")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Account__B43B145F50121052")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Account__F3DBC57223143E54")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("accountId");

                entity.Property(e => e.Address)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
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

                entity.Property(e => e.Username)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.EquipmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("equipmentId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.ImageEquip)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("imageEquip");

                entity.Property(e => e.Location)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.ReportId).HasColumnName("reportId");

                entity.Property(e => e.ResourcesId).HasColumnName("resourcesId");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__repor__49C3F6B7");

                entity.HasOne(d => d.Resources)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ResourcesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__resou__4AB81AF0");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedBackId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("feedBackId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Comment)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.NumberFeedBack).HasColumnName("numberFeedBack");

                entity.Property(e => e.ReportId).HasColumnName("reportId");

                entity.Property(e => e.Status)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__accoun__403A8C7D");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__report__3F466844");
            });

            modelBuilder.Entity<HistoryEquipment>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__HistoryE__19BDBDD35836AD21");

                entity.ToTable("HistoryEquipment");

                entity.Property(e => e.HistoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("historyId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentId");

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
                    .HasConstraintName("FK__HistoryEq__equip__4D94879B");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.ImageId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("imageId");

                entity.Property(e => e.DateImgae)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("dateImgae");

                entity.Property(e => e.NameImage)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("nameImage");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Image__postId__5070F446");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("postId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post__accountId__3C69FB99");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourcesId)
                    .HasName("PK__Resource__557C3399331034E6");

                entity.Property(e => e.ResourcesId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("resourcesId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("image");

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

                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.Property(e => e.TotalQuantity).HasColumnName("totalQuantity_");

                entity.Property(e => e.UsedQuantity).HasColumnName("usedQuantity_");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resources__taskI__46E78A0C");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("taskId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creatorId");

                entity.Property(e => e.Deadline)
                    .HasColumnType("date")
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
                    .WithMany(p => p.TaskCreators)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Task__creatorId__4316F928");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TaskEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Task__employeeId__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
