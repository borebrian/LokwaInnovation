using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using Lubes.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LokwaInnovation.Controllers
{
    public class PDF_DocumentsController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment1;



        public PDF_DocumentsController(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _webHostEnvironment1 = webHostEnvironment;
        }

        // GET: PDF_Documents
        public async Task<IActionResult> Index([Optional] string Values)
        {
            if (Values == null)
            {
                return View(await _context.PDF_Documents.ToListAsync());
            }
            else
            {

                var posts = _context.PDF_Documents.Where(w => w.Document_name.Contains(Values)).ToList();
                int docCount = posts.Count();
                ViewBag.SeachResults = posts;
                ViewBag.count = docCount;
                @ViewBag.SearchValue = Values;
                return View();
            }
        }

        // GET: PDF_Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF_Documents = await _context.PDF_Documents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pDF_Documents == null)
            {
                return NotFound();
            }

            return View(pDF_Documents);
        }

        // GET: PDF_Documents/Create
        public async Task<IActionResult> PDF_Content(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF_Documents = await _context.PDF_Documents.FindAsync(id);
            if (pDF_Documents == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            var listOfdocs = _context.PDF_Documents.ToList();
            ViewBag.relatedItems = listOfdocs;

            return View(pDF_Documents);
        }

        public IActionResult Create()
        {

            return View();
        }

        // POST: PDF_Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PDF_Documents pDF_Documents)
        {

            if (ModelState.IsValid)
            {
                if (pDF_Documents.Document != null)
                {
                    string docfolder = "PDF_Documents/" + Guid.NewGuid().ToString() + pDF_Documents.Document.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, docfolder);
                    await pDF_Documents.Document.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                    //model.SaveAs(Server.MapPath(filePath));

                    //var filename = Path.GetFileName(file.FileName);
                    //var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), filename);
                    //file.SaveAs(path);
                    //tyre.Url = filename;

                    if (pDF_Documents.Cover_image != null)
                    {
                        string coverfolder = "Cover_images/" + Guid.NewGuid().ToString() + pDF_Documents.Cover_image.FileName;
                        string serverFolder1 = Path.Combine(_webHostEnvironment.WebRootPath, coverfolder);
                        await pDF_Documents.Cover_image.CopyToAsync(new FileStream(serverFolder1, FileMode.Create));




                        PDF_Documents pdfdoc = new PDF_Documents
                        {
                            Document_name = pDF_Documents.Document_name,
                            Document_description = pDF_Documents.Document_description,
                            Book_url = docfolder,
                            Cover_url = coverfolder
                        };
                        _context.Add(pdfdoc);
                        await _context.SaveChangesAsync();
                        TempData["book"] = docfolder;
                        TempData["name"] = pDF_Documents.Document_name;
                        TempData["description"] = pDF_Documents.Document_description;
                        TempData["cover"] = coverfolder;

                    }
                }
                //_context.Add(pDF_Documents);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //var itemlist = _context.PDF_Documents.Where(x => x.ID==pDF_Documents.ID).ToList();
            return View(pDF_Documents);
        }

        // GET: PDF_Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF_Documents = await _context.PDF_Documents.FindAsync(id);
            if (pDF_Documents == null)
            {
                return NotFound();
            }
            return View(pDF_Documents);
        }

        // POST: PDF_Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PDF_Documents pDF_Documents)
        {
            if (id != pDF_Documents.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int idd = id;
                    var pDF_Documents0 = await _context.PDF_Documents.FindAsync(id);
                    var pDF_Documents1 = await _context.PDF_Documents.FindAsync(idd);
                    var pDF_Documents2 = await _context.PDF_Documents.FindAsync(id);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, pDF_Documents2.Book_url);

                    System.IO.File.Delete(path);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    string docfolder = "PDF_Documents/" + Guid.NewGuid().ToString() + pDF_Documents.Document.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, docfolder);
                    await pDF_Documents.Document.CopyToAsync(new FileStream(serverFolder, FileMode.Create));


                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    var coverPath = Path.Combine(_webHostEnvironment1.WebRootPath, pDF_Documents1.Cover_url);
                    System.IO.File.Delete(coverPath);


                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    string coverfolder = "Cover_images/" + Guid.NewGuid().ToString() + pDF_Documents.Cover_image.FileName;
                    string serverFolder1 = Path.Combine(_webHostEnvironment.WebRootPath, coverfolder);
                    await pDF_Documents.Cover_image.CopyToAsync(new FileStream(serverFolder1, FileMode.Create));


                    var entity = _context.PDF_Documents.FirstOrDefault(item => item.ID == id);
                    if (entity != null)
                    {
                        entity.Book_url = docfolder;

                        entity.Cover_url = coverfolder;
                        entity.Date_modified = DateTime.Now.ToString();
                        entity.Document_description = pDF_Documents.Document_description;
                        entity.Document_name = pDF_Documents.Document_name;

                        await _context.SaveChangesAsync();





                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PDF_DocumentsExists(pDF_Documents.ID))
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
            return View(pDF_Documents);
        }

        // GET: PDF_Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF_Documents = await _context.PDF_Documents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pDF_Documents == null)
            {
                return NotFound();
            }

            return View(pDF_Documents);
        }

        // POST: PDF_Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pDF_Documents = await _context.PDF_Documents.FindAsync(id);
            var pDF_Documents1 = await _context.PDF_Documents.FindAsync(id);
            var pDF_Documents2 = await _context.PDF_Documents.FindAsync(id);

            _context.PDF_Documents.Remove(pDF_Documents);
            await _context.SaveChangesAsync();

            var ititems = _context.Pdf_refference.Where(m => m.Doc_id == id);
            _context.RemoveRange(ititems);
            _context.SaveChanges();
            TempData["status"] = " and all associated refference files has been deleted successfully!";

            var path = Path.Combine(this._webHostEnvironment.WebRootPath, pDF_Documents2.Book_url);

            //if (System.IO.File.Exists(path))
            //{
            GC.Collect();
            GC.WaitForPendingFinalizers();
            System.IO.File.Delete(path);

            //}


            //return Content(path);


            GC.Collect();
            GC.WaitForPendingFinalizers();
            var coverPath = Path.Combine(this._webHostEnvironment1.WebRootPath, pDF_Documents1.Cover_url);
            //if (System.IO.File.Exists(path))
            //{
            System.IO.File.Delete(coverPath);

            //}
            ViewBag.deleteSuccess = "true";
            return RedirectToAction(nameof(Index));

        }

        private bool PDF_DocumentsExists(int id)
        {
            return _context.PDF_Documents.Any(e => e.ID == id);
        }
    }
   
}
