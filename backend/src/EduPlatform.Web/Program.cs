using EduPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();



        app.Run();
    }
}