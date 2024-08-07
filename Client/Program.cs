using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using QuickChat.Client;
using QuickChat.Shared.Data;
using QuickChat.Shared.Data.InitDataFactory;
using QuickChat.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "QuickChat.Api/") });
builder.Services.AddScoped<AbstractDataFactory, TestDataFactory>();
builder.Services.AddScoped<ChatService>(); // Register the ChatService

// Register QuickChatDbContext with Azure SQL Database
builder.Services.AddDbContext<QuickChatDbContext>(options =>
    options.UseSqlServer("Server=tcp:quick-chat-db-server.database.windows.net,1433;Initial Catalog=QuickChatDB;Persist Security Info=False;User ID=bezshumu;Password=Bad#oy@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

await builder.Build().RunAsync();
