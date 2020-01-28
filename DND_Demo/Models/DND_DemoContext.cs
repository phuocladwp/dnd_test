using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DND_Demo.Models
{
    public partial class DND_DemoContext : DbContext
    {
        public DND_DemoContext()
        {
        }

        public DND_DemoContext(DbContextOptions<DND_DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dndclasses> Dndclasses { get; set; }
        public virtual DbSet<Dndmembers> Dndmembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=wd16vmdbcls31; database=DND_Demo; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dndclasses>(entity =>
            {
                entity.ToTable("DNDClasses");

                entity.Property(e => e.DndclassDescription)
                    .HasColumnName("DNDClassDescription")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DndclassName)
                    .HasColumnName("DNDClassName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dndmembers>(entity =>
            {
                entity.ToTable("DNDMembers");

                entity.Property(e => e.CreatedTimestamp).HasColumnType("datetime");

                entity.Property(e => e.DndclassId).HasColumnName("DNDClassId");

                entity.Property(e => e.Dndname)
                    .IsRequired()
                    .HasColumnName("DNDName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FavoriteTvseries)
                    .HasColumnName("FavoriteTVSeries")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateTimestamp).HasColumnType("datetime");

                entity.Property(e => e.NetworkId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RealName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dndclass)
                    .WithMany(p => p.Dndmembers)
                    .HasForeignKey(d => d.DndclassId)
                    .HasConstraintName("FK__DNDMember__DNDCl__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
