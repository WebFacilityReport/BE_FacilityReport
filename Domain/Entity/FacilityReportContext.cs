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
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;

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

                entity.HasIndex(e => e.Email, "UQ__Account__AB6E6164E43B4FD9")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Account__B43B145FA4C9659A")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Account__F3DBC572F6D49005")
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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
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

                entity.Property(e => e.ResourcesId).HasColumnName("resourcesId");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
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

                entity.Property(e => e.FeedBackId)
                    .ValueGeneratedOnAdd()

                    .HasColumnName("feedBackId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Comment)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentId");

                entity.Property(e => e.NumberFeedBack).HasColumnName("numberFeedBack");

                entity.Property(e => e.ReportId).HasColumnName("reportId");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict) // thay vì ClientSetNull
                    .IsRequired(false)
                    .HasConstraintName("FK__Feedback__accoun__4F7CD00D");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__equipm__5070F446");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__report__4E88ABD4");
            });

            modelBuilder.Entity<HistoryEquipment>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__HistoryE__19BDBDD3247C79B7");

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
                    .HasConstraintName("FK__HistoryEq__equip__48CFD27E");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.ImageId)
                    .ValueGeneratedOnAdd()

                    .HasColumnName("imageId");

                entity.Property(e => e.DateImgae)
                    .HasColumnType("date")
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
                    .HasConstraintName("FK__Image__postId__4BAC3F29");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.JobId)
                    .ValueGeneratedOnAdd()

                    .HasColumnName("jobId");

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
                    .HasMaxLength(255)
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
                    .HasMaxLength(255)
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
                    .HasName("PK__Resource__557C33998F6B65AB");

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
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TotalQuantity).HasColumnName("totalQuantity_");

                entity.Property(e => e.UsedQuantity).HasColumnName("usedQuantity_");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resources__jobId__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
