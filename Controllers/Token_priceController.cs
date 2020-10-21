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
    public class Token_priceController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Token_priceController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Token_price
        public async Task<IActionResult> Index()
        {
            var token = _context.Token_price.FirstOrDefault();
            if (token == null)
            {
                return Redirect("~/Token_price/Create");

            }
            else
            {
                return View(await _context.Token_price.ToListAsync());

            }
        }

        // GET: Token_price/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token_price = await _context.Token_price
                .FirstOrDefaultAsync(m => m.ID == id);
            if (token_price == null)
            {
                return NotFound();
            }

            return View(token_price);
        }

        // GET: Token_price/Create
        public IActionResult Create()
        {
            var token = _context.Token_price.FirstOrDefault();
            if (token == null)
            {
            return View();


            }
            else
            {
                return Redirect("~/Token_price/Index");

            }
        }

        // POST: Token_price/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Token_pricelist,DateModified")] Token_price token_price)
        {
            if (ModelState.IsValid)
            {
                _context.Add(token_price);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(token_price);
        }

        // GET: Token_price/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token_price = await _context.Token_price.FindAsync(id);
            if (token_price == null)
            {
                return NotFound();
            }
            return View(token_price);
        }

        // POST: Token_price/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Token_pricelist,DateModified")] Token_price token_price)
        {
            if (id != token_price.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(token_price);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Token_priceExists(token_price.ID))
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
            return View(token_price);
        }

        // GET: Token_price/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token_price = await _context.Token_price
                .FirstOrDefaultAsync(m => m.ID == id);
            if (token_price == null)
            {
                return NotFound();
            }

            return View(token_price);
        }

        // POST: Token_price/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token_price = await _context.Token_price.FindAsync(id);
            _context.Token_price.Remove(token_price);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Token_priceExists(int id)
        {
            return _context.Token_price.Any(e => e.ID == id);
        }
    }
}
