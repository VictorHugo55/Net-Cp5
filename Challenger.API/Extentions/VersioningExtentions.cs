﻿using Asp.Versioning;

namespace WebApplication2.API.Extentions;

public static class VersioningExtentions
{
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; //v1 v1.1 v1.1.1
                options.SubstituteApiVersionInUrl = true;
            });

        return services;
    }
}