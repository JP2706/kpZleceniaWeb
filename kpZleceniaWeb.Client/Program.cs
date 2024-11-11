using kpZleceniaWeb.Client;
using kpZleceniaWeb.Client.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddCulture();

var uri = new Uri(builder.Configuration["ApiConfiguration:BaseAddress"] + "api/");

builder.Services.AddClient(uri);

await builder.Build().RunAsync();


