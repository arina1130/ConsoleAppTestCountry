using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Country>? countries;

        public HomeController(ILogger<HomeController> logger, IServiceProvider service)
        {
            _logger = logger;
            countries = service.GetService<CountryService>().Countries;
            countries.Sort();
        }

        public IActionResult Index()
        {   

            return View(countries);
        }


        [HttpGet]
        public IActionResult Details(string name)
        {
            Country country = countries.FirstOrDefault(c => c.Name.Official==name);
            return View(country);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}