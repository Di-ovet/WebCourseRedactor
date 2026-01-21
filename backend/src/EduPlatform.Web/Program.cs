using EduPlatform.Infrastructure;
using EduPlatform.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();
        builder.Services.AddDbContext<EduPlatformDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("Default")
            ));
        builder.Services.AddInfrastructure();
        builder.Services.AddOpenIddict()

        // 1. Core (storage)
        .AddCore(options =>
        {
            options.UseEntityFrameworkCore()
                   .UseDbContext<EduPlatformDbContext>();
        })

        // 2. Server (authorization server)
        .AddServer(options =>
        {
            // Endpoints
            options.SetAuthorizationEndpointUris("/connect/authorize")
                   .SetTokenEndpointUris("/connect/token")
                   .SetUserInfoEndpointUris("/connect/userinfo");

            // Flow
            options.AllowAuthorizationCodeFlow()
                   .RequireProofKeyForCodeExchange();

            // Scopes
            options.RegisterScopes(
                OpenIddictConstants.Scopes.OpenId,
                OpenIddictConstants.Scopes.Profile,
                OpenIddictConstants.Scopes.Email
            );

            // Tokens
            options.UseReferenceRefreshTokens(); // for http-only cookie
            options.DisableAccessTokenEncryption(); // JWT access token

            // Dev certs (OK for now)
            options.AddDevelopmentEncryptionCertificate()
                   .AddDevelopmentSigningCertificate();

            // ASP.NET Core integration
            options.UseAspNetCore()
                   .EnableAuthorizationEndpointPassthrough()
                   .EnableTokenEndpointPassthrough()
                   .EnableUserInfoEndpointPassthrough();
        })

        // 3. Validation (API auth)
        .AddValidation(options =>
        {
            options.SetIssuer("http://localhost:5288/"); // ”кажите ваш актуальный адрес сервера
            options.AddAudiences("eduplatform_api");
            options.UseSystemNetHttp();
            options.UseAspNetCore();
        });
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
            .AddCookie(options =>
        {
            options.LoginPath = "/login";
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {

            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        

        app.Run();
    }
}