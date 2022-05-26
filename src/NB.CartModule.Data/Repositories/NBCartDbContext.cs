using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using NB.CartModule.Data.Models;
using VirtoCommerce.CartModule.Data.Model;
using VirtoCommerce.CartModule.Data.Repositories;

namespace NB.CartModule.Data.Repositories
{
    public class NBCartDbContext : CartDbContext
    {
        private const string _discriminatorName = "Discriminator";
        public NBCartDbContext(DbContextOptions<NBCartDbContext> options)
          : base(options)
        {
        }

        protected NBCartDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineItemEntity>()
            .HasDiscriminator()
            .HasValue<NBCartLineItemEntity>(nameof(NBCartLineItemEntity));
            modelBuilder.Entity<LineItemEntity>().Property("Discriminator").HasMaxLength(128);
            base.OnModelCreating(modelBuilder);
        }
    }
}

