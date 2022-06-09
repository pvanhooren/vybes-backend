using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();

app.MapControllers();
app.Run();

void ConfigureServices(IServiceCollection services)
{
    builder.WebHost.ConfigureAppConfiguration((_, config) =>
    {
        config.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json");
    });
    
    string domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
    services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = domain;
            options.Audience = builder.Configuration["Auth0:Audience"];
            // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = ClaimTypes.NameIdentifier
            };
        });
    
    services.AddControllers();
    services.AddOcelot();
    services.AddCors(options =>
        options.AddPolicy("CorsPolicy", b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
}