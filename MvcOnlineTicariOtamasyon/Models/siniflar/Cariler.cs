using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10,ErrorMessage ="en fazla 10 karekter olabilir")]

        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Required(ErrorMessage =" bu alan bos kalamaz")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Required(ErrorMessage = " bu alan bos kalamaz")]
        public string CariSifre { get; set; }
        public bool Durum {get; set;}
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}