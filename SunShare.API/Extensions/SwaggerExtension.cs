using Microsoft.OpenApi.Models;
using SunShare.API.Configuration;
using System.Reflection;
namespace SunShare.API.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, ApiConfiguration apiConfiguration)
        {

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{apiConfiguration.Swagger.Title} {DateTime.Now.Year} ",
                    Version = "v1",
                    Description = apiConfiguration.Swagger.Description,
                    Contact = new OpenApiContact() { Name = apiConfiguration.Swagger.Name, Email = apiConfiguration.Swagger.Email }
                });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";  
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); 

                x.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
