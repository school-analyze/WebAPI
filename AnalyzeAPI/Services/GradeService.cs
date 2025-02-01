using AnalyzeAPI.Data;
using AnalyzeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyzeAPI.Services;

public class GradeService(AppDbContext db) : IGradeService
{
    private readonly AppDbContext _db = db;

    public async Task<List<GradeModel>> GetAllGrades()
    {
        return await _db.Grades.ToListAsync();
    }

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

    public async Task DeleteGrade(GradeModel grade)
    {
        _db.Grades.Remove(grade);
        await _db.SaveChangesAsync();
    }

    public async Task<GradeModel?> UpdateGrade(int id, GradeModel grade)
    {
        var existingGrade = await _db.Grades.FindAsync(id);
        if (existingGrade == null)
        {
            return null;
        }
        existingGrade.Grade = grade.Grade;
        existingGrade.PercentageInfluence = grade.PercentageInfluence;
        existingGrade.DateAdded = grade.DateAdded;
        
        await _db.SaveChangesAsync();
        return existingGrade;
    }
}