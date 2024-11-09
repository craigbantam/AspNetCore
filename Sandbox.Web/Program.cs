using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Sanbox.Services;
using Sandbox.Data;
using Sandbox.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IHomeItemsRepository, HomeItemsRepository>();
builder.Services.AddScoped<IHomeItemService, HomeItemService>();
builder.Services.AddDbContext<HomeItemsDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        optionsBuilder => optionsBuilder.MigrationsAssembly("Sandbox.Migrations"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
