using System.ComponentModel.DataAnnotations;

namespace ASP_Lern.Models;

public class RegisterModel
{
    [Required( ErrorMessage = "Username is required" )]
    public string Username { get; set; }

    [Required( ErrorMessage = "Email is required" )]
    [EmailAddress( ErrorMessage = "Invalid email format" )]
    public string Email { get; set; }

    [Required( ErrorMessage = "Password is required" )]
    public string Password { get; set; }

    [Required( ErrorMessage = "Confirm password is required" )]
    [Compare( "Password", ErrorMessage = "Passwords do not match" )]
    public string ConfirmPassword { get; set; }
}
