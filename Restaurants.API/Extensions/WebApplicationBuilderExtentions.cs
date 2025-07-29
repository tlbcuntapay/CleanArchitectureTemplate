using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;
using Serilog;

namespace Restaurants.API.Extensions;

public static class WebApplicationBuilderExtentions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        // Add Authentication
        builder.Services.AddAuthentication();

        // Swagger Package
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                    },
                    []
                }
            });
        });

        // Add Swagger Identity
        builder.Services.AddEndpointsApiExplorer();

        // Add middleware before using UseMiddleware
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<TimeExecutionMiddleware>();

        // Serilog Package 
        builder.Host.UseSerilog((context, config) =>
            config.ReadFrom.Configuration(context.Configuration)
        );
    }
}
