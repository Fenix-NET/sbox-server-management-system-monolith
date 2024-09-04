using Microsoft.EntityFrameworkCore;
using SboxServersManager.Domain.Aggregates;
using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Repositories
{
    public class ServersManagerDbContext : DbContext
    {
        public ServersManagerDbContext(DbContextOptions<ServersManagerDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Mod> Mods { get; set; }

    }
}
