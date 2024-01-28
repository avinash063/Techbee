using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Techbee.Model;

namespace Techbee.Data
{
    public class TechbeeContext : DbContext
    {
        public TechbeeContext (DbContextOptions<TechbeeContext> options)
            : base(options)
        {
        }

        public DbSet<Techbee.Model.TechbeeDetail> TechbeeDetail { get; set; } = default!;
    }
}
