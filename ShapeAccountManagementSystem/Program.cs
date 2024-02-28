
using Microsoft.EntityFrameworkCore;
using ShapeAccountManagementSystem.Extensions;
using ShapeAccountManagementSystem.Infrastracture.Context;
using ShapeAccountManagementSystem.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.ConfigureCors(builder.Configuration.GetSection("CORS:Origins")?.Value?.ToString()!);
builder.Services.AddDbContext<ShapeDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ShapeCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
