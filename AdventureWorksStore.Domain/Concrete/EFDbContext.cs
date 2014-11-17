using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksStore.Domain.Entities;

namespace AdventureWorksStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
    }
}
