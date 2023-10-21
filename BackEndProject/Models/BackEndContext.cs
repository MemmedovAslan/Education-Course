using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEndProject.Models
{
    public partial class BackEndContext : DbContext
    {
        public BackEndContext()
        {
        }

        public BackEndContext(DbContextOptions<BackEndContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Elaqe> Elaqes { get; set; }
        public virtual DbSet<Kateqoriyalar> Kateqoriyalars { get; set; }
        public virtual DbSet<Kurslar> Kurslars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIN-DE842EDO3NN\\SQLEXPRESS;Database=Back-End;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Elaqe>(entity =>
            {
                entity.ToTable("Elaqe");

                entity.Property(e => e.Nomre).HasMaxLength(20);

                entity.Property(e => e.Saat).HasMaxLength(20);

                entity.Property(e => e.Unvan).HasMaxLength(60);
            });

            modelBuilder.Entity<Kateqoriyalar>(entity =>
            {
                entity.HasKey(e => e.KateqoriyaId)
                    .HasName("PK__Kateqori__4A511846E6D83DE0");

                entity.ToTable("Kateqoriyalar");

                entity.Property(e => e.KateqoriyaAd).HasMaxLength(20);
            });

            modelBuilder.Entity<Kurslar>(entity =>
            {
                entity.HasKey(e => e.KursId)
                    .HasName("PK__Kurslar__BCCFFFDBF415591C");

                entity.ToTable("Kurslar");

                entity.Property(e => e.KursAd).HasMaxLength(30);

                entity.Property(e => e.KursHaqqinda).HasMaxLength(300);

                entity.Property(e => e.KursSekil).HasMaxLength(50);

                entity.HasOne(d => d.KursKateqoriya)
                    .WithMany(p => p.Kurslars)
                    .HasForeignKey(d => d.KursKateqoriyaId)
                    .HasConstraintName("FK__Kurslar__KursKat__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
