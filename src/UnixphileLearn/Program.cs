using Microsoft.EntityFrameworkCore;
using UnixphileLearn.Components;
using UnixphileLearn.Data;
using UnixphileLearn.Models;
using UnixphileLearn.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<LmsDbContext>(options => options.UseSqlite("Data Source=lms.db"));

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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapCourseEndpoints();

app.Run();
