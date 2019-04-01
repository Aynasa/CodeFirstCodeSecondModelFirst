namespace CodeSecond
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Worker> Worker { get; set; }
        public virtual DbSet<Vklad> Vklad { get; set; }
        public virtual DbSet<Prog> Prog { get; set; }
        public virtual DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Vklad)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.Worker)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prog>()
                .HasMany(e => e.Vklads)
                .WithRequired(e => e.Prog)
                .WillCascadeOnDelete(false);
        }
    }
}
