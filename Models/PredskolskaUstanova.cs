namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PredskolskaUstanova")]
    public partial class PredskolskaUstanova
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PredskolskaUstanova()
        {
            Vaspitacs = new HashSet<Vaspitac>();
            VaspitnaGrupas = new HashSet<VaspitnaGrupa>();
        }

        public int PredskolskaUstanovaID { get; set; }

        [Required]
        [StringLength(30)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(20)]
        public string BrojTelefona { get; set; }

        [Required]
        [StringLength(30)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(30)]
        public string PripadnostUstanove { get; set; }

        [Required]
        [StringLength(20)]
        public string PIB { get; set; }

        public int SedisteID { get; set; }

        public virtual Sediste Sediste { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaspitac> Vaspitacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaspitnaGrupa> VaspitnaGrupas { get; set; }
    }
}
