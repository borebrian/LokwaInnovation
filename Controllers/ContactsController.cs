using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using LokwaInnovation.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;

namespace LokwaInnovation.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ContactsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnonymousMessages.Where(x => x.status == false).ToListAsync());
        }
        public async Task<IActionResult> Reply([Optional] String Names ,[Optional]String message,[Optional] string MessageReadStatus,[Optional] string Phone,[Optional] string role )
        {
            return View(await _context.AnonymousMessages.Where(x => x.status == false).ToListAsync());
        }
        [Authorize]

        public async Task<IActionResult> chartBox([Optional] String id, [Optional] String phone)
        {
            var rolse = User.Identity.Name;
            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;
            //LETS GET CLIENTS NAME
            var contacts = await _context.Log_in
                .FirstOrDefaultAsync(m => m.User_ID.ToString() == user_id);
            ViewBag.name = contacts.Full_name;


            //LETS GET USER DETAILS
            HttpContext.Session.SetString("FullNames", contacts.Full_name);
            HttpContext.Session.SetString("PhoneNumber", contacts.Phone_number);
            HttpContext.Session.SetString("Roles", contacts.Roles.ToString());

            var friends = _context.AnonymousMessages.Where(f => f.Phone_number == phone).ToList();
            friends.ForEach(a => a.status = true);
            _context.SaveChanges();

            //  LETS GET ALL HIS/ HER MESSAGES


            var result = _context.AnonymousMessages;



            return View( _context
        .AnonymousMessages.GroupBy(x => x.Phone_number)
        .Select(x => new { Location = x.Key, Buildings = x.Count() }).ToList());
            //}
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.AnonymousMessages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Full_name,Phone_number,Subject,Message,status,Roles,ID")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.AnonymousMessages.FindAsync(id);
            if (contacts == null)
            {
                return NotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Full_name,Phone_number,Subject,Message,status,Roles,ID")] Contacts contacts)
        {
            if (id != contacts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactsExists(contacts.ID))
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
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.AnonymousMessages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacts = await _context.AnonymousMessages.FindAsync(id);
            _context.AnonymousMessages.Remove(contacts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactsExists(int id)
        {
            return _context.AnonymousMessages.Any(e => e.ID == id);
        }
    }
}
