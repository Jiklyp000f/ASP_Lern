using ASP_Lern.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

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

        var user = new ApplicationUser
        {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword( model.Password ),
            IsActive = true
        };
        _context.Users.Add( user );
        await _context.SaveChangesAsync();
        return RedirectToAction( "Success" ); // Перенаправляем на успешную страницу
    }
}
