using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Serve static files from wwwroot
app.UseStaticFiles();

// Map controllers
app.MapControllers();

// Optional: serve index.html as default
app.MapFallbackToFile("index.html");

app.Run();
