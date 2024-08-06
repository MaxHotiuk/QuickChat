using QuickChat.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR().AddAzureSignalR();
var app = builder.Build();

app.UseDefaultFiles();
app.UseRouting();
app.UseStaticFiles();
app.MapHub<ChatSampleHub>("/chat");
await app.RunAsync();