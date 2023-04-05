using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SStore.Model.Data;
using SStore.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddTransient<ICounterServicecs, CounterServicecs>();
builder.Services.AddTransient<IAppUserService, AppUserService>();
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("StoreConnection"));
});
//var path = Environment.CurrentDirectory;
//// var path = Environment.GetFolderPath(folder);
//var DbPath = System.IO.Path.Join(path, "store.db");
//builder.Services.AddDbContextFactory<StoreDbContext>(opt =>
//    opt.UseSqlite($"Data Source={DbPath}"));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
