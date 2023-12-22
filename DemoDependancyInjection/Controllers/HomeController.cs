using DemoDependancyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DPI.Services;
using DPI.Services.IServices;

namespace DemoDependancyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransient _transient1;
        private readonly ITransient _transient2;
        private readonly IScoped _scoped1;
        private readonly IScoped _scoped2;
        private readonly ISingleton _singleton1;
        private readonly ISingleton _singleton2;

        public HomeController(ILogger<HomeController> logger, ITransient transient1, ITransient transient2, 
                IScoped scoped1, IScoped scoped2, ISingleton singleton1 , ISingleton singleton2)
        {
            _logger = logger;
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        public IActionResult Index()
        {
            ViewBag.t1 = _transient1.GetGUID();
            ViewBag.t2 = _transient2.GetGUID();
            ViewBag.s1 = _scoped1.GetGUID();
            ViewBag.s2 = _scoped2.GetGUID();
            ViewBag.si1 = _singleton1.GetGUID();
            ViewBag.si2 = _singleton2.GetGUID();

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
}