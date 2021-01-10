using Microsoft.AspNetCore.Mvc;
using Proje008.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.ViewComponents
{
    public class NeSöylüyorListViewComponent:ViewComponent
    {
        private readonly INeSöylüyorService _neSöylüyorService;

        public NeSöylüyorListViewComponent(INeSöylüyorService neSöylüyorService)
        {
            _neSöylüyorService = neSöylüyorService;
        }

        public IViewComponentResult Invoke()
        {
            var röportaj = _neSöylüyorService.GetAll();
            return View(röportaj);
        }
    }
}
