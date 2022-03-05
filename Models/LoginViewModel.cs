using System.ComponentModel.DataAnnotations;

namespace PrivateNotes.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Required")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}