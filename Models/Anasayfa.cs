using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Models
{
    public class Anasayfa
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ResimYolu { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ResimDosyası { get; set; }

        public string AnasayfaBaslik { get; set; }
        public string AnasayfaAciklama { get; set; }

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

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ResimYolu3 { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ResimDosyası3 { get; set; }

        public string AnasayfaBaslik2 { get; set; }
        public string AnasayfaAciklama2 { get; set; }

        public string AnasayfaBaslik3 { get; set; }
        public string AnasayfaAciklama3 { get; set; }
        public string AnasayfaBaslik4 { get; set; }
        public string AnasayfaAciklama4 { get; set; }
        public string AnasayfaBaslik5 { get; set; }
        public string AnasayfaAciklama5 { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ResimDosyası4 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ResimYolu4 { get; set; }

        public string PeopleSaysBaslik { get; set; }
        public string PeopleSaysAciklama { get; set; }


    }
}
