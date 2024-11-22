using Microsoft.EntityFrameworkCore;
using SunShare.Database.Mappings;
using SunShare.Database.Models;

namespace SunShare.Database
{
    public class OracleDbContext(DbContextOptions<OracleDbContext> options) : DbContext(options)
    {

        public DbSet<Locador> Locadores { get; set; }
        public DbSet<Locatario> Locatarios { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocadorMapping());
            modelBuilder.ApplyConfiguration(new LocatarioMapping());
            modelBuilder.ApplyConfiguration(new ContratoMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
