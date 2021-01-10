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
    public class AnasayfasController : Controller
    {
       

        private readonly MojoDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AnasayfasController(MojoDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Anasayfas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anasayfas.ToListAsync());
        }

        // GET: Anasayfas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anasayfa = await _context.Anasayfas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anasayfa == null)
            {
                return NotFound();
            }

            return View(anasayfa);
        }

        // GET: Anasayfas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anasayfas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResimDosyası,AnasayfaBaslik,AnasayfaAciklama,ResimDosyası1,ResimDosyası2,ResimDosyası3,AnasayfaBaslik2,AnasayfaAciklama2,AnasayfaBaslik3,AnasayfaAciklama3,AnasayfaBaslik4,AnasayfaAciklama4,ResimDosyası4")] Anasayfa anasayfa)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _hostEnvironment.WebRootPath;
                string wwwRoothPath1 = _hostEnvironment.WebRootPath;
                string wwwRoothPath2 = _hostEnvironment.WebRootPath;
                string wwwRoothPath3 = _hostEnvironment.WebRootPath;
                string wwwRoothPath4 = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(anasayfa.ResimDosyası.FileName);
                string fileName1 = Path.GetFileNameWithoutExtension(anasayfa.ResimDosyası1.FileName);
                string fileName2 = Path.GetFileNameWithoutExtension(anasayfa.ResimDosyası2.FileName);
                string fileName3 = Path.GetFileNameWithoutExtension(anasayfa.ResimDosyası3.FileName);
                string fileName4 = Path.GetFileNameWithoutExtension(anasayfa.ResimDosyası4.FileName);

                string extension = Path.GetExtension(anasayfa.ResimDosyası.FileName);
                string extension1 = Path.GetExtension(anasayfa.ResimDosyası1.FileName);
                string extension2 = Path.GetExtension(anasayfa.ResimDosyası2.FileName);
                string extension3 = Path.GetExtension(anasayfa.ResimDosyası3.FileName);
                string extension4 = Path.GetExtension(anasayfa.ResimDosyası4.FileName);


                anasayfa.ResimYolu = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                anasayfa.ResimYolu1 = fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension;
                anasayfa.ResimYolu2 = fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension;
                anasayfa.ResimYolu3 = fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension;
                anasayfa.ResimYolu4 = fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRoothPath + "/AnasayfaResimleri/", fileName);
                string path1 = Path.Combine(wwwRoothPath + "/AnasayfaResimleri/", fileName1);
                string path2 = Path.Combine(wwwRoothPath + "/AnasayfaResimleri/", fileName2);
                string path3 = Path.Combine(wwwRoothPath + "/AnasayfaResimleri/", fileName3);
                string path4 = Path.Combine(wwwRoothPath + "/AnasayfaResimleri/", fileName4);


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await anasayfa.ResimDosyası.CopyToAsync(fileStream);
                }
                using (var fileStream1 = new FileStream(path1, FileMode.Create))
                {
                    await anasayfa.ResimDosyası1.CopyToAsync(fileStream1);
                }
                using (var fileStream2 = new FileStream(path2, FileMode.Create))
                {
                    await anasayfa.ResimDosyası2.CopyToAsync(fileStream2);
                }
                using (var fileStream3 = new FileStream(path3, FileMode.Create))
                {
                    await anasayfa.ResimDosyası3.CopyToAsync(fileStream3);
                }
                using (var fileStream4 = new FileStream(path4, FileMode.Create))
                {
                    await anasayfa.ResimDosyası4.CopyToAsync(fileStream4);
                }

                _context.Add(anasayfa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anasayfa);
        }

        // GET: Anasayfas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anasayfa = await _context.Anasayfas.FindAsync(id);
            if (anasayfa == null)
            {
                return NotFound();
            }
            return View(anasayfa);
        }

        // POST: Anasayfas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimYolu,AnasayfaBaslik,AnasayfaAciklama,ResimYolu1,ResimYolu2,ResimYolu3,AnasayfaBaslik2,AnasayfaAciklama2,AnasayfaBaslik3,AnasayfaAciklama3,AnasayfaBaslik4,AnasayfaAciklama4,ResimYolu4")] Anasayfa anasayfa)
        {
            if (id != anasayfa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anasayfa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnasayfaExists(anasayfa.Id))
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
            return View(anasayfa);
        }

        // GET: Anasayfas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anasayfa = await _context.Anasayfas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anasayfa == null)
            {
                return NotFound();
            }

            return View(anasayfa);
        }

        // POST: Anasayfas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anasayfa = await _context.Anasayfas.FindAsync(id);
            var anasayfa1 = await _context.Anasayfas.FindAsync(id);
            var anasayfa2 = await _context.Anasayfas.FindAsync(id);
            var anasayfa3 = await _context.Anasayfas.FindAsync(id);
            var anasayfa4 = await _context.Anasayfas.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "AnasayfaResimleri", anasayfa.ResimYolu);
            var imagePath1 = Path.Combine(_hostEnvironment.WebRootPath, "AnasayfaResimleri", anasayfa1.ResimYolu1);
            var imagePath2 = Path.Combine(_hostEnvironment.WebRootPath, "AnasayfaResimleri", anasayfa2.ResimYolu2);
            var imagePath3 = Path.Combine(_hostEnvironment.WebRootPath, "AnasayfaResimleri", anasayfa3.ResimYolu3);
            var imagePath4 = Path.Combine(_hostEnvironment.WebRootPath, "AnasayfaResimleri", anasayfa4.ResimYolu4);

            if (System.IO.File.Exists(imagePath))
                {
                System.IO.File.Delete(imagePath);
                System.IO.File.Delete(imagePath1);
                System.IO.File.Delete(imagePath2);
                System.IO.File.Delete(imagePath3);
                System.IO.File.Delete(imagePath4);
            }

            _context.Anasayfas.Remove(anasayfa);
            _context.Anasayfas.Remove(anasayfa1);
            _context.Anasayfas.Remove(anasayfa2);
            _context.Anasayfas.Remove(anasayfa3);
            _context.Anasayfas.Remove(anasayfa4);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnasayfaExists(int id)
        {
            return _context.Anasayfas.Any(e => e.Id == id);
        }
    }
}
