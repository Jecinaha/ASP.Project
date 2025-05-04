using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class LoginViewModel
{

    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address format.")]
    [Display(Name = "Email", Prompt = "Enter email address")]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"[A-Za-z\d!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~]{10,128}")]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter password")]
    public string Password { get; set; } = null!;

    public bool Remember { get; set; }
}
