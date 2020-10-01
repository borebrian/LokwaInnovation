using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using Lubes.Models;

namespace LokwaInnovation.Controllers
{
    public class PDF_RefferenceController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PDF_RefferenceController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: PDF_Refference
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pdf_refference.ToListAsync());
        }

        // GET: PDF_Refference/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF_Refference = await _context.Pdf_refference
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pDF_Refference == null)
            {
                return NotFound();
            }

            return View(pDF_Refference);
        }

        // GET: PDF_Refference/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PDF_Refference/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Doc_id,Refference_url,Date_modified")] PDF_Refference pDF_Refference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pDF_Refference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pDF_Refference);
        }

        // GET: PDF_Refference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF_Refference = await _context.Pdf_refference.FindAsync(id);
            if (pDF_Refference == null)
            {
                return NotFound();
            }
            return View(pDF_Refference);
        }

        // POST: PDF_Refference/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Doc_id,Refference_url,Date_modified")] PDF_Refference pDF_Refference)
        {
            if (id != pDF_Refference.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pDF_Refference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PDF_RefferenceExists(pDF_Refference.ID))
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
            return View(pDF_Refference);
        }

        // GET: PDF_Refference/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF_Refference = await _context.Pdf_refference
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pDF_Refference == null)
            {
                return NotFound();
            }

            return View(pDF_Refference);
        }

        // POST: PDF_Refference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pDF_Refference = await _context.Pdf_refference.FindAsync(id);
            _context.Pdf_refference.Remove(pDF_Refference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PDF_RefferenceExists(int id)
        {
            return _context.Pdf_refference.Any(e => e.ID == id);
        }
    }
}
