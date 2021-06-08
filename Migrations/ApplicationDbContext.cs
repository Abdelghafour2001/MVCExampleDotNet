using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Data;

namespace MVC.Migrations
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Personne> Personnes{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=abdel_test;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>()
                .HasKey(e => e.Nom);
                
        }
    }
}
