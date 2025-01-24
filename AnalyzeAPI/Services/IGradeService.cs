using AnalyzeAPI.Models;

namespace AnalyzeAPI.Services;

public interface IGradeService
{
    public Task<List<GradeModel>> GetAllGrades();
    public Task<GradeModel?> GetGradeById(int id);
    public Task<GradeModel> AddGrade(GradeModel grade);
    public Task DeleteGrade(GradeModel grade);
    public Task<GradeModel?> UpdateGrade(int id, GradeModel grade);
}