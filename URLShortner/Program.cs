using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Middleware;
using UrlShortener.Services;

var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseInMemoryDatabase("UrlShortenerDb"));
builder.Services.AddScoped<IUrlShortenerService, UrlShortenerService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "URL Shortener API", Version = "v1" });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

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
