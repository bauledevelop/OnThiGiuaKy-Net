using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ontap.Data;

namespace Ontap.Data
{
    public class OntapContext : DbContext
    {
        public OntapContext (DbContextOptions<OntapContext> options)
            : base(options)
        {
        }

        public DbSet<Ontap.Data.ViTri> ViTri { get; set; } = default!;

        public DbSet<Ontap.Data.DoiBong> DoiBong { get; set; }= default!;

        public DbSet<Ontap.Data.SanVanDong> SanVanDong { get; set; } = default!;

        public DbSet<Ontap.Data.TranDau> TranDau { get; set; } = default!;

        public DbSet<Ontap.Data.CauThu> CauThu { get; set; } = default!;
    }
}
