using AnalyzeAPI.Data;
using AnalyzeAPI.Models;

namespace AnalyzeAPI.Services;

public class GradeService(AppDbContext db) : IGradeService
{
    private readonly AppDbContext _db = db;

    public async Task<GradeModel?> GetGradeById(int id)
    {
        return await _db.Grades.FindAsync(id);
    }

    public async Task<GradeModel> AddGrade(GradeModel grade)
    {
        _db.Grades.Add(grade);
        await _db.SaveChangesAsync();
        return grade;
    }

    public async Task DeleteGrade(int id)
    {
        var grade = await _db.Grades.FindAsync(id);
        if (grade == null)
        {
            throw new Exception("Grade not found");
        }
        
        _db.Grades.Remove(grade);
        await _db.SaveChangesAsync();
    }

    public Task<GradeModel?> UpdateGrade(int id, GradeModel grade)
    {
        throw new NotImplementedException();
    }
}