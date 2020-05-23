using Microsoft.EntityFrameworkCore;

namespace UniversityNavigator.DomainModel.GeneratedDataModel
{
    public partial class UniversityNavigatorContext : DbContext
    {
        public UniversityNavigatorContext()
        {
        }

        public UniversityNavigatorContext(DbContextOptions<UniversityNavigatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audience> Audience { get; set; }
        public virtual DbSet<AudienceImage> AudienceImage { get; set; }
        public virtual DbSet<AudienceQuickSearch> AudienceQuickSearch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4V1BOFI\\SQLEXPRESS;Initial Catalog=UniversityNavigator;User ID=sa;Password=qwerty123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audience>(entity =>
            {
                entity.Property(e => e.AudienceId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Building)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AudienceImage>(entity =>
            {
                entity.HasKey(e => e.Audience)
                    .HasName("PK__Audience__365FC56369DE0B6B");

                entity.Property(e => e.Audience)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.AudienceNavigation)
                    .WithOne(p => p.AudienceImage)
                    .HasForeignKey<AudienceImage>(d => d.Audience)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AudienceImageRef");
            });

            modelBuilder.Entity<AudienceQuickSearch>(entity =>
            {
                entity.HasKey(e => e.Audience)
                    .HasName("PK__AudinceQ__365FC563D87054BD");

                entity.Property(e => e.Audience)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.AudienceNavigation)
                    .WithOne(p => p.AudienceQuickSearch)
                    .HasForeignKey<AudienceQuickSearch>(d => d.Audience)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AudienceQuickSearch");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
