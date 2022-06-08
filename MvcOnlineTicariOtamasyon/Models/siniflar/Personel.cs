using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.siniflar
{
    public class Personel { 
    
        [Key]
        public int PersonelID { get; set; }
        [Display(Name ="Personel Adi")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Display(Name = "Personel Soyadi")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Display(Name = "Personel Gorseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(1500)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int Departmanid { get; set; }
        public virtual Departmanlar Departmanlar { get; set;  }
    }
}