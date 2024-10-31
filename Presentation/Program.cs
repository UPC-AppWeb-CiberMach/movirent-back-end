using Application.Renting.CommandServices;
using Application.Renting.QueryServices;
using Application.Historial.CommandServices;
using Application.Historial.QueryServices;
using Application.Subscription.CommandServices;
using Application.Subscription.QueryServices;
using Domain.Renting.Repositories;
using Domain.Renting.Services;
using Domain.Historial.Repositories;
using Domain.Historial.Services;
using Domain.Shared;
using Domain.Subscription.Repositories;
using Domain.Subscription.Services;
using Infrastructure.Renting;
using Infrastructure.Historial;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Infrastructure.Subscription;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection native - before .net core Autofact,Nijtect
builder.Services.AddScoped<IScooterRepository, ScooterRepository>();
builder.Services.AddScoped<IScooterQueryService, ScooterQueryService>();
builder.Services.AddScoped<IScooterCommandService, ScooterCommandService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IHistorialRepository, HistorialRepository>();
builder.Services.AddScoped<IHistorialQueryService, HistorialQueryService>();
builder.Services.AddScoped<IHistorialCommandService, HistorialCommandService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var connectionString = builder.Configuration.GetConnectionString("MovirentPlatform");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
