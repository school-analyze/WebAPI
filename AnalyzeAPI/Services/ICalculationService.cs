namespace AnalyzeAPI.Services;

public interface ICalculationService
{
    public Task<double> SubjectAverage(int subjectId);
}