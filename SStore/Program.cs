using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SStore;
using SStore.Model.Data;
using SStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AppServices(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())   
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
