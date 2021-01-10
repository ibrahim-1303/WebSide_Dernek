using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Models
{
    public class MojoDbContext : DbContext
    {
        public MojoDbContext(DbContextOptions<MojoDbContext> options) : base(options)
        {

        }

        public DbSet<Anasayfa> Anasayfas { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Hizmetlerimiz> Hizmetlerimizs { get; set; }
        public DbSet<Projeler> Projelers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<NeSöylüyor> NeSöylüyors { get; set; }
    }
}
