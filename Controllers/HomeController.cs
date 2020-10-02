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
using Lubes.Models;

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

        public IActionResult PDF_ReaderTest()
        {
            return View();

        }


            [AllowAnonymous]
        public IActionResult Dashboard()
        {


            var  itemlist = _context.PDF_Documents.ToList();
            ViewBag.itemlist = itemlist;

            //BIND DOCUMENTS
            var messages = _context.AnonymousMessages.Where(x=> x.status==false).Count();
            ViewBag.messages = messages.ToString();


            //BIND DOCUMENTS
            var docs = _context.PDF_Documents.Count();
            ViewBag.docs = docs.ToString();


            //BIND VISITS
            var visits = _context.Visits_counter.Count();
            ViewBag.Visits = visits.ToString();

            //BIND CLIENTS
            var clients = _context.Log_in.Where(x=>x.Roles==2).Count();
            ViewBag.clients = clients.ToString();

            //BIND CLIENTS
            var faqs = _context.AnonymousMessages.Where(x => x.status).Count();
            ViewBag.faqs = faqs.ToString();
            return View();

        }

        //[ChildActionOnly]
        public ActionResult RenderMenu()
        {
            return PartialView("_MenuBar");
        }
         public ActionResult Visits()
        {
            return View(_context.Visits_counter.Take(10).ToList()); 
        }


        [AllowAnonymous]
        public IActionResult Index()
        {


          
            var author = new Visits_counter
            {

                Date = DateTime.Now.ToString(),
                Role = "Anonymous",
              
    
            };
            _context.Add(author);
            _context.SaveChanges();

            return View();

             

            
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Full_name,Phone_number,Subject,Message,status,Roles,ID,Time")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {

                Contacts contacts1 = new Contacts {
                    Full_name = contacts.Full_name,
                    Phone_number = contacts.Phone_number,
                    Subject = contacts.Subject,
                    Message = contacts.Message,
                    status = contacts.status,
                    Roles = contacts.Roles,
                    ID = contacts.ID,
                    Time = DateTime.Now.ToString()
                
                
                };

                _context.Add(contacts1);
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
