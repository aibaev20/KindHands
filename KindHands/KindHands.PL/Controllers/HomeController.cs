using KindHands.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KindHands.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVolunteerService _volunteerService;
        private readonly IOrganisationService _organisationService;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IVolunteerService volunteerService, IOrganisationService organisationService)
        {
            _volunteerService = volunteerService;
            _organisationService = organisationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        /*
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */

        [HttpPost]
        public IActionResult RegisterVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName)
        {
            if (!_volunteerService.CheckVolunteer(firstName))
            {
                _volunteerService.AddVolunteer(username, password, phoneNumber, email, firstName, lastName);
                TempData["SuccessMessage"] = "Account registered successfully. You can now log in.";
                return RedirectToAction("Register");
            }

            TempData["ErrorMessage"] = "Account with this plate number already exists.";
            return RedirectToAction("Register");
        }


        [HttpPost]
        public IActionResult RegisterOrganisation(string username, string password, string phoneNumber, string email, string name, string description)
        {
            if (!_organisationService.CheckOrganisation(name))
            {
                _organisationService.AddOrganisation(username, password, phoneNumber, email, name, description);
                TempData["SuccessMessage"] = "Account registered successfully. You can now log in.";
                return RedirectToAction("Register");
            }

            TempData["ErrorMessage"] = "Account with this phone number already exists.";
            return RedirectToAction("Register");
        }
    }
}
