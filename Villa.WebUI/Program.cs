using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Reflection;
using Villa.Business.Abstract;
using Villa.Business.Concreate;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.EntityFramework;
using Villa.DataAccess.Repositories;
using Villa.Entity.Entities;
using Villa.WebUI.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Servis kayýtlarýný ekle
builder.Services.AddServiceExtensions();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// appsettings.json'dan verileri al
var connectionString = builder.Configuration.GetConnectionString("MongoConnection");
var databaseName = builder.Configuration["DatabaseName"]; // JSON'daki gibi 'B' büyük

// DbContext Ayarlarý
builder.Services.AddDbContext<VillaContext>(options =>
{
    options.UseMongoDB(connectionString, databaseName);
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<VillaContext>();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();

var app = builder.Build();


// Bu satýrý ekle:
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR")
});


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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