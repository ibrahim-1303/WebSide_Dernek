using Proje008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Services
{
    public class HizmetManager : IHizmetService
    {
        private readonly MojoDbContext _dbContext;

        public HizmetManager(MojoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Hizmetlerimiz> GetAll()
        {
            var hizmet = _dbContext.Hizmetlerimizs;

            return hizmet.ToList();
        }
    }
}
