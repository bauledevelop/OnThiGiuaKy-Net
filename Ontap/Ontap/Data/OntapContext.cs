using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ontap.Data
{
    public class OntapContext : DbContext
    {
        public OntapContext (DbContextOptions<OntapContext> options)
            : base(options)
        {
        }

        public DbSet<Ontap.Data.Player> Players { get; set; } = default!;
        public DbSet<Ontap.Data.Match> Matches { get; set; }  
        public DbSet<Ontap.Data.Team> Teams { get; set; } 
        public DbSet<Ontap.Data.Stadium> Stadiums { get; set; }
        public DbSet<Ontap.Data.Product> Products { get; set; }
    }
}
