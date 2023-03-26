using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Sales.API.Extentions;
using Sales.BLL.Extentions;
using Sales.DAL.Repositories.Contracts;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Logs/sales-api-.txt", rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}, [{Level}], {Message:lj}{NewLine}{Exception}")
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration.GetConnectionString("SalesDBConnection"));
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy
        .WithOrigins("http://localhost:7247", "https://localhost:7247")
        .WithHeaders(HeaderNames.ContentType)
        .AllowAnyMethod()
    );

app.UseHttpsRedirection();

app.UseAuthorization();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider.GetRequiredService<ISubElementRepository>;
    SubElementEnhancer.Configure(services.Invoke());
}

app.MapControllers();


app.Run();
