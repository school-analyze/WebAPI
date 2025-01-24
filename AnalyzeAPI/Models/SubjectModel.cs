using System.ComponentModel.DataAnnotations;

namespace AnalyzeAPI.Models;

public class SubjectModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public ICollection<GradeModel> Grades { get; set; } = new List<GradeModel>();
}