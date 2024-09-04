using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SboxServersManager.Domain.Aggregates;
using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("players");

            builder.Property(p => p.Id).HasColumnName("player_id")
                .IsRequired();
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Username).HasColumnName("username")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Role).HasColumnName("role")
                .IsRequired();

            builder.Property(p => p.IsBanned).HasColumnName("isbanned")
                .IsRequired();

            builder.Property(p => p.Warn).HasColumnName("warn")
                .IsRequired();

            builder.Property(p => p.LastActive).HasColumnName("last_active");

            builder.Property(p => p.DateReceivingBan).HasColumnName("date_receiving_ban");

            builder.HasOne<Server>()
                .WithMany(s => s.Players)
                .HasForeignKey(p => p.ServerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
