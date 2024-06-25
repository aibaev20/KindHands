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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginVolunteer(string email, string password, string phoneNumber)
        {
            if (!_volunteerService.CheckVolunteer(phoneNumber))
            {
                TempData["ErrorMessage"] = "Account not found.";
                return RedirectToAction("Login");
            }

            if (!_volunteerService.AuthenticateVolunteer(email, password, phoneNumber))
            {
                TempData["ErrorMessage"] = "Incorrect credentials.";
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LoginOrganisation(string email, string password, string phoneNumber)
        {
            if (!_organisationService.CheckOrganisation(phoneNumber))
            {
                TempData["ErrorMessage"] = "Account not found.";
                return RedirectToAction("Login");
            }

            if (!_organisationService.AuthenticateOrganisation(email, password, phoneNumber))
            {
                TempData["ErrorMessage"] = "Incorrect credentials.";
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RegisterVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName)
        {
            if (!_volunteerService.CheckVolunteer(phoneNumber))
            {
                _volunteerService.AddVolunteer(username, password, phoneNumber, email, firstName, lastName);
                TempData["SuccessMessage"] = "Account registered successfully. You can now log in.";
                return RedirectToAction("Register");
            }

            TempData["ErrorMessage"] = "Account with this phone number already exists.";
            return RedirectToAction("Register");
        }


        [HttpPost]
        public IActionResult RegisterOrganisation(string username, string password, string phoneNumber, string email, string name, string description)
        {
            if (!_organisationService.CheckOrganisation(phoneNumber))
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
