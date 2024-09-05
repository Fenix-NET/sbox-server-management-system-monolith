using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SboxServersManager.Domain.Aggregates;
using SboxServersManager.Domain.Entities;
using SboxServersManager.Infrastructure.Data.EntityConfigurations;

namespace SboxServersManager.Infrastructure.Data
{
    public class ServersManagerDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ServersManagerDbContext(DbContextOptions<ServersManagerDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ServerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new ModConfiguration());
            modelBuilder.ApplyConfiguration(new AdminTaskConfiguration());
        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<AdminTask> AdminTasks { get; set; }
    }
}
