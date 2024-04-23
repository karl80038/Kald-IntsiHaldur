using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kald_IntsiHaldur.Data;
using Kald_IntsiHaldur.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Kald_IntsiHaldurContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Kald_IntsiHaldurContext") ?? throw new InvalidOperationException("Connection string 'Kald_IntsiHaldurContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

//Initsialiseerime
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var ci = new CultureInfo("et-EE"); //
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ci),
    SupportedCultures = new List<CultureInfo>
    {
        ci,
    },
    SupportedUICultures = new List<CultureInfo>
    {
        ci,
    }
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Incidents}/{action=Index}/{id?}");

app.Run();
