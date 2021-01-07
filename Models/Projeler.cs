using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Models
{
    public class Projeler
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ResimYolu { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ResimDosyası { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ResimYolu1 { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ResimDosyası1 { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ResimYolu2 { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ResimDosyası2 { get; set; }

        public string Baslik1 { get; set; }
        public string Aciklama { get; set; }
        public string Yer { get; set; }
        public string Kategori { get; set; }
        public string KategoriYili { get; set; }



    }
}
