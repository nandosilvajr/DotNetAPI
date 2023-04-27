using DotNet001BlazorWebApplication.Data;
using DotNet001BlazorWebApplication.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Refit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DotNet001BlazorWebApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DotNet001BlazorWebApplicationContext") ?? throw new InvalidOperationException("Connection string 'DotNet001BlazorWebApplicationContext' not found.")));
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddRefitClient<IWebServiceAPI>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7189"));

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
