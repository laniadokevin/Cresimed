using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Interfaces;
using System.Security.Claims;
using TestYourself.Campus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestYourself.Core.Entities.ViewModel.Campus;

namespace TestYourself.Campus.Controllers
{
    [Route("/Account")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private readonly IExamRepository _examRepository;
        private readonly IPercentilRepository _percentilRepository;

        private SecurityManager securityManager = new SecurityManager();

        public AccountController(IUserRepository userRepository,
            ILogRepository logRepository,
            IExamRepository examRepository,
            IPercentilRepository percentilRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _percentilRepository = percentilRepository ?? throw new ArgumentNullException(nameof(percentilRepository));
        }

        [Route("")]
        [Route("~/")]
        [Route("~/Account/index")]
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
                return RedirectToAction("Welcome","Account");
            }
        }

        [Authorize(Roles = "SuperAdmin")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Customer")]
        [Route("~/Account/welcome")]
        public IActionResult Welcome()
        {
            DashboardViewModel view = new DashboardViewModel();

            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            view.PieChart = _examRepository.GetAllBySpecialty(userID);
            view.Last5Exams = _examRepository.GetLast5Exams(userID);
            view.PercentilChart = _percentilRepository.GetPercentilsForUser(userID);
            if (view.PercentilChart.Percentils.Count()>10)
                view.PercentilChart.Percentils = view.PercentilChart.Percentils.Take(10).ToList();

            return View("Welcome", view);
        }

        [Route("~/Account/ForgotPwd")]
        public IActionResult ForgotPwd()
        {

            return View("ForgotPwd");
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Customer")]
        [Route("~/Account/ResetPwd")]
        public IActionResult ResetPwd(string password)
        {
            var pre = _userRepository.GetById(int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault()));


            pre.Password = BCrypt.Net.BCrypt.HashPassword(password);
            
            var user = _userRepository.UpdateUser(pre);

            return View("Welcome");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Customer")]
        [Route("~/Account/ResetPwd")]
        public IActionResult ResetPwd()
        {

            return View("ResetPwd");
        }

        [Route("~/Account/accessdenied")]
        public IActionResult AccessDenied()
        {
            ViewBag.error = "Access Denied";
            return View("Index");
        }


        [Route("~/Account/SignOut")]
        public IActionResult SignOut()
        {
            securityManager.SignOut(this.HttpContext);
            return RedirectToAction("Index");
        }

    }
}