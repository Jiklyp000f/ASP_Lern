using Microsoft.AspNetCore.Mvc;

namespace ASP_Lern.Controllers;

public class RegisterController : Controller
{
    // GET: /Register/
    public IActionResult Index()
    {
        return View();
    }

    // POST: /Register/
    [HttpPost]
    [ValidateAntiForgeryToken] // Добавьте защиту от CSRF
    public IActionResult Index( RegisterController model )
    {
        if ( !ModelState.IsValid )
        {
            // Возвращаем форму с ошибками
            return View( model );
        }

        // Логика сохранения данных (например, в БД)
        // Пример:
        // _context.Users.Add(new User { ... });
        // _context.SaveChanges();

        return RedirectToAction( "Success" ); // Перенаправляем на успешную страницу
    }
}
