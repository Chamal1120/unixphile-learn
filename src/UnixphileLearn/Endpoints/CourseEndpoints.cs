namespace UnixphileLearn.Endpoints;

using Microsoft.EntityFrameworkCore;
using UnixphileLearn.Models;
using UnixphileLearn.Data;
using System.Threading.Tasks;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/courses", async (LmsDbContext db) =>
        await db.Courses.ToListAsync());

        app.MapPost("/api/courses", async (LmsDbContext db, Course course) =>
        {
            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return Results.Created($"/api/courses/{course.Id}", course);
        });
    }
    
}