using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MarinePizza.Client;
using MarinePizza.Client.Services.Contracts;
using MarinePizza.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7014/")
    }
);

builder.Services.AddScoped<IPizzaService, PizzaService>();

await builder.Build().RunAsync();

