﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab3.Ef
{
    public partial class VkladDb : DbContext
    {
        public VkladDb()
            : base("name=VkladDb")
        {
        }


        public DbSet<Vklad> Vklads { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Prog> Progs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Vklads)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prog>()
                .HasMany(e => e.Vklads)
                .WithRequired(e => e.Prog)
                .WillCascadeOnDelete(false);

        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<VkladDb>
    {
        protected override void Seed(VkladDb db)
        {
            Client m = new Client { FIO = "Колонин Альберт Сергеевич" };
            db.Clients.Add(m);
            db.SaveChanges();
            Prog c = new Prog { Prog_name = "Совсем выгодный", Percent = 7 };
            db.Progs.Add(c);
            db.SaveChanges();
            db.Vklads.Add(new Vklad { Balance = 1244, DateOpen = new System.DateTime(1991, 12, 31) });
            db.SaveChanges();
        }
    }

}
