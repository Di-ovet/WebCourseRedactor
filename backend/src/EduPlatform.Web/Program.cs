using EduPlatform.Infrastructure;
using EduPlatform.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using OpenIddict.Validation.AspNetCore;
using System;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();
        builder.Services.AddDbContext<EduPlatformDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
            options.UseOpenIddict();
        });
        
        builder.Services.AddInfrastructure();
        builder.Services.AddOpenIddict()

        .AddCore(options =>
        {
            options.UseEntityFrameworkCore()
                   .UseDbContext<EduPlatformDbContext>();
        })

        .AddServer(options =>
        {
            options.SetTokenEndpointUris("/connect/token");

            options.AllowPasswordFlow(); // TEMPORARY, internal use
            options.AcceptAnonymousClients();

            options.AddDevelopmentEncryptionCertificate()
                   .AddDevelopmentSigningCertificate();

            options.UseAspNetCore()
                   .EnableTokenEndpointPassthrough();
        })

        .AddValidation(options =>
        {
            options.UseSystemNetHttp();
            options.UseAspNetCore();
        });

        builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //TODO: make swagger work
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        

        app.Run();
    }
}