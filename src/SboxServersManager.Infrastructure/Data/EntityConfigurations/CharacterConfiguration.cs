using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SboxServersManager.Domain.Aggregates;
using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Data.EntityConfigurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("characters");

            builder.Property(p => p.Id).HasColumnName("character_id")
                .IsRequired();
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Role).HasColumnName("role")
                .IsRequired();

            builder.Property(p => p.IsBanned).HasColumnName("isbanned")
                .IsRequired();

            builder.Property(p => p.Warn).HasColumnName("warn")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.CreatedDate).HasColumnName("created")
                .IsRequired();

            builder.Property(p => p.LastActive).HasColumnName("last_active");

            builder.Property(p => p.DateReceivingBan).HasColumnName("date_receiving_ban");

            builder.HasOne<Server>()
                .WithMany(s => s.Characters)
                .HasForeignKey(p => p.ServerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
