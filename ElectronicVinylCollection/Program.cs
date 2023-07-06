using ElectronicVinylCollection.Controllers;
using ElectronicVinylCollection.Entities;
using ElectronicVinylCollection.Middleware;
using ElectronicVinylCollection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorPages();
        // Add services to the container.

        builder.Logging.ClearProviders();
        builder.Host.UseNLog();

        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<VinylDbContext>();
        
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddTransient<ErrorHandlingMiddleware>();

        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


        
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.MapControllers();
        app.MapRazorPages();
        app.Run();

    }
}