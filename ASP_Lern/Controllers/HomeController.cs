using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_Lern.Models;
using ASP_Lern.Services;

namespace ASP_Lern.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly WeatherService _weatherService;

    public HomeController( ILogger<HomeController> logger, WeatherService weatherService )
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    public async Task<IActionResult> Weather(string city = "Yoshkar-Ola" )
    {
        try
        {
            var weather = await _weatherService.GetWeatherAsync( city );
            ViewBag.City = weather.City;
            ViewBag.Temperature = weather.Temperature;
            ViewBag.Description = weather.Description;
        }
        catch(Exception ex )
        {
            ViewBag.Error = "Ошибка: " + ex.Message;
        }

        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
