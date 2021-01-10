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
    public class ProjelerController : Controller
    {
        private readonly MojoDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProjelerController(MojoDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Projeler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projelers.ToListAsync());
        }

        // GET: Projeler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeler = await _context.Projelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeler == null)
            {
                return NotFound();
            }

            return View(projeler);
        }

        // GET: Projeler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projeler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResimDosyası,ResimDosyası1,ResimDosyası2,Baslik1,Aciklama,Yer,Kategori,KategoriYili")] Projeler projeler)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _hostEnvironment.WebRootPath;
                string wwwRoothPath1 = _hostEnvironment.WebRootPath;
                string wwwRoothPath2 = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(projeler.ResimDosyası.FileName);
                string fileName1 = Path.GetFileNameWithoutExtension(projeler.ResimDosyası1.FileName);
                string fileName2 = Path.GetFileNameWithoutExtension(projeler.ResimDosyası2.FileName);

                string extension = Path.GetExtension(projeler.ResimDosyası.FileName);
                string extension1 = Path.GetExtension(projeler.ResimDosyası1.FileName);
                string extension2 = Path.GetExtension(projeler.ResimDosyası2.FileName);

                projeler.ResimYolu = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                projeler.ResimYolu1 = fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension;
                projeler.ResimYolu2 = fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRoothPath + "/ProjelerResimleri/", fileName);
                string path1 = Path.Combine(wwwRoothPath + "/ProjelerResimleri/", fileName1);
                string path2 = Path.Combine(wwwRoothPath + "/ProjelerResimleri/", fileName2);


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await projeler.ResimDosyası.CopyToAsync(fileStream);
                }
                using (var fileStream1 = new FileStream(path1, FileMode.Create))
                {
                    await projeler.ResimDosyası1.CopyToAsync(fileStream1);
                }
                using (var fileStream2 = new FileStream(path2, FileMode.Create))
                {
                    await projeler.ResimDosyası2.CopyToAsync(fileStream2);
                }
                _context.Add(projeler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeler);
        }

        // GET: Projeler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeler = await _context.Projelers.FindAsync(id);
            if (projeler == null)
            {
                return NotFound();
            }
            return View(projeler);
        }

        // POST: Projeler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimYolu,ResimYolu1,ResimYolu2,Baslik1,Aciklama,Yer,Kategori,KategoriYili")] Projeler projeler)
        {
            if (id != projeler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjelerExists(projeler.Id))
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
            return View(projeler);
        }

        // GET: Projeler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeler = await _context.Projelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeler == null)
            {
                return NotFound();
            }

            return View(projeler);
        }

        // POST: Projeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proje= await _context.Projelers.FindAsync(id);
            var proje1 = await _context.Projelers.FindAsync(id);
            var proje2 = await _context.Projelers.FindAsync(id);


            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "ProjelerResimleri", proje.ResimYolu);
            var imagePath1 = Path.Combine(_hostEnvironment.WebRootPath, "ProjelerResimleri", proje1.ResimYolu1);
            var imagePath2 = Path.Combine(_hostEnvironment.WebRootPath, "ProjelerResimleri", proje2.ResimYolu2);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
                System.IO.File.Delete(imagePath1);
                System.IO.File.Delete(imagePath2);

            }

            _context.Projelers.Remove(proje);
            _context.Projelers.Remove(proje1);
            _context.Projelers.Remove(proje2);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProjelerExists(int id)
        {
            return _context.Projelers.Any(e => e.Id == id);
        }
    }
}
