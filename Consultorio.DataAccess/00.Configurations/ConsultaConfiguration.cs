using Consultorio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Consultorio.DataAccess._00.Configurations
{
    public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();
            builder.Property(c => c.CreationDate)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(c => c.Active)
                .IsRequired();
            builder.Property(c => c.UpdatedDate);
            builder.Property(c => c.BeginingScheduleHour)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(c => c.EndingScheduleHour)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(c => c.ScheduleDay)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(c => c.PractitionerId)
                .IsRequired();
            builder.Property(c => c.ConsultorioId)
                .IsRequired();
        }
    }
}
