﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Models
{
    public class NeSöylüyor
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ResimYolu { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ResimDosyası { get; set; }


        public string Aciklama { get; set; }
        public string Ad { get; set; }
        public string Meslek { get; set; }


    }
}
