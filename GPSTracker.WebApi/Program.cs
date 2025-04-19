using GPSTracker.Application;
using GPSTracker.Infrastructure;
using GPSTracker.Infrastructure.Security.Jwt;
using GPSTracker.WebApi.Extensions;
using GPSTracker.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
Console.WriteLine($"Issuer: {jwtSettings?.Issuer}");
Console.WriteLine($"Audience: {jwtSettings?.Audience}");
Console.WriteLine($"Key: {jwtSettings?.Key}");
Console.WriteLine($"Duration: {jwtSettings?.DurationInMinutes} min");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>() 
            ?? throw new InvalidOperationException("JwtSettings section is missing from the configuration.");
        
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.RegisterEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
