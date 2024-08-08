using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using QuickChat.Client;
using QuickChat.Shared.Data;
using QuickChat.Shared.Data.InitDataFactory;
using QuickChat.Shared.Services;
using QuickChat.Shared.Controllers;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "QuickChat.Api/") });
builder.Services.AddScoped<AbstractDataFactory, TestDataFactory>();
builder.Services.AddScoped<ChatService>(); // Register the ChatService

// Register DBLoadController
builder.Services.AddScoped<DBLoadController>();

await builder.Build().RunAsync();
