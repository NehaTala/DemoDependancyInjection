using DPI.Services;
using DPI.Services.IServices;
using DPI.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("DemoDBConnection");
builder.Services.AddDbContext<TestCoreContext>(op => op.UseSqlServer(conn));

builder.Services.AddTransient<ITransient, UserMethod>();
builder.Services.AddSingleton<ISingleton, UserMethod>();
builder.Services.AddScoped<IScoped, UserMethod>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
