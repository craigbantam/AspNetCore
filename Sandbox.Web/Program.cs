using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Sandbox.Data;
using Sandbox.Data.Repository;
using Sandbox.Services;
using Sandbox.Web.StartupServices;

var builder = WebApplication.CreateBuilder(args);

// Ensure external appsettings.json files are loaded from the current working directory
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

//builder.WebHost.UseUrls("http://0.0.0.0:80");

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();

// Register services
builder.Services.AddControllers();
builder.Services.AddScoped<MigrationStartupService>();
builder.Services.AddScoped<IHomeItemsRepository, HomeItemsRepository>();
builder.Services.AddScoped<IHomeItemService, HomeItemService>();

builder.Services.AddDbContext<HomeItemsDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        sqlOpts => sqlOpts.MigrationsAssembly("Sandbox.Migrations"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", cors =>
        cors.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Authentication:Authority"];
    options.Audience = builder.Configuration["Authentication:Audience"];
});

var app = builder.Build();

app.Services.GetService<ILogger<Program>>()?.LogInformation("App Started");

using (var scope = app.Services.CreateScope())
{
    var migrationService = scope.ServiceProvider.GetService<MigrationStartupService>();
    await migrationService.Init();
}



app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
