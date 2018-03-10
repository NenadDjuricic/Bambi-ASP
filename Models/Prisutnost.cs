namespace TestDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prisutnost")]
    public partial class Prisutnost
    {
        [Key]
        [Column(Order = 0)]
        public int PrisutnostID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DnevnikRadaID { get; set; }

        [Required]
        [StringLength(100)]
        public string Evidencija { get; set; }

        public int DeteID { get; set; }

        public virtual Dete Dete { get; set; }

        public virtual DnevnikRada DnevnikRada { get; set; }
    }
}
