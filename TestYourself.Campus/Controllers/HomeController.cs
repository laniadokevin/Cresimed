using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestYourself.Campus.Models;
using TestYourself.Core.Entities.ViewModel.Campus;
using TestYourself.Core.Interfaces;

namespace TestYourself.Campus.Controllers
{
    [Route("/Contact")]
    public class HomeController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public HomeController( IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [Route("~/Contact/NewContact")]
        public IActionResult NewContact()
        {
            return View(new ContactViewModel());
        }


        [HttpPost]
        [Route("~/Contact/NewContact")]
        public IActionResult NewContact(ContactViewModel view)
        {
            var e = _contactRepository.SaveContact(view.Contact);
            if (e.ContactID > 0)
            {
                var nview = new ContactViewModel();

                nview.Status = "Mensaje enviado correctamente!";
                nview.isOk = true;

                return View(nview);
            }
            else
            {
                var nview = new ContactViewModel();

                nview.Status = "Error intente nuevamente mas tarde!";
                nview.isOk = false;

                return View(nview);
            }
        }

    }
}