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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NBCartLineItemEntity>().HasDiscriminator<string>("Discriminator").HasValue(nameof(NBCartLineItemEntity));
            modelBuilder.Entity<NBCartLineItemEntity>().Property("Discriminator").HasMaxLength(128);
            modelBuilder.Entity<NBCartLineItemEntity>().Property(x => x.PrescriptionId).HasMaxLength(128);

        }
    }
}

