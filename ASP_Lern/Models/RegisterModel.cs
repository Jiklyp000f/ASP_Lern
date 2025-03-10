using System.ComponentModel.DataAnnotations;

namespace ASP_Lern.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Username is reqired")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is reqired")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is reqired")]
    public string Password { get; set; }

}
