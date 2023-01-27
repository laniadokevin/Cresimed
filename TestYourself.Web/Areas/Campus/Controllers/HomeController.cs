using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestYourself.Web.Models;

namespace TestYourself.Web.Areas.Campus.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("index2/{id}")]
        public IActionResult Index2(int id)
        {
            Debug.WriteLine("id: " + id);
            return View("Index");
        }
    }
}