using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Gonderici { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]

        public string konu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Icerik { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Tarih { get; set; }
    }
}