using Microsoft.EntityFrameworkCore;
using Viktalea.Application.Contracts.Services;
using Viktalea.Domain.Entities;

namespace Viktalea.Infraestructure.Persistence
{
    public partial class ViktaleaContext(DbContextOptions<ViktaleaContext> options, ICurrentUserService currentUserService) : DbContext(options)
    {
        public virtual DbSet<Client> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasKey(e => e.Id)
                      .HasName("PK_Client");

                entity.Property(e => e.Ruc)
                      .IsRequired()
                      .HasMaxLength(11)
                      .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.ContactPhone)
                      .IsRequired()
                      .HasMaxLength(15)
                      .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.Address)
                      .HasMaxLength(250);

                entity.Property(e => e.IsActive)
                      .HasDefaultValue(true);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.UpdatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.CreatedBy)
                      .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy)
                      .HasMaxLength(100);

                entity.HasIndex(e => e.Ruc)
                      .HasDatabaseName("IX_Client_Ruc")
                      .IsUnique();

                entity.HasIndex(e => e.BusinessName)
                      .HasDatabaseName("IX_Client_BusinessName");
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var username = currentUserService.GetCurrentUsername() ?? "system";

            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = username;
                        entry.Entity.IsActive = true;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        entry.Entity.UpdatedBy = username;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsActive = false;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        entry.Entity.UpdatedBy = username;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
