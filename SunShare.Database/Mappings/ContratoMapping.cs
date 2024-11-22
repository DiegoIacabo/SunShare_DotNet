using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SunShare.Database.Models;

namespace SunShare.Database.Mappings
{
    public class ContratoMapping : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("tb_contratos_ss");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.LocadorId).IsRequired();
            builder.Property(x => x.LocatarioId).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.AmountOfEnergy).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.TermsAndConditions).IsRequired();
        }
    }
}
