using Proje008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Services
{
    public class NeSöylüyorManager : INeSöylüyorService
    {
        private readonly MojoDbContext _dbContext;

        public NeSöylüyorManager(MojoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<NeSöylüyor> GetAll()
        {
            var Röportaj = _dbContext.NeSöylüyors;

            return Röportaj.ToList();
        }
    }
}
