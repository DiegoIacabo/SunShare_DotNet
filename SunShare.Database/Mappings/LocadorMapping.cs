using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SunShare.Database.Models;

namespace SunShare.Database.Mappings
{
    public class LocadorMapping : IEntityTypeConfiguration<Locador>
    {
        public void Configure(EntityTypeBuilder<Locador> builder)
        {
            builder.ToTable("tb_locadores_ss");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Email).
                IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.PowerCompany)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.AverageProduction).IsRequired();

            builder.Property(x => x.AvailableEnergy).IsRequired();
        }
    }
}
