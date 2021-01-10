using Proje008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Services
{
  public  interface IHizmetService
    {
        List<Hizmetlerimiz> GetAll();
    }
}
