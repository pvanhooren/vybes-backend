using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
await app.UseOcelot();

app.MapControllers();
app.Run();


void ConfigureServices(IServiceCollection services)
{
    builder.WebHost.ConfigureAppConfiguration((_, config) =>
    {
        config.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json");
    });
    services.AddAuthentication();
    services.AddControllers();
    services.AddOcelot();
    services.AddCors(options =>
        options.AddPolicy("CorsPolicy", b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
}