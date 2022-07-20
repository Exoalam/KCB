using KCB.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Blazored.LocalStorage;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<DataBase>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgwNTI2QDMyMzAyZTMyMmUzMGVDVmJ6MjJUalU0dlV2WjZHQlhUQjREMi9sL0R3KzVPM0RZMkpDaFVLK2M9");

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

