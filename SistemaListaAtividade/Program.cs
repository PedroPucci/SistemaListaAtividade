using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using SistemaListaAtividade.Extensions;
using SistemaListaAtividade.Persistence.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

// Inicialize o logger Serilog
LogExtension.InitializeLogger();

// Obtenha o logger configurado
var loggerSerialLog = LogExtension.GetLogger();

// Use o logger...
loggerSerialLog.Information("Logging initialized.");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration!");
}

app.Run();
