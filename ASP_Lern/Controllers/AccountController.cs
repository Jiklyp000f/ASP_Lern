using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Lern.Controllers;

public class AccountController : Controller
{
    public ActionResult LogIn()
    {
        return View();
    }
    public ActionResult Register()
    {
        return View();
    }
}
