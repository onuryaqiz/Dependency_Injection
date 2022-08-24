using Dependency_Injection.Models;
using Dependency_Injection.Services;
using Dependency_Injection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILog _log;
        // Controller'ın Constructor'ından IoC'lere erişebiliriz. 

        //public ILog Log { get; } // Getter ile erişme ama tercih edilmez.
        //public HomeController(ILog log)
        //{

        //    Log = log;

        //}

        //public HomeController(ILog log)
        //{
        //    _log = log;
        //}

        public IActionResult Index([FromServices] ILog log) // Action bazlı Dependency Injection'ı kullanmak da bu şekilde olmaktadır. Container'dan getir .
        {

            _log.Log();
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