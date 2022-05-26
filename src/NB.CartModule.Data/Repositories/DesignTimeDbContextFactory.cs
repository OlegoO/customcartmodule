using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NB.CartModule.Data.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NBCartDbContext>
    {
        public NBCartDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NBCartDbContext>();

            builder.UseSqlServer("Data Source=(local);Initial Catalog=VirtoCommerce66;Persist Security Info=True;MultipleActiveResultSets=True;Connect Timeout=30");

            return new NBCartDbContext(builder.Options);
        }
    }
}
