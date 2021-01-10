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

namespace Proje008.Models
{
    [Authorize]
    public class NeSöylüyorController : Controller
    {
        private readonly MojoDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public NeSöylüyorController(MojoDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: NeSöylüyor
        public async Task<IActionResult> Index()
        {
            return View(await _context.NeSöylüyors.ToListAsync());
        }

        // GET: NeSöylüyor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neSöylüyor = await _context.NeSöylüyors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neSöylüyor == null)
            {
                return NotFound();
            }

            return View(neSöylüyor);
        }

        // GET: NeSöylüyor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NeSöylüyor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResimDosyası,Aciklama,Ad,Meslek")] NeSöylüyor neSöylüyor)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(neSöylüyor.ResimDosyası.FileName);

                string extension = Path.GetExtension(neSöylüyor.ResimDosyası.FileName);

                neSöylüyor.ResimYolu = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRoothPath + "/NeSöylüyorResimleri/", fileName);


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await neSöylüyor.ResimDosyası.CopyToAsync(fileStream);
                }

                _context.Add(neSöylüyor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(neSöylüyor);
        }

        // GET: NeSöylüyor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neSöylüyor = await _context.NeSöylüyors.FindAsync(id);
            if (neSöylüyor == null)
            {
                return NotFound();
            }
            return View(neSöylüyor);
        }

        // POST: NeSöylüyor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimYolu,Aciklama,Ad,Meslek")] NeSöylüyor neSöylüyor)
        {
            if (id != neSöylüyor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neSöylüyor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeSöylüyorExists(neSöylüyor.Id))
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
            return View(neSöylüyor);
        }

        // GET: NeSöylüyor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neSöylüyor = await _context.NeSöylüyors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neSöylüyor == null)
            {
                return NotFound();
            }

            return View(neSöylüyor);
        }

        // POST: NeSöylüyor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neSöylüyor = await _context.NeSöylüyors.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "NeSöylüyorResimleri", neSöylüyor.ResimYolu);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.NeSöylüyors.Remove(neSöylüyor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeSöylüyorExists(int id)
        {
            return _context.NeSöylüyors.Any(e => e.Id == id);
        }
    }
}
