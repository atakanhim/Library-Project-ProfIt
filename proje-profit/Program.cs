using BL.Abstract;
using BL.Concrete;
using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using DAL.Abstract;
using DAL.Concrete.EntityFramework;
using DAL.Concrete.EntityFramework.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using proje_profit.Helpers;
using proje_profit.Models;
using Serilog;
using Serilog.Core;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DataContextConnection") ?? throw new InvalidOperationException("Connection string 'DataContextConnection' not found.");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();
// httpservices add
builder.Services.AddHttpClient();
// fluent vlaidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<BooksViewModel>,BooksValidator>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// connection helperss
builder.Services.AddSingleton<IBookService, BookManager>();
builder.Services.AddSingleton<IBookDal, EfBookDal>();
builder.Services.AddSingleton<IHistoryService, HistoryManager>();
builder.Services.AddSingleton<IHistoryDal, EfHistoryDal>();
builder.Services.AddSingleton<ItcknValidator, TcknValidator>();




// seri log add
Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Error()
    .WriteTo.File("logs/log.txt")
    .CreateLogger();

builder.Host.ConfigureLogging(a =>
{
    a.ClearProviders();
}).UseSerilog(log);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
