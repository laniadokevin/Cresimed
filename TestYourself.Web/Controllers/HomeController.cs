using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Entities.ViewModel.Web;
using TestYourself.Core.Interfaces;
using TestYourself.Web.Models;

namespace TestYourself.Web.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFaqRepository _faqRepository;

        public HomeController(ILogger<HomeController> logger,
            IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
            _logger = logger;
        }
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            FrontWebViewModel view = new FrontWebViewModel();
            view.Faqs = new List<Faq>();
            view.Faqs = _faqRepository.GetAll();
            return View("Index",view);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}