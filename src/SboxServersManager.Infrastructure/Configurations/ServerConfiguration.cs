using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SboxServersManager.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Configurations
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("servers");

            builder.Property(s => s.Id).HasColumnName("server_id");

            builder.HasKey(x => x.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100).HasColumnName("name");

            builder.Property(s => s.Status).IsRequired().HasColumnName("status");

            builder.Property(s => s.Address).IsRequired().HasColumnName("ip_adress");

            builder.Property(s => s.Port).IsRequired().HasColumnName("port");

            builder.HasMany(s => s.Players).WithOne().HasForeignKey(p => p.ServerId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(s => s.ActiveMods).WithMany(m => m.InstalledOnServers);
        }
    }
}
