using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AnalyzeAPI.Models;

public class UserModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    [Required]
    public bool IsAdmin { get; set; }

    public ICollection<GradeModel>? Grades { get; set; } = new List<GradeModel>();
}