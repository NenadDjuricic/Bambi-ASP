namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaspitnaGrupa")]
    public partial class VaspitnaGrupa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VaspitnaGrupa()
        {
            Detes = new HashSet<Dete>();
            Vaspitacs = new HashSet<Vaspitac>();
        }

        public int VaspitnaGrupaID { get; set; }

        [Required]
        [Display(Name = "Grupa")]
        [StringLength(30)]
        public string Naziv { get; set; }

        public int PredskolskaUstanovaID { get; set; }

        public int DnevnikRadaID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dete> Detes { get; set; }

        public virtual DnevnikRada DnevnikRada { get; set; }

        public virtual PredskolskaUstanova PredskolskaUstanova { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaspitac> Vaspitacs { get; set; }
    }
}
