using AnalyzeAPI.Models;

namespace AnalyzeAPI.Services;

public interface IGradeService
{
    public Task<GradeModel> GetGrade(int id);
    public Task<GradeModel> AddGrade(GradeModel grade);
    public Task<GradeModel> DeleteGrade(int id);
    public Task<GradeModel> UpdateGrade(int id, GradeModel grade);
}