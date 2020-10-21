using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using Lubes.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace LokwaInnovation.Controllers
{
    public class PDF_RefferenceController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PDF_RefferenceController(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        [Authorize(Roles = "1")]

        // GET: PDF_Refference
        public async Task<IActionResult> Index([Optional] int id)
        {
           
            return View(await _context.Pdf_refference.ToListAsync());
        }

        // GET: PDF_Refference/Details/5
        [Authorize(Roles = "1")]

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
            var posts = _context.Pdf_refference.Where(w => w.Doc_id.ToString() == id.ToString());
            ViewBag.relatedPost = posts;
            return View(pDF_Refference);
        }

        // GET: PDF_Refference/Create
        [Authorize(Roles = "1")]

        public IActionResult Create([Optional] String id, [Optional] String PDFName)
        {
            if (id == null)
            {
                TempData["statusMessage"] = "You must add a PDF file first.";
                TempData["status"] = "Warning!";

                return RedirectToAction("Create", "PDF_Documents");
            }
            else
            {
                HttpContext.Session.SetString("docid", id);
                HttpContext.Session.SetString("docname", PDFName);
                var posts = _context.Pdf_refference.Where(w => w.Doc_id.ToString()== HttpContext.Session.GetString("docid")).ToList();
                ViewBag.relatedPost = posts;

                ViewBag.id = id;
                return View();
            }

        }

        // POST: PDF_Refference/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> Create( PDF_Refference pDF_Refference, [Optional] int id)
        {
            if (ModelState.IsValid)
            {

                string refcover = "Refferences/" + Guid.NewGuid().ToString() + pDF_Refference.Image.FileName;
                string serverFolder1 = Path.Combine(_webHostEnvironment.WebRootPath, refcover);
                await pDF_Refference.Image.CopyToAsync(new FileStream(serverFolder1, FileMode.Create));


                PDF_Refference pdfdoc = new PDF_Refference
                {
                    Doc_id = pDF_Refference.Doc_id,
                    Description = pDF_Refference.Description,
                    Refference_url = refcover,
                    Date_modified = DateTime.Now.ToString()
                };
                _context.Add(pdfdoc);
                await _context.SaveChangesAsync();

                ViewBag.status = "Refference has been uploaded successfully!";
                ViewBag.imageURL = "/" + refcover;
                ViewBag.Description = pDF_Refference.Description;
            }

            var posts = _context.Pdf_refference.Where(w => w.Doc_id.ToString() == HttpContext.Session.GetString("docid")).ToList();
            ViewBag.relatedPost = posts;
            return View();
        
    }

        [Authorize(Roles = "1")]

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
        [Authorize(Roles = "1")]

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
        [Authorize(Roles = "1")]

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
        [Authorize(Roles = "1")]

        // POST: PDF_Refference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pDF_Refference = await _context.Pdf_refference.FindAsync(id);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            var path = Path.Combine(_webHostEnvironment.WebRootPath, pDF_Refference.Refference_url);

            System.IO.File.Delete(path);
            _context.Pdf_refference.Remove(pDF_Refference);
            await _context.SaveChangesAsync();
            TempData["status"] = " Refference deleted successfulyy!";

            return RedirectToAction("Index", "PDF_Documents" );
        }

        private bool PDF_RefferenceExists(int id)
        {
            return _context.Pdf_refference.Any(e => e.ID == id);
        }
    }
}
