using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container with camelCase JSON serialization for JS-friendly responses.
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
});

// Configure CORS: allow localhost:3000 during development and an optional production origin from configuration.
var allowedOrigins = new List<string>
{
    "http://localhost:3000",
};

var prodOrigin = builder.Configuration["ProductionOrigin"]; // set this in appsettings or env for production
if (!string.IsNullOrWhiteSpace(prodOrigin)) allowedOrigins.Add(prodOrigin);

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins.ToArray())
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new global::Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Santhosh S Portfolio API",
        Version = "v1",
        Description = "API endpoints for Santhosh S's personal portfolio website"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Santhosh S Portfolio API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root (https://localhost:5001)
    });
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("DefaultCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
