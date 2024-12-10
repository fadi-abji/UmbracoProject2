using UmbracoProject2.Views;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Blazor integration
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


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
app.MapFallbackToPage("/_BlazorHost"); // This should match the file name in the Pages folder

await app.RunAsync();
