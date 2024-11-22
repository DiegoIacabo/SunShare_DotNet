using Microsoft.EntityFrameworkCore;
using SunShare.API.Configuration;
using SunShare.Database;

namespace SunShare.API.Extensions
{
    public static class ContextExtension
    {

        public static IServiceCollection AddContext(this IServiceCollection services, ApiConfiguration apiConfiguration)
        {
            //Oracle
            services.AddDbContext<OracleDbContext>(options =>
            {
                options.UseOracle(apiConfiguration.OracleDb.ConnectionString);
            });

            return services;
        }
    }
}
