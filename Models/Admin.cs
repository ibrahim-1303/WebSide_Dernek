﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje008.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string KullanıcıAdı { get; set; }
        [Column(TypeName = "Varchar(10)")]

        public string Sifre { get; set; }
    }
}
