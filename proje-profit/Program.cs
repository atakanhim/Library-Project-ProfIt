using BL.Abstract;
using BL.Concrete;
using DAL.Abstract;
using DAL.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IBookService, BookManager>();
builder.Services.AddSingleton<IBookDal, EfBookDal>();
builder.Services.AddSingleton<IHistoryService, HistoryManager>();
builder.Services.AddSingleton<IHistoryDal, EfHistoryDal>();
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
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
