using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BosApen.EF
{
    class Context : DbContext
    {
        public DbSet<Aap> AapRecords { get; set; }
        public DbSet<Bos> BosRecords { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KPQ5N23\SQLEXPRESS;Initial Catalog=BosApen;Integrated Security=True");
        }
    }
}
