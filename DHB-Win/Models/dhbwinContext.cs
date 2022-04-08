using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class dhbwinContext : DbContext
    {
        public dhbwinContext()
        {
        }

        public dhbwinContext(DbContextOptions<dhbwinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AchievedAchievement> AchievedAchievement { get; set; }
        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<Bet> Bet { get; set; }
        public virtual DbSet<BetOptions> BetOptions { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Placement> Placement { get; set; }
        public virtual DbSet<Plz> Plz { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Server=tcp:database-dhbwin.database.windows.net,1433;Initial Catalog=dhbwin;Persist Security Info=False;User ID=dbadmin;Password=admin123!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AchievedAchievement>(entity =>
            {
                entity.HasKey(e => new {e.AchIdFk, e.UidFk})
                    .HasName("AchievedAchievement_pk")
                    .IsClustered(false);

                entity.ToTable("AchievedAchievement", "dhbwin");

                entity.HasIndex(e => e.AchIdFk)
                    .HasName("AchievedAchievement_AchID_fk_uindex")
                    .IsUnique();

                entity.Property(e => e.AchIdFk)
                    .HasColumnName("AchID_fk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UidFk).HasColumnName("UID_fk");

                entity.HasOne(d => d.AchIdFkNavigation)
                    .WithOne(p => p.AchievedAchievement)
                    .HasForeignKey<AchievedAchievement>(d => d.AchIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AchievedAchievement_Achievement_AchID_fk");

                entity.HasOne(d => d.UidFkNavigation)
                    .WithMany(p => p.AchievedAchievement)
                    .HasForeignKey(d => d.UidFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_AchievedAchievement___fk");
            });

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasKey(e => e.AchId)
                    .HasName("Achievement_pk")
                    .IsClustered(false);

                entity.ToTable("Achievement", "dhbwin");

                entity.HasIndex(e => e.AchId)
                    .HasName("Achievement_AchID_uindex")
                    .IsUnique();

                entity.Property(e => e.AchId).HasColumnName("AchID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId)
                    .HasName("Bet_pk")
                    .IsClustered(false);

                entity.ToTable("Bet", "dhbwin");

                entity.HasIndex(e => e.BetId)
                    .HasName("Bet_BetID_uindex")
                    .IsUnique();

                entity.Property(e => e.BetId).HasColumnName("BetID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UidFk2).HasColumnName("UID_fk2");

                entity.HasOne(d => d.UidFk2Navigation)
                    .WithMany(p => p.Bet)
                    .HasForeignKey(d => d.UidFk2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UID_fk2");
            });

            modelBuilder.Entity<BetOptions>(entity =>
            {
                entity.HasKey(e => e.OptionsId)
                    .HasName("BetOptions_pk")
                    .IsClustered(false);

                entity.ToTable("BetOptions", "dhbwin");

                entity.HasIndex(e => e.OptionsId)
                    .HasName("BetOptions_OptionsID_uindex")
                    .IsUnique();

                entity.Property(e => e.OptionsId).HasColumnName("OptionsID");

                entity.Property(e => e.BetId).HasColumnName("BetID");

                entity.Property(e => e.Descpription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Bet)
                    .WithMany(p => p.BetOptions)
                    .HasForeignKey(d => d.BetId)
                    .HasConstraintName("BetOptions_Bet_BetID_fk");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("Job_pk")
                    .IsClustered(false);

                entity.ToTable("Job", "dhbwin");

                entity.HasComment("Create jobs with Betcoins");

                entity.HasIndex(e => e.JobId)
                    .HasName("Job_JobID_uindex")
                    .IsUnique();

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.JobProvider)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("Job_User_UID_fk");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.JobWorker)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("Job_worker_fk");
            });

            modelBuilder.Entity<Placement>(entity =>
            {
                entity.HasKey(e => new {e.UidFk, e.PlacementId, e.BetIdFk})
                    .HasName("Placement_pk")
                    .IsClustered(false);

                entity.ToTable("Placement", "dhbwin");

                entity.HasIndex(e => e.BetIdFk)
                    .HasName("Placement_BetID_fk_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.PlacementId)
                    .HasName("Placement_PlacementID_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.UidFk)
                    .HasName("Placement_UID_fk_uindex")
                    .IsUnique();

                entity.Property(e => e.UidFk).HasColumnName("UID_fk");

                entity.Property(e => e.PlacementId)
                    .HasColumnName("PlacementID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BetIdFk).HasColumnName("BetID_fk");

                entity.Property(e => e.OptionIdFk).HasColumnName("OptionID_fk");

                entity.HasOne(d => d.BetIdFkNavigation)
                    .WithOne(p => p.Placement)
                    .HasForeignKey<Placement>(d => d.BetIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bet_fk");

                entity.HasOne(d => d.OptionIdFkNavigation)
                    .WithMany(p => p.Placement)
                    .HasForeignKey(d => d.OptionIdFk)
                    .HasConstraintName("Placement_BetOptions_OptionsID_fk");

                entity.HasOne(d => d.UidFkNavigation)
                    .WithOne(p => p.Placement)
                    .HasForeignKey<Placement>(d => d.UidFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_fk");
            });

            modelBuilder.Entity<Plz>(entity =>
            {
                entity.HasKey(e => e.Plz1)
                    .HasName("PLZ_pk")
                    .IsClustered(false);

                entity.ToTable("PLZ", "dhbwin");

                entity.HasIndex(e => e.Plz1)
                    .HasName("PLZ_PLZ_uindex")
                    .IsUnique();

                entity.Property(e => e.Plz1)
                    .HasColumnName("PLZ")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ort)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("User_pk")
                    .IsClustered(false);

                entity.ToTable("User", "dhbwin");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.EMail)
                    .HasColumnName("E-Mail")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Firstname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PlzFk).HasColumnName("PLZ_fk");

                entity.Property(e => e.Profilepicture).HasColumnType("image");

                entity.Property(e => e.Street)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.PlzFkNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PlzFk)
                    .HasConstraintName("PLZ_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}