using Microsoft.EntityFrameworkCore;
using SboxServersManager.Domain.Aggregates;
using SboxServersManager.Domain.Entities;
using SboxServersManager.Infrastructure.Configurations;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new ModConfiguration());
        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<AdminTask> AdminTasks { get; set; }

    }
}
