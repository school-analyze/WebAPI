namespace AnalyzeAPI.Models;

public class GradeModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SubjectId { get; set; }
    public decimal Grade { get; set; }
    public int PercentageInfluence { get; set; }
    public DateOnly DateAddded { get; set; }
}