using Consultorio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess._00.Configurations
{
    public class PractitionerConfiguration : IEntityTypeConfiguration<Practitioner>
    {
        public void Configure(EntityTypeBuilder<Practitioner> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.CreationDate)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(p => p.Active)
                .IsRequired();
            builder.Property(p => p.UpdatedDate);
            builder.Property(p => p.GivenName)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(p => p.FamilyName)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(p => p.Qualification)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
