using AnalyzeAPI.Models;

namespace AnalyzeAPI.Services;

public interface IGradeService
{
    public Task<GradeModel?> GetGradeById(int id);
    public Task<GradeModel> AddGrade(GradeModel grade);
    public Task DeleteGrade(int id);
    public Task<GradeModel?> UpdateGrade(int id, GradeModel grade);
}