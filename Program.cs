var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();  // <-- This line was missing

var app = builder.Build();

// Serve static files from wwwroot (your index.html)
app.UseDefaultFiles();  // serves index.html automatically
app.UseStaticFiles();

// Map controller routes
app.MapControllers();

app.Run();
