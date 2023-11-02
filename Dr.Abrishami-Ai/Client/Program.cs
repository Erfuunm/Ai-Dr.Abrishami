global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;

using Dr.Abrishami_Ai.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Blazored.SessionStorage;
using Dr.Abrishami_Ai.Client.Extention;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazoredSessionStorageAsSingleton();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationExtention>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
