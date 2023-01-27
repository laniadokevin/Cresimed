using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TestYourself.Web.Models;

namespace TestYourself.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/demo")]
    public class DemoController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Work1()
        {
            return View("Work1");
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Work2()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            Debug.WriteLine(user.Value);
            return View("Work2");
        }

        [Authorize(Roles = "SuperAdmin,Admin,Employee")]
        public IActionResult Work3()
        {
            return View("Work3");
        }
    }
}