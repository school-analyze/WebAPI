using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnalyzeAPI.Models;

public class GradeModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey(nameof(UserModel))]
    public int UserId { get; set; }
    [Required]
    public Subject Subject { get; set; }
    [Required]
    [Range(0.00, 10.00)]
    [Precision(4, 2)]
    public decimal Grade { get; set; }
    [Required]
    [Range(0, 100)]
    public int PercentageInfluence { get; set; } = 100;
    [Required]
    public DateOnly DateAdded { get; set; }
}