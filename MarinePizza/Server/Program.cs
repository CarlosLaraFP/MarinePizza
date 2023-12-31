﻿/*
    A solution (top level directory) is a container for 1 or more related projects (independently compiled).
 */

using MarinePizza.Services;
using MarinePizza.Data;
using MarinePizza.Interfaces;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registers PizzaContext with the ASP.NET Core dependency injection system.
// Specifies that PizzaContext will use the SQLite database provider.
// Defines a SQLite connection string that points to a local file, MarinePizza.db.
builder.Services.AddSqlite<PizzaContext>("Data Source=MarinePizza.db");

// PizzaService is registered with the ASP.NET Core dependency injection system
builder.Services.AddScoped<IPizzaService, PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseCors(policy => policy
//    .WithOrigins("https://localhost:7015", "http://localhost:5262")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType)
//);

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

// call the new extension method
app.CreateDbIfNotExists();

//app.MapGet("/", () => @"Pizza management API. Navigate to /swagger to open the Swagger test UI.");

app.Run();

/*
    In the context of ASP.NET Core's dependency injection system, a service's lifetime can be one of three main types: Singleton, Scoped, or Transient.
    Each of these lifetimes answers the question: "When should a new instance of the service be created?"

    A scoped service in ASP.NET Core is one where a new instance is created once per client request and reused in other places within the same request.

    Transient: A new instance of the service is created every time it's requested. This means that multiple requests for a transient service within a single client request will return multiple instances.

    Scoped: An instance is created once per client request. This means if you request the service multiple times within the same HTTP request, you will get the same instance. However, a different client request will receive a different instance.

    Singleton: An instance is created the first time it's requested (or when the application starts, if you configure it during startup) and then every subsequent request will use the same instance.

    To clarify the Scoped lifetime:

    In a typical web application, each HTTP request is treated as a separate "scope."
    When a request comes in, the DI container will create a new set of scoped services, or reuse existing ones if they've already been instantiated for the given request.
    Once the request is finished, any scoped services that were created for that request can be disposed of.
 */