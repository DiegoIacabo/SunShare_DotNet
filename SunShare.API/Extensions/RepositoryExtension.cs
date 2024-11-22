using SunShare.Database.Models;
using SunShare.Repository;
using SunShare.Repository.Oracle;

namespace SunShare.API.Extensions
{
    public static class RepositoryExtension
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Locador>, OracleRepository<Locador>>();
            services.AddScoped<IRepository<Locatario>, OracleRepository<Locatario>>();
            services.AddScoped<IRepository<Contrato>, OracleRepository<Contrato>>();

            return services;
        }
    }
}
