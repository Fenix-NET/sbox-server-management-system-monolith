using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Configurations
{
    public class ModConfiguration : IEntityTypeConfiguration<Mod>
    {
        public void Configure(EntityTypeBuilder<Mod> builder)
        {
            builder.ToTable("mods");

            builder.Property(m => m.Id).HasColumnName("mod_id")
                .IsRequired();
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Version).HasColumnName("version")
                .HasMaxLength(50);

            builder.Property(m => m.Description).HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}
