using HR.LeaveManagement.Application;
using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Custom Services
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureService(builder.Configuration);
builder.Services.ConfigurePersistenceService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{Title = "HR.LeaveManagement.Api", Version = "v1"});
});

// Cors Policy
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", b => 
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
