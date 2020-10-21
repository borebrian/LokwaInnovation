using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using LokwaInnovation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using System.IdentityModel.Tokens.Jwt;

namespace LokwaInnovation.Controllers
{
    public class Log_inController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Log_inController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Log_in
        public async Task<IActionResult> Index()
        {
            return View(await _context.Log_in.ToListAsync());
        }

        // GET: Log_in/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log_in = await _context.Log_in
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (log_in == null)
            {
                return NotFound();
            }

            return View(log_in);
        }

        // GET: Log_in/Create


        public IActionResult Log_in()
        {
            return View();
        }
        public IActionResult LoginUser(Log_in user)
        {
            if (user.Phone_number == null || user.Password == null)
            {
                TempData["Error"] = "Username and password is required!";
                return Redirect("~/Log_in/Log_in");
            }
            else
            {
                var pass = user.Password;
              
                TokenProvider TokenProvider = new TokenProvider(_context);

                var userToken = TokenProvider.LoginUser(user.Phone_number, user.Password);
                if (userToken == null)
                {
                    
                    TempData["Error"] = "Invalid login credentials";
                    return Redirect("~/Log_in/Log_in");
                }
                else
                {
                    HttpContext.Session.SetString("JWToken", userToken);
                    TempData["Error"] = "Successfully loged in!";

                   // var blog = _context.Log_in
                   //.Where(b => b.Phone_number.ToString() == user.Phone_number)
                   //.FirstOrDefault();
                    

                    //HttpContext.Session.SetString("Roles", blog.Roles.ToString());
                    //return Content(HttpContext.Session.GetString("Roles"));

                    return Redirect("~/Home/redd");

                }
            }
               


            
         
            
            //return Redirect("~/Tenders/Master");


        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public void redd()
        {
            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;
            //LETS GET CLIENTS NAME
            var contacts =  _context.Log_in
                .First(m => m.User_ID.ToString() == user_id);
            HttpContext.Session.SetString("FullNames", contacts.Full_name);
            HttpContext.Session.SetString("PhoneNumber", contacts.Phone_number);
            HttpContext.Session.SetString("Roles", contacts.Roles.ToString());
            

           
        }

        public IActionResult Logoff()
        {

            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");

        }



        // POST: Log_in/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Log_in([Bind("Full_name,Phone_number,Email,Password,Date,User_ID,Roles")] Log_in log_in)
        {



            return View();
        }

        
            public IActionResult Create()
        {
            return View();
        }

        // POST: Log_in/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create([Bind("Full_name,Phone_number,Email,Password,Date,User_ID,Roles")] Log_in log_in)
        {


            if (ModelState.IsValid)
            {

                


                bool clientUsernameExists = _context.Log_in.Any(x => x.Phone_number == log_in.Phone_number);
                if (clientUsernameExists)
                {
                    ViewBag.MessageError = "A user has been registered with above phone number.Please use another phone number!";
                    return View();
                }
                else
                {
                    _context.Add(log_in);
                    await _context.SaveChangesAsync();
                    ViewBag.MessageSuccess = "User created successfully please log in to proceed!";
                    return View();
                }

              
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }

        }

        // GET: Log_in/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log_in = await _context.Log_in.FindAsync(id);
            if (log_in == null)
            {
                return NotFound();
            }
            return View(log_in);
        }

        // POST: Log_in/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Full_name,Phone_number,Email,Password,Date,User_ID,Roles")] Log_in log_in)
        {
            if (id != log_in.User_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log_in);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Log_inExists(log_in.User_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(log_in);
        }

        // GET: Log_in/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log_in = await _context.Log_in
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (log_in == null)
            {
                return NotFound();
            }

            return View(log_in);
        }

        // POST: Log_in/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log_in = await _context.Log_in.FindAsync(id);
            _context.Log_in.Remove(log_in);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Log_inExists(int id)
        {
            return _context.Log_in.Any(e => e.User_ID == id);
        }
    }
}
