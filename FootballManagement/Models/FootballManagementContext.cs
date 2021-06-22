using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FootballManagement.Models
{
    public partial class FootballManagementContext : DbContext
    {
        public FootballManagementContext()
        {
        }

        public FootballManagementContext(DbContextOptions<FootballManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-38IAPAP;Initial Catalog=FootballManagement;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");

                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Place).HasMaxLength(256);

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Coaches)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Coach_Team");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Place).HasMaxLength(256);

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Player_Team");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
