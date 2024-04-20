using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kald_IntsiHaldur.Models;

namespace Kald_IntsiHaldur.Data
{
    public class Kald_IntsiHaldurContext : DbContext
    {
        public Kald_IntsiHaldurContext (DbContextOptions<Kald_IntsiHaldurContext> options)
            : base(options)
        {
        }

        public DbSet<Kald_IntsiHaldur.Models.Incident> Incident { get; set; } = default!;
    }
}
