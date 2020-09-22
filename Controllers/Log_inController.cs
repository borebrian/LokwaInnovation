using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using LokwaInnovation.Models;

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
                _context.Add(log_in);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(log_in);
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
