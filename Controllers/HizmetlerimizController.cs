using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proje008.Models;

namespace Proje008.Controllers
{
    [Authorize]
    public class HizmetlerimizController : Controller
    {
        private readonly MojoDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HizmetlerimizController(MojoDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Hizmetlerimiz
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hizmetlerimizs.ToListAsync());
        }

        // GET: Hizmetlerimiz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetlerimiz = await _context.Hizmetlerimizs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmetlerimiz == null)
            {
                return NotFound();
            }

            return View(hizmetlerimiz);
        }

        // GET: Hizmetlerimiz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hizmetlerimiz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResimDosyası,Baslik,Aciklama")] Hizmetlerimiz hizmetlerimiz)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(hizmetlerimiz.ResimDosyası.FileName);

                string extension = Path.GetExtension(hizmetlerimiz.ResimDosyası.FileName);

                hizmetlerimiz.ResimYolu = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRoothPath + "/HizmetlerimizResimleri/", fileName);


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await hizmetlerimiz.ResimDosyası.CopyToAsync(fileStream);
                }

                _context.Add(hizmetlerimiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hizmetlerimiz);
        }

        // GET: Hizmetlerimiz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetlerimiz = await _context.Hizmetlerimizs.FindAsync(id);
            if (hizmetlerimiz == null)
            {
                return NotFound();
            }
            return View(hizmetlerimiz);
        }

        // POST: Hizmetlerimiz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimDosyası,Baslik,Aciklama")] Hizmetlerimiz hizmetlerimiz)
        {
            if (id != hizmetlerimiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                string wwwRoothPath = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(hizmetlerimiz.ResimDosyası.FileName);

                string extension = Path.GetExtension(hizmetlerimiz.ResimDosyası.FileName);

                hizmetlerimiz.ResimYolu = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRoothPath + "/HizmetlerimizResimleri/", fileName);
                


                using (var fileStream = new FileStream(path, FileMode.Create))
                {



                    await hizmetlerimiz.ResimDosyası.CopyToAsync(fileStream);

                }

                try
                {
                    _context.Update(hizmetlerimiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HizmetlerimizExists(hizmetlerimiz.Id))
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
            return View(hizmetlerimiz);
        }

        // GET: Hizmetlerimiz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetlerimiz = await _context.Hizmetlerimizs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmetlerimiz == null)
            {
                return NotFound();
            }

            return View(hizmetlerimiz);
        }

        // POST: Hizmetlerimiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hizmetlerimiz = await _context.Hizmetlerimizs.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "HizmetlerimizResimleri", hizmetlerimiz.ResimYolu);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }



                _context.Hizmetlerimizs.Remove(hizmetlerimiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HizmetlerimizExists(int id)
        {
            return _context.Hizmetlerimizs.Any(e => e.Id == id);
        }
    }
}
