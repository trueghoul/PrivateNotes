using System.ComponentModel.DataAnnotations;

namespace PrivateNotes.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Required")]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required(ErrorMessage = "Required")]
    [Compare("Password", ErrorMessage = "Password do not match")]
    public string ConfirmPassword { get; set; }
}