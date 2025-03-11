using ASP_Lern.Models;
using ASP_Lern.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<WeatherService>( client =>
{
    client.BaseAddress = new Uri( "https://api.openweathermap.org/" );
} );

var weatherApiKey = builder.Configuration[ "WeatherApiKey" ];

builder.Services.AddSingleton( sp => new WeatherService(
    sp.GetRequiredService<IHttpClientFactory>().CreateClient(),
    weatherApiKey
    ) );

builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
