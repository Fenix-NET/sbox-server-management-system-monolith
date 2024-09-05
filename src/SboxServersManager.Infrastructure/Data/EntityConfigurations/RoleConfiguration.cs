using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Data.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
            new Role
            {
                Name = "User",
                NormalizedName = "USER"
            },
            new Role
            {
                Name = "Player",
                NormalizedName = "PLAYER"
            },
            new Role
            {
                Name = "Vip",
                NormalizedName = "VIP"
            },
            new Role
            {
                Name = "Helper",
                NormalizedName = "HELPER"
            },
            new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new Role
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            },
            new Role
            {
                Name = "Developer",
                NormalizedName = "DEVELOPER"
            },
            new Role
            {
                Name = "Owner",
                NormalizedName = "OWNER"
            });
        }
    }
}
