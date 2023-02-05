using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Interfaces;
using TestYourself.Web.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using TestYourself.Core.Entities.Enum;
using TestYourself.Core.Entities.ViewModel.Admin.Grid;
using TestYourself.Core.Entities.ViewModel.Web;

namespace TestYourself.Web.Controllers
{
    [Route("/Account")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;


        public AccountController(IUserRepository userRepository, ILogRepository logRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        }

        [Route("~/Account/Register")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [Route("~/Account/Register")]
        public IActionResult Register(RegisterViewModel view)
        {
            return View();
        }


    }
}