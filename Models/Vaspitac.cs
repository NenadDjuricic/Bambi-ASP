namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vaspitac")]
    public partial class Vaspitac
    {
        public int VaspitacID { get; set; }

        [Required]
        [StringLength(15)]
        public string Ime { get; set; }

        [Required]
        [StringLength(15)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(20)]
        public string BrojTelefona { get; set; }

        [Required]
        [StringLength(13)]
        public string JMBG { get; set; }

        public int PredskolskaUstanovaID { get; set; }

        public int VaspitnaGrupaID { get; set; }

        public int DnevnikRadaID { get; set; }

        public virtual DnevnikRada DnevnikRada { get; set; }

        public virtual PredskolskaUstanova PredskolskaUstanova { get; set; }

        public virtual VaspitnaGrupa VaspitnaGrupa { get; set; }
    }
}
