using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proje008.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MojoDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger ,MojoDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Anasayfas.ToListAsync());
        }


        public async Task<IActionResult> Hizmetlerimiz()
        {
            return View(await _dbContext.Hizmetlerimizs.ToListAsync());
        }


        public async Task<IActionResult> Hakkımızda()
        {
            return View(await _dbContext.Hakkimizdas.ToListAsync());
        }


        public async Task<IActionResult> Projeler()
        {
            return View(await _dbContext.Projelers.ToListAsync());
        }


        public ActionResult İletisim()
        {
            return View();
        }




    }
}
