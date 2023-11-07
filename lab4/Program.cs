using lab4.Data;
using lab4.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("MSSQL");
        builder.Services.AddDbContext<TouristAgency1Context>(option => option.UseSqlServer(connectionString));
        builder.Services.AddControllersWithViews(options => {
            options.CacheProfiles.Add("ModelCache",
                new CacheProfile()
                {
                    Location = ResponseCacheLocation.Any,
                    Duration = 2 * 11 + 240
                });
        });
        builder.Services.AddSession();


        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseSession();

        app.UseDbInitializer();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "client",
            pattern: "{controller=Client}/{action=ShowTable}");

        app.MapControllerRoute(
            name: "typesOfRecration",
            pattern: "{controller=TypesOfRecration}/{action=ShowTable}");

        app.MapControllerRoute(
           name: "voucher",
           pattern: "{controller=Voucher}/{action=ShowTable}");

        app.Run();
    }
}