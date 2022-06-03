using DHB_Win.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DHB_Win.Data
{
    public partial class dhbwinContext : IdentityDbContext<User>
    {
        public dhbwinContext()
        {
        }

        public dhbwinContext(DbContextOptions<dhbwinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AchievedAchievement> AchievedAchievements { get; set; } = null!;
        public virtual DbSet<Achievement> Achievements { get; set; } = null!;
        public virtual DbSet<Bet> Bets { get; set; } = null!;
        public virtual DbSet<BetOption> BetOptions { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Placement> Placements { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AchievedAchievement>(entity =>
            {
                entity.HasKey(e => e.Aaid)
                    .HasName("AAID_PK");

                entity.ToTable("AchievedAchievement", "dhbwin");

                entity.HasIndex(e => e.AchIdFk, "AchievedAchievement_AchID_fk_uindex")
                    .IsUnique();

                entity.Property(e => e.Aaid)
                    .ValueGeneratedNever()
                    .HasColumnName("AAID");

                entity.Property(e => e.AchIdFk)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AchID_fk");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.UidFk).HasColumnName("UID_fk");

                entity.HasOne(d => d.AchIdFkNavigation)
                    .WithOne(p => p.AchievedAchievement)
                    .HasForeignKey<AchievedAchievement>(d => d.AchIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AchievedAchievement_Achievement_AchID_fk");

                entity.HasOne(d => d.UidFkNavigation)
                    .WithMany(p => p.AchievedAchievements)
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

                entity.HasIndex(e => e.AchId, "Achievement_AchID_uindex")
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

                entity.HasIndex(e => e.BetId, "Bet_BetID_uindex")
                    .IsUnique();

                entity.Property(e => e.BetId).HasColumnName("BetID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

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
                    .WithMany(p => p.Bets)
                    .HasForeignKey(d => d.UidFk2)
                    .HasConstraintName("UID_fk2");
            });

            modelBuilder.Entity<BetOption>(entity =>
            {
                entity.HasKey(e => e.OptionsId)
                    .HasName("BetOptions_pk")
                    .IsClustered(false);

                entity.ToTable("BetOptions", "dhbwin");

                entity.HasIndex(e => e.OptionsId, "BetOptions_OptionsID_uindex")
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

                entity.HasIndex(e => e.JobId, "Job_JobID_uindex")
                    .IsUnique();

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.JobProviders)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("Job_User_UID_fk");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.JobWorkers)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("Job_worker_fk");
            });

            modelBuilder.Entity<Placement>(entity =>
            {
                entity.HasKey(e => new {e.UidFk, e.PlacementId, e.BetIdFk})
                    .HasName("Placement_pk")
                    .IsClustered(false);

                entity.ToTable("Placement", "dhbwin");

                entity.Property(e => e.UidFk).HasColumnName("UID_fk");

                entity.Property(e => e.PlacementId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PlacementID");

                entity.Property(e => e.BetIdFk).HasColumnName("BetID_fk");

                entity.Property(e => e.OptionIdFk).HasColumnName("OptionID_fk");

                entity.HasOne(d => d.BetIdFkNavigation)
                    .WithMany(p => p.Placements)
                    .HasForeignKey(d => d.BetIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bet_fk");

                entity.HasOne(d => d.OptionIdFkNavigation)
                    .WithMany(p => p.Placements)
                    .HasForeignKey(d => d.OptionIdFk)
                    .HasConstraintName("Placement_BetOptions_OptionsID_fk");

                entity.HasOne(d => d.UidFkNavigation)
                    .WithMany(p => p.Placements)
                    .HasForeignKey(d => d.UidFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_fk");
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dhbwin");
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

                entity.Property(e => e.Street)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Plz)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Stadt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });
            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}