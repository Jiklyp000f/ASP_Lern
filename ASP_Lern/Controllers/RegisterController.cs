using ASP_Lern.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using ASP_Lern.Services;

namespace ASP_Lern.Controllers;

public class RegisterController : Controller
{
    private readonly ApplicationDbContext _context;
    public RegisterController( ApplicationDbContext context )
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // POST: /Register/
    [HttpPost]
    [ValidateAntiForgeryToken] // Добавьте защиту от CSRF
    public async Task<IActionResult> Index( RegisterModel model )
    {
        if ( !ModelState.IsValid )
        {
            // Возвращаем форму с ошибками
            return View( model );
        }

        if ( _context.Users.Any( u => u.Username == model.Username ) )
        {
            ModelState.AddModelError( "Username", "This username is already taken." );
            return View( model );
        }

        // Проверяем уникальность Email
        if ( _context.Users.Any( u => u.Email == model.Email ) )
        {
            ModelState.AddModelError( "Email", "This email is already registered." );
            return View( model );
        }

        // Хэшируем пароль перед сохранением
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword( model.Password );

        var user = new ApplicationUser
        {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = hashedPassword,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        
        _context.Users.Add( user ); // Добавляем пользователя в контекст
        Console.WriteLine( $"Saving user: {model.Username}, {model.Email}, {model.Password}" );

        try
        {
            
            

            // Сохраняем изменения в базе данных
            await _context.SaveChangesAsync();
            Console.WriteLine( $"Saving user: {model.Username}, {model.Email}, {model.Password}" );

            // Перенаправляем на успешную страницу
            return RedirectToAction( "Success" );
        }
        catch ( Exception ex )
        {
            // Логирование ошибки
            Console.WriteLine( $"Error: {ex.Message}" );
            return View( "Error" );
        }
    }

    public IActionResult Success()
    {
        return View();
    }

}
