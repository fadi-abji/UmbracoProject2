using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using UmbracoProject2.Views;
using Wengine.Base;
using Wengine.Business.Database;
//using Wengine.Components.Core.Extensions;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WengineContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

IConfigurationSection appSettingsSection = builder.Configuration.GetSection("AppSettings");
AppSettings<ClientSettings> appSettings = appSettingsSection.Get<AppSettings<ClientSettings>>();

appSettings.PopulateClientSettings(builder.Environment.EnvironmentName);
builder.Services.AddSingleton(typeof(IAppSettings), appSettings);
builder.Services.AddSingleton(typeof(IClientSettings), appSettings.ClientSettings);


//Blazor integration
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddWengineServerSideForUmbraco(options =>
{
    options.Modules.ProjectsEnabled = true;
});
builder.Services.AddWengineComponents();

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();


app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

//Blazor integration
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapFallbackToPage("/_BlazorHost");




await app.RunAsync();
