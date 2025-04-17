using GPSTracker.WebApi.Extensions;
using GPSTracker.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
