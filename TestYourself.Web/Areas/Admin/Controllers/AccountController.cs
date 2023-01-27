using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Interfaces;
using TestYourself.Web.Models;

namespace TestYourself.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;

        private SecurityManager securityManager = new SecurityManager();

        public AccountController(IUserRepository userRepository, ILogRepository logRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        }

        [Route("")]
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var account = _userRepository.processLogin(username, password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || account == null)
            {
                ViewBag.error = "Invalid";
                return View("Index");
            }
            else
            {
                securityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("welcome");
            }
        }



        [Route("welcome")]
        public IActionResult Welcome()
        {
            return View("Welcome");
        }

        [Route("access-denied")]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        
        [Route("SignOut")]
        public IActionResult SignOut()
        {
            securityManager.SignOut(this.HttpContext);
            return RedirectToAction("Index");
        }
    }
}