using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace AnalyzeAPI.Models;

public class UserModel : IdentityUser<int>
{
    [Required]
    public bool IsAdmin { get; set; }
}