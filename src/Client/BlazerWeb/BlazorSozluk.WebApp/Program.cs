using Blazored.LocalStorage;
using BlazorSozluk.WebApp;
using BlazorSozluk.WebApp.Infrastructure.Services;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("WebApiClient",client =>
{
    client.BaseAddress = new Uri(builder.Configuration["WebApiClientAddress"]);
});

builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient(builder.Configuration["WebApiClientAddress"]);
});

builder.Services.AddTransient<IVoteService, VoteService>();
builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<IFavService, FavService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIdentityService, IdentityService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
