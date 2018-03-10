using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TestDataBase.Models
{
    [Table("Proizvodi")]
    public partial class Proizvodi
    {
        public int ProizvodID { get; set; }

        [Required]
        [Display(Name = "Proizvodi")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Opis { get; set; }

        public int KategorijaID { get; set; }
        [Display(Name = "Cena proizvoda")]
        public decimal Price { get; set; }


      

        public virtual Category Kategorija { get; set; }
    }
}