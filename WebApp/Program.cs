using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using WebApp.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<MarketContext>(option =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); 

app.UseRouting();

app.MapControllerRoute(name: "default", pattern:"{controller=Home}/{action=Index}/{id?}") ;

app.Run();

 