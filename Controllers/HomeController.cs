using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LokwaInnovation.Models;
using LokwaInnovation.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace LokwaInnovation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [Authorize]
        public IActionResult redd()
        {


            var role = User.Identity.Name;

            if (role == "1")
            {
                return Redirect("~/Home/Dashboard");

            }
            else
            {
                return Content("Not allowed");

            }

        }

        [Authorize]
        public IActionResult Dashboard()
        {



            return View();
        
        }
            [Authorize]
        public IActionResult Index()
        {
          

            var email = User.Identity.Name;

            var bigCities = new List<Claim>();
            if (email == null)
            {
                return Content(null);

            }
            else
            {
                return Content(email.Count().ToString());

            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Full_name,Subject,Date,Message,ID")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacts);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Message sent successfully! we will reach back to you shortly";
                
            }

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
