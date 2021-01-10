using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proje008.Models;

namespace Proje008.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly MojoDbContext _context;

        public AdminController(MojoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }

        public async Task<IActionResult> Index(Admin admin)
        {
            var giris = _context.Admins.FirstOrDefault(x =>
                x.KullanıcıAdı == admin.KullanıcıAdı && x.Sifre == admin.Sifre);

            if (giris != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, value: giris.KullanıcıAdı)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Admin");
            }

            if (giris == null)
            {
                return NotFound("Bilgiler eşleşmedi");
            }

            return View();
        }

        [Authorize]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string KullanıcıAdı, string Sifre)
        {
            var admin = _context.Admins.FirstOrDefault();
            if (admin!= null)
            {
                ViewBag.msj0 = "Bilgiler başarıyla değiştirildi";
                admin.KullanıcıAdı = KullanıcıAdı;
                admin.Sifre = Sifre;
                _context.SaveChanges();
                return View("Admin");
            }


            return NotFound("Bilgileriniz Değiştirilemedi");

        }


        public async Task<IActionResult> CikisYap()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","HomeController");
        }
    }
}
