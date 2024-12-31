using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ScreenSound.Web;
using ScreenSound.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

// Adicionando controle de autorização aos serviços
builder.Services.AddAuthorizationCore();
// Quando o ASP for pedido, execute ele a partir da classe AuthAPI
builder.Services.AddScoped<AuthenticationStateProvider, AuthAPI>();
// AuthAPI recebe o service obrigatório AuthenticationStateProvider
builder.Services.AddScoped<AuthAPI>(sp => (AuthAPI) sp.GetRequiredService<AuthenticationStateProvider>());

// Adicionando escopo cookieHandler aos serviços da aplicação
builder.Services.AddScoped<CookieHandler>();

builder.Services.AddScoped<ArtistaAPI>();
builder.Services.AddScoped<MusicaAPI>();

builder.Services.AddHttpClient("API",client => {
    client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();
