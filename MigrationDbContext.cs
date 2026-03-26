using Microsoft.EntityFrameworkCore;
using CodeMigrationTool.Models;

namespace CodeMigrationTool.Database
{
    public class MigrationDbContext : DbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<MigrationProject> Projects { get; set; } = null!;
        
        public DbSet<MigrationLog> Logs { get; set; } = null!;
        
        public DbSet<TransformationRule> TransformationRules { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MigrationProject configuration
            modelBuilder.Entity<MigrationProject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProjectName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Status).HasMaxLength(50);
                entity.HasMany(e => e.Logs)
                    .WithOne(l => l.Project)
                    .HasForeignKey(l => l.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // MigrationLog configuration
            modelBuilder.Entity<MigrationLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Level).HasMaxLength(20);
                entity.HasIndex(e => new { e.ProjectId, e.CreatedAt });
            });

            // TransformationRule configuration
            modelBuilder.Entity<TransformationRule>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RuleType).HasMaxLength(50);
                entity.HasIndex(e => e.IsActive);
            });
        }
    }
}