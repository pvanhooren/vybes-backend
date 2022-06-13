using Microsoft.EntityFrameworkCore;
using ProfileMicroservice.Data;
using ProfileMicroservice.Data.Repositories;
using ProfileMicroservice.Data.Repositories.Interfaces;
using ProfileMicroservice.RabbitMQ;
using ProfileMicroservice.RabbitMQ.Interfaces;
using ProfileMicroservice.Services;
using ProfileMicroservice.Services.Interfaces;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Environment);

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

void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
{
    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:ProfilesConn"],
            sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); });
    }, ServiceLifetime.Transient);
    
    services.AddSingleton<IMessageBusClient, MessageBusClient>();
    
    services.AddTransient<IProfileService, ProfileService>();
    services.AddTransient<IProfileRepository, ProfileRepository>();
    
    services.AddCors(options =>
        options.AddPolicy("CorsPolicy", b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
}
