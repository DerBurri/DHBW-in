using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<AchievedAchievement> AchievedAchievements { get; set; } = null!;
        public virtual DbSet<Achievement> Achievements { get; set; } = null!;
        public virtual DbSet<Bet> Bets { get; set; } = null!;
        public virtual DbSet<BetOption> BetOptions { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Placement> Placements { get; set; } = null!;
        public virtual DbSet<Plz> Plzs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(
                    "Server=tcp:database-dhbwin.database.windows.net,1433;Initial Catalog=dhbwin;Persist Security Info=False;User ID=dbadmin;Password=admin123!;");
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

            modelBuilder.Entity<Plz>(entity =>
            {
                entity.HasKey(e => e.Plz1)
                    .HasName("PLZ_pk")
                    .IsClustered(false);

                entity.ToTable("PLZ", "dhbwin");

                entity.HasIndex(e => e.Plz1, "PLZ_PLZ_uindex")
                    .IsUnique();

                entity.Property(e => e.Plz1)
                    .ValueGeneratedNever()
                    .HasColumnName("PLZ");

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
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E-Mail")
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

                entity.Property(e => e.Street)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.PlzFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PlzFk)
                    .HasConstraintName("PLZ_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}