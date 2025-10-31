using System.Reflection;
using Challenger.Application.Configs;
using Challenger.Application.UseCase;
using Challenger.Application.UseCase.CreateMoto;
using Challenger.Application.UseCase.CreateUser;
using Challenger.Application.UseCase.UpdateUser;
using Challenger.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WebApplication2.API.Extentions;
using WebApplication2.API.Extentions;

namespace WebApplication2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var configs = builder.Configuration.Get<Settings>();

        builder.Services.AddSingleton(configs);
        
        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwagger(configs);

        builder.Services.AddInfra(configs);
        
        builder.Services.AddScoped<ICreatePatioUseCase, CreatePatioUseCase>();
        builder.Services.AddScoped<IUpdatePatioUseCase, UpdatePatioUseCase>();
        builder.Services.AddScoped<ICreateMotoUseCase, CreateMotoUseCase>();
        builder.Services.AddScoped<IUpdateMotoUseCase, UpdateMotoUseCase>();
        builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        
        builder.Services.AddHealthServices(builder.Configuration);

        builder.Services.AddVersioning();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(ui =>
                {
                    ui.SwaggerEndpoint("/swagger/v1/swagger.json",  "PJ.API v1");
                    ui.SwaggerEndpoint("/swagger/v2/swagger.json",  "PJ.API v2");
                }
            );
        }

        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health-check", new HealthCheckOptions()
            {
                ResponseWriter = HealthCheckExtentions.WriteResponse
            });
        });

        app.Run();
    }
}