using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PokedexGambaApp; // Nahraď názvem tvé aplikace

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrace HttpClient služby
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// // Nastavení CORS (pokud je potřeba na serverové straně)
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowLocalhost",
//         policy => policy.WithOrigins("http://localhost:8081") // Nastav správnou URL pro tvoji aplikaci
//                         .AllowAnyMethod()
//                         .AllowAnyHeader());
// });

await builder.Build().RunAsync();
