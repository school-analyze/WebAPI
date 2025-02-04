using AnalyzeAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnalyzeAPI.Data;

public class AppDbContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
{
    public DbSet<GradeModel> Grades { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<GradeModel>()
            .Property(g => g.Subject)
            .HasConversion<int>();
    }
}