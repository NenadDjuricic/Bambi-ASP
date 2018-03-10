namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sediste")]
    public partial class Sediste
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sediste()
        {
            PredskolskaUstanovas = new HashSet<PredskolskaUstanova>();
        }

        public int SedisteID { get; set; }

        [Required]
        [StringLength(30)]
        public string Naziv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PredskolskaUstanova> PredskolskaUstanovas { get; set; }
    }
}
