using System;
using System.Collections.Generic;
using System.Text;

namespace BosApen.EF
{
    class Context
    {
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KPQ5N23\SQLEXPRESS;Initial Catalog=BosApen;Integrated Security=True");
        }
    }
}
