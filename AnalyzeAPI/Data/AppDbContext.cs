using AnalyzeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyzeAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<SubjectModel> Subjects { get; set; } = null!;
    public DbSet<GradeModel> Grades { get; set; } = null!;
    
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasIndex(u => u.UserName).IsUnique();
        modelBuilder.Entity<SubjectModel>().HasData(
            new SubjectModel { Id = 1, Name = "Math" },
            new SubjectModel { Id = 2, Name = "Italian" },
            new SubjectModel { Id = 3, Name = "History" },
            new SubjectModel { Id = 4, Name = "Physical Education" },
            new SubjectModel { Id = 5, Name = "SIR" },
            new SubjectModel { Id = 6, Name = "English" },
            new SubjectModel { Id = 7, Name = "Telecommunication" },
            new SubjectModel { Id = 8, Name = "TPI" },
            new SubjectModel { Id = 9, Name = "Computer Science" },
            new SubjectModel { Id = 10, Name = "Religion" }
        );
    }
}