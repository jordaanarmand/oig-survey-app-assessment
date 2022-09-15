using System.Data.Common;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using OIG_Survey_App.Extensions;
using Oig.AppConfiguration.Extensions;
using OIG.Survey.Data.Database.Extensions;
using OIG.Survey.Domain.Concerns.Questionnaires.BackgroundProcessing;
using OIG.Survey.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddValidatorsFromAssembly(typeof(Program).Assembly)
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    ;

builder.Services.AddFrontEnd();
builder.Services.AddDatabase(configuration.GetSettings<DataSettings>());
builder.Services.AddDomain();

// TODO: Replace with a generic implementation which registers all classes which implements a custom IBackgroundJob 
builder.Services.AddScoped<IActivateQuestionnairesJobHandler, ActivateQuestionnairesJobHandler>();
builder.Services.AddScoped<IFinishQuestionnairesJobHandler, FinishQuestionnairesJobHandler>();

// TODO: Move into AddHangfire extension method
builder.Services.AddHangfire(_ => _
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(configuration.GetConnectionString("HangfireConnection")));

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
    "default",
    "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    "DeleteQuestionnaire",
    "{controller=Questionnaire}/{action=Delete}/{id}");

// TODO: Move into UseHangfire extension method
app.UseHangfireDashboard();
app.UseHangfireServer();

using (var scope = app.Services.CreateScope())
{
    var activateQuestionnairesJobHandler = scope.ServiceProvider.GetService<IActivateQuestionnairesJobHandler>();
    RecurringJob.AddOrUpdate("ActivateQuestionnaires",
        () => activateQuestionnairesJobHandler.Handle(new CancellationToken()),
        "*/3 * * * *");
    
    var finishQuestionnairesJobHandler = scope.ServiceProvider.GetService<IFinishQuestionnairesJobHandler>();
    RecurringJob.AddOrUpdate("FinishQuestionnaires",
        () => finishQuestionnairesJobHandler.Handle(new CancellationToken()),
        "*/3 * * * *");
}

app.Run();