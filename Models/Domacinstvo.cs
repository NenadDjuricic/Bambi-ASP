namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Domacinstvo")]
    public partial class Domacinstvo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Domacinstvo()
        {
            Detes = new HashSet<Dete>();
        }

        public int DomacinstvoID { get; set; }

        public int BrojClanova { get; set; }

        public int BrojDece { get; set; }

        [Required]
        [StringLength(30)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dete> Detes { get; set; }
    }
}
