namespace UnixphileLearn.Data;

using Microsoft.EntityFrameworkCore;
using UnixphileLearn.Models;

public class LmsDbContext : DbContext
{
    public LmsDbContext(DbContextOptions<LmsDbContext> options) : base(options) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
}