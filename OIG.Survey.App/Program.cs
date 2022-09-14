using Oig.AppConfiguration.Extensions;
using Oig.Cors;
using Oig.Cors.Extensions;
using OIG.Survey.Data.Database.Extensions;
using OIG.Survey.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCorsPolicySupport(configuration.GetSettings<CorsSettings>());
builder.Services.AddDatabase(configuration.GetSettings<DataSettings>());
builder.Services.AddDomain();

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