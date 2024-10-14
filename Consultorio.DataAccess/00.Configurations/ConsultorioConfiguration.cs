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
    public class ConsultorioConfiguration : IEntityTypeConfiguration<ConsultorioEntity>
    {
        public void Configure(EntityTypeBuilder<ConsultorioEntity> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();
            builder.Property(c => c.CreationDate)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(c => c.Active)
                .IsRequired();
            builder.Property(c => c.UpdatedDate);
            builder.Property(c => c.Speciality)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(c => c.MedicalOficceNumber)
                .IsRequired();

            var Creationdate = DateTime.Parse("2024-01-07");

            builder.HasData(new List<ConsultorioEntity>() { 
                new() {Id = Guid.NewGuid(), CreationDate = Creationdate, Speciality ="Cardiology",MedicalOficceNumber = 1},
                new() {Id = Guid.NewGuid(), CreationDate = Creationdate, Speciality ="Neumology",MedicalOficceNumber = 2},
                new() {Id = Guid.NewGuid(), CreationDate = Creationdate, Speciality ="Pediatric Cardiology",MedicalOficceNumber = 3},
            });





        }
    }
}
