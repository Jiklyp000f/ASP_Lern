using System.ComponentModel.DataAnnotations;

namespace ASP_Lern.Models;

public class ApplicationUser
{
    [Key] // Первичный ключ
    public int Id { get; set; } // Автоинкремент

    [Required]
    [StringLength( 50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters." )]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; } // Хэшированный пароль

    [Required]
    public bool IsActive { get; set; } = true; // Активен ли пользователь

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Дата создания
}