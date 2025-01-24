using AnalyzeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyzeAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<GradeModel> Grades { get; set; } = null!;
    
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<UserModel>().HasIndex(u => u.UserName).IsUnique();

        modelBuilder.Entity<GradeModel>()
            .Property(g => g.Subject)
            .HasConversion<string>();
    }
}