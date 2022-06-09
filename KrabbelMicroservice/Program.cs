using KrabbelMicroservice.Data;
using KrabbelMicroservice.Data.Repositories;
using KrabbelMicroservice.Data.Repositories.Interfaces;
using KrabbelMicroservice.RabbitMQ;
using KrabbelMicroservice.RabbitMQ.Interfaces;
using KrabbelMicroservice.Services;
using KrabbelMicroservice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:KrabbelsConn"],
            sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); });
    }, ServiceLifetime.Singleton);

    services.AddSingleton<IEventProcessor, EventProcessor>();
    services.AddHostedService<MessageBusSubscriber>();

    services.AddTransient<IProfileKrabbelService, ProfileKrabbelService>();
    services.AddTransient<IProfileKrabbelRepository, ProfileKrabbelRepository>();
    
    services.AddCors(options =>
        options.AddPolicy("CorsPolicy", b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
}