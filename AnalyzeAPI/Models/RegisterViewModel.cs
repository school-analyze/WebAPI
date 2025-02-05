using System.ComponentModel.DataAnnotations;

namespace AnalyzeAPI.Models;

public class RegisterViewModel
{
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}