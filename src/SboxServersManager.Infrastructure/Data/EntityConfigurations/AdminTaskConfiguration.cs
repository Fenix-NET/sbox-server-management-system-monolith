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
    public class AdminTaskConfiguration : IEntityTypeConfiguration<AdminTask>
    {
        public void Configure(EntityTypeBuilder<AdminTask> builder)
        {
            builder.ToTable("admin_tasks");

            builder.Property(t => t.Id).HasColumnName("task_id");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Type).HasColumnName("type")
                .IsRequired();

            builder.Property(t => t.Priority).HasColumnName("priority")
                .IsRequired();

            builder.Property(t => t.Details).HasColumnName("details");

            builder.Property(t => t.Status).HasColumnName("status")
                .IsRequired();

            builder.Property(t => t.ScheduledTime).HasColumnName("scheduled_time");

            builder.Property(t => t.CompletedTime).HasColumnName("completed_time");

            builder.Property(t => t.Owner).HasColumnName("owner");

            builder.Property(t => t.Annotation).HasColumnName("annotation");

            builder.Property(t => t.CreatedDate).HasColumnName("created_date")
                .IsRequired();

            builder.HasOne<Server>()
                .WithMany()
                .HasForeignKey(t => t.ServerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(t => t.ServerId).HasColumnName("server_id");
        }

    }
}
