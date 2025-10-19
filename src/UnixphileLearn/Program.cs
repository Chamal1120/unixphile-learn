using Microsoft.EntityFrameworkCore;
using UnixphileLearn.Components;
using UnixphileLearn.Data;
using UnixphileLearn.Models;
using UnixphileLearn.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

// Load connection string based on environment
var environment = builder.Environment.EnvironmentName;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure the database context to use the connection string from appsettings
builder.Services.AddDbContext<LmsDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )));

// Log the current environment
Console.WriteLine($"Current Environment: {builder.Environment.EnvironmentName}");
Console.WriteLine($"Connection String: {connectionString}");

var app = builder.Build();

// Seed initial data (for testing)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LmsDbContext>();
    if (!db.Courses.Any())
    {
        db.Courses.Add(new Course { Title = "Intro to Blazor", Description = "Learn Blazor Basics" });
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAntiforgery();

app.UseStaticFiles();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapCourseEndpoints();

app.Run();
