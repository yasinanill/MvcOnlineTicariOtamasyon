using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.siniflar
{
    public class Yapilacak
    {
        [Key]
        public int PYapilacakID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Baslik { get; set; }

        [Column(TypeName = "bit")]

        public bool Durum { get; set; }
  

    }
}