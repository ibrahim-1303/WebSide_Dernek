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
    public class HakkimizdaController : Controller
    {
        private readonly MojoDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HakkimizdaController(MojoDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Hakkimizda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hakkimizdas.ToListAsync());
        }

        // GET: Hakkimizda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizda = await _context.Hakkimizdas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkimizda == null)
            {
                return NotFound();
            }

            return View(hakkimizda);
        }

        // GET: Hakkimizda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hakkimizda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResimDosyası,Baslik,Aciklama")] Hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(hakkimizda.ResimDosyası.FileName);

                string extension = Path.GetExtension(hakkimizda.ResimDosyası.FileName);

                hakkimizda.ResimYolu = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRoothPath + "/HakkimizdaResimleri/", fileName);


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await hakkimizda.ResimDosyası.CopyToAsync(fileStream);
                }
                _context.Add(hakkimizda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimizda);
        }

        // GET: Hakkimizda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizda = await _context.Hakkimizdas.FindAsync(id);
            if (hakkimizda == null)
            {
                return NotFound();
            }
            return View(hakkimizda);
        }

        // POST: Hakkimizda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimYolu,Baslik,Aciklama")] Hakkimizda hakkimizda)
        {
            if (id != hakkimizda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakkimizda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HakkimizdaExists(hakkimizda.Id))
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
            return View(hakkimizda);
        }

        // GET: Hakkimizda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizda = await _context.Hakkimizdas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkimizda == null)
            {
                return NotFound();
            }

            return View(hakkimizda);
        }

        // POST: Hakkimizda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hakkimizda = await _context.Hakkimizdas.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "HakkimizdaResimleri", hakkimizda.ResimYolu);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _context.Hakkimizdas.Remove(hakkimizda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HakkimizdaExists(int id)
        {
            return _context.Hakkimizdas.Any(e => e.Id == id);
        }
    }
}
