namespace TestDataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Vrtic : DbContext
    {
        public Vrtic()
            : base("name=Vrtic")
        {
        }

        public virtual DbSet<Dete> Detes { get; set; }
        public virtual DbSet<DnevnikRada> DnevnikRadas { get; set; }
        public virtual DbSet<Domacinstvo> Domacinstvoes { get; set; }
        public virtual DbSet<PredskolskaUstanova> PredskolskaUstanovas { get; set; }
        public virtual DbSet<Prisutnost> Prisutnosts { get; set; }
        public virtual DbSet<Sediste> Sedistes { get; set; }
        public virtual DbSet<Vaspitac> Vaspitacs { get; set; }
        public virtual DbSet<VaspitnaGrupa> VaspitnaGrupas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dete>()
                .HasMany(e => e.Prisutnosts)
                .WithRequired(e => e.Dete)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DnevnikRada>()
                .HasMany(e => e.Prisutnosts)
                .WithRequired(e => e.DnevnikRada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DnevnikRada>()
                .HasMany(e => e.Vaspitacs)
                .WithRequired(e => e.DnevnikRada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DnevnikRada>()
                .HasMany(e => e.VaspitnaGrupas)
                .WithRequired(e => e.DnevnikRada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Domacinstvo>()
                .HasMany(e => e.Detes)
                .WithRequired(e => e.Domacinstvo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PredskolskaUstanova>()
                .HasMany(e => e.Vaspitacs)
                .WithRequired(e => e.PredskolskaUstanova)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PredskolskaUstanova>()
                .HasMany(e => e.VaspitnaGrupas)
                .WithRequired(e => e.PredskolskaUstanova)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sediste>()
                .HasMany(e => e.PredskolskaUstanovas)
                .WithRequired(e => e.Sediste)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaspitnaGrupa>()
                .HasMany(e => e.Detes)
                .WithRequired(e => e.VaspitnaGrupa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaspitnaGrupa>()
                .HasMany(e => e.Vaspitacs)
                .WithRequired(e => e.VaspitnaGrupa)
                .WillCascadeOnDelete(false);
        }
    }
}
