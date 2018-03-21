namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


  
        [Table("Dete")]
    public partial class Dete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dete()
        {
            Prisutnosts = new HashSet<Prisutnost>();
        }

        public int DeteID { get; set; }

        [Required]
        [StringLength(20)]
        public string Ime { get; set; }

 

        [Required]
        [StringLength(20)]
        public string Prezime { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        [StringLength(13)]
        public string JMBG { get; set; }

        [Required]
        [StringLength(30)]
        public string ImeRoditelja { get; set; }

        public int DomacinstvoID { get; set; }

        public int VaspitnaGrupaID { get; set; }

        public virtual Domacinstvo Domacinstvo { get; set; }

        public virtual VaspitnaGrupa VaspitnaGrupa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prisutnost> Prisutnosts { get; set; }
    }
}
