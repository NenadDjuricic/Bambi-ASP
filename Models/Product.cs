namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillItems = new HashSet<BillItem>();
        }

        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Proizvod")]
        [StringLength(50)]
        public string Name { get; set; }

        public int CategoryID { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        public int Unit { get; set; }
        [Display(Name = "Zaliha")]
        public decimal? Stock { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillItem> BillItems { get; set; }

        public virtual Category Category { get; set; }

        public virtual Unit Unit1 { get; set; }
    }
}
