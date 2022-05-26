using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NB.CartModule.Data.Models;
using VirtoCommerce.CartModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Domain;

namespace NB.CartModule.Data.Repositories
{
    public class NBCartRepository : CartRepository
    {
        public IQueryable<NBCartLineItemEntity> CustomerOrders2 => DbContext.Set<NBCartLineItemEntity>();
        public NBCartRepository(NBCartDbContext dbContext) : base(dbContext)
        {
        }
    }
}
